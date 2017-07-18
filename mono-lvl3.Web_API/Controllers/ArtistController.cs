using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using mono_lvl3.Service.Common;
using mono_lvl3.Common.Filters;
using mono_lvl3.Model.DomainModels;
using mono_lvl3.Web_API.ViewModels;
using System.Web.Http.Cors;

namespace mono_lvl3.Web_API.Controllers
{
    //
    [RoutePrefix("api/artist")]
    public class ArtistController : ApiController
    {
        #region Properites

        protected IArtistService Service { get; private set; }

        #endregion Properties


        #region Constructors

        //public ArtistController()  {  }

        public ArtistController(IArtistService service)
        {
            this.Service = service;
        }

        #endregion Constructors


        #region Methods

        [HttpGet]
        //[Route("{pageNumber}/{pageSize}")]
        public async Task<HttpResponseMessage> Get(string searchString = "", int pageNumber = 0, int pageSize = 0)
        {
            try
            {
                var artists = Mapper.Map<IEnumerable<ArtistViewModel>>(await Service.GetAsync(new Filter(searchString, pageNumber, pageSize)));

                if (artists != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, artists);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }

        [Route("{id:guid}")]
        [HttpGet]
        public async Task<HttpResponseMessage> Get(Guid id)
        {
            try
            {
                var artist = await Service.GetByIDAsync(id);

                if (artist != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                        Mapper.Map<ArtistViewModel>(artist));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(ArtistViewModel artistViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "ModelState invalid!");
                }

                var artist = await Service.AddAsync(Mapper.Map<ArtistDomainModel>(artistViewModel));  //problem

                if (artist == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, artistViewModel);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Post failed.");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }
        
        
        [Route("{id:guid}")]
        [HttpPut]
        public async Task<HttpResponseMessage> Put(Guid id, [FromBody]ArtistViewModel artistViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "ModelState invalid!");
                }

                var result = await Service.UpdateAsync(Mapper.Map<ArtistDomainModel>(artistViewModel));

                if (result == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, artistViewModel);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError,
                        "Update failed.");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            try
            {
                if (await Service.DeleteAsync(id) == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Deleted.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }

        #endregion Methods
    }
}
