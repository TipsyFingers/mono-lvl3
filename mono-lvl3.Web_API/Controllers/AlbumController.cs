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

    [RoutePrefix("api/album")]
    public class AlbumController : ApiController
    {
        #region Properites

        protected IAlbumService Service { get; private set; }

        #endregion Properties


        #region Constructors

        //public AlbumController()  {  }

        public AlbumController(IAlbumService service)
        {
            this.Service = service;
        }

        #endregion Constructors


        #region Methods

        [HttpGet]
        [Route("{pageNumber}/{pageSize}")]
        public async Task<HttpResponseMessage> Get(string searchString = "", int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var albums = await Service.GetAsync(new Filter(searchString, pageNumber, pageSize));

                if (albums != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                        Mapper.Map<List<AlbumViewModel>>(albums));
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
                var album = await Service.GetByIDAsync(id);

                if (album != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                        Mapper.Map<AlbumViewModel>(album));
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
        public async Task<HttpResponseMessage> Post(AlbumViewModel albumViewModel)
        {
            try
            {
                var album = await Service.AddAsync(Mapper.Map<AlbumPOCO>(albumViewModel));

                if (album == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, albumViewModel);
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
        public async Task<HttpResponseMessage> Put(Guid id, AlbumViewModel albumViewModel)
        {
            try
            {
                var result = await Service.UpdateAsync(Mapper.Map<AlbumPOCO>(albumViewModel));
                if (result == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, albumViewModel);
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
