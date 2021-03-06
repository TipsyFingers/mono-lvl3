﻿using System;
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
        //[Route("{pageNumber}/{pageSize}")]
        public async Task<HttpResponseMessage> Get(string searchString = "", int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var albums = Mapper.Map<IEnumerable<AlbumViewModel>>(await Service.GetAsync(new Filter(searchString, pageNumber, pageSize)));

                if (albums != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, albums);
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
        public async Task<HttpResponseMessage> Post([FromBody]AlbumViewModel albumViewModel)
        {
            try
            {
                if (!ModelState.IsValid || albumViewModel == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "ModelState invalid!");
                }

                var album = await Service.AddAsync(Mapper.Map<AlbumDomainModel>(albumViewModel));

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

        // add artists to album
        [HttpPost]
        [Route("{id:guid}")]
        public async Task<HttpResponseMessage> Post(Guid id, [FromBody]IEnumerable<Guid> artistIds)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "ModelState invalid!");
                }

                var album = await Service.GetByIDAsync(id);

                if (album != null)
                {
                    await Service.AddArtistsToAlbumAsync(id, artistIds);
                    album = await Service.GetByIDAsync(id);
                    return Request.CreateResponse(HttpStatusCode.OK, album);
                }

                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Post failed.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString());
            }
        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<HttpResponseMessage> Put(Guid id, [FromBody]AlbumViewModel albumViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "ModelState invalid!");
                }
                var result = await Service.UpdateAsync(Mapper.Map<AlbumDomainModel>(albumViewModel));

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
