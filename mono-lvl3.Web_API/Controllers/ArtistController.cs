using mono_lvl3.Service.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using mono_lvl3.Web_API.ViewModels;
using mono_lvl3.Common.Filters;
using mono_lvl3.Model.Common;

namespace mono_lvl3.Web_API.Controllers
{

    [RoutePrefix("api/artist")]
    public class ArtistController : ApiController
    {
        #region Properites

        protected IArtistService Service { get; private set; }

        #endregion Properties


        #region Constructors

        public ArtistController()  {  }

        public ArtistController(IArtistService service)
        {
            this.Service = service;
        }

        #endregion Constructors


        #region Methods
        
        [HttpGet]
        [Route("{pageNumber}/{pageSize}")]
        public async Task<HttpResponseMessage> Get(string searchString = "", int pageNumber = 0, int pageSize = 0)
        {
            try
            {
                var artists = await Service.GetAsync(new Filter(searchString, pageNumber, pageSize));

                if (artists != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                        Mapper.Map<List<ArtistViewModel>>(artists));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            try
            {
                var artist = await Service.GetByIDAsync(id);

                if (artist == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok<IArtist>(artist);
                }
                //if (artist != null)
                //{
                //    return Request.CreateResponse(HttpStatusCode.OK,
                //        Mapper.Map<ArtistViewModel>(artist));
                //}
                //else
                //{
                //    return Request.CreateResponse(HttpStatusCode.NotFound);
                //}
            }
            catch (Exception e)
            {
                throw e;
               // return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }

        #endregion Methods
    }
}
