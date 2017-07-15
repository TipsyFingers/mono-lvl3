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

namespace mono_lvl3.Web_API.Controllers
{

    [RoutePrefix("api/song")]
    public class SongController : ApiController
    {
        #region Properites

        protected ISongService Service { get; private set; }

        #endregion Properties


        #region Constructors

        //public SongController()  {  }

        public SongController(ISongService service)
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
                var songs = await Service.GetAsync(new Filter(searchString, pageNumber, pageSize));

                if (songs != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                        Mapper.Map<List<SongViewModel>>(songs));
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

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<HttpResponseMessage> Get(Guid id)
        {
            try
            {
                var song = await Service.GetByIDAsync(id);

                if (song != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                        Mapper.Map<SongViewModel>(song));
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
        public async Task<HttpResponseMessage> Post(SongViewModel songViewModel)
        {
            try
            {
                var song = await Service.AddAsync(Mapper.Map<SongDomainModel>(songViewModel));

                if (song == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, songViewModel);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError,
                        "Post failed.");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<HttpResponseMessage> Put(Guid id, SongViewModel songViewModel)
        {
            try
            {
                var result = await Service.UpdateAsync(Mapper.Map<SongDomainModel>(songViewModel));
                if (result == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, songViewModel);
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
