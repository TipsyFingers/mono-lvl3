using AutoMapper;
using mono_lvl3.Model.Common;
using mono_lvl3.Model.DomainModels;
using mono_lvl3.Service.Common;
using mono_lvl3.WebMVC.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace mono_lvl3.WebMVC.Controllers
{
    public class AlbumController : Controller
    {
        #region Properites

        protected IAlbumService Service { get; private set; }

        #endregion Properties


        #region Constructors

        public AlbumController(IAlbumService service)
        {
            this.Service = service;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Gets albums
        /// </summary>
        /// <returns>Albums paged list</returns>
        public async Task<ActionResult> Index(string searchString, int pageNumber = 1, int pageSize = 10)
        {
            var albums = Mapper.Map<IEnumerable<AlbumViewModel>>(
                await Service.GetAsync(new Common.Filters.Filter(searchString, pageNumber, pageSize)))
                .ToPagedList(pageNumber, pageSize);

            var albumPagedList = new StaticPagedList<AlbumViewModel>(albums, albums.GetMetaData());
            return View(albumPagedList);
        }


        /// <summary>
        /// Gets album by ID
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Album</returns>
        public async Task<ActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IAlbum album = await Service.GetByIDAsync(id);

            if (album == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<AlbumViewModel>(album));
        }


        /// <summary>
        /// Gets user interface for creating new album
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }


        /// <summary>
        /// Creates new album
        /// </summary>
        /// <param name="album">The album.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id, Name, Genre, Price")] AlbumViewModel album)
        {
            album.Id = Guid.NewGuid();
            
            if (ModelState.IsValid)
            {
                await Service.AddAsync(Mapper.Map<AlbumPOCO>(album));
                return RedirectToAction("Index");
            }

            return View();
        }


        /// <summary>
        /// Gets album by ID for editing
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var album = await Service.GetByIDAsync(id);

            if (album == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<AlbumViewModel>(album));
        }


        /// <summary>
        /// Updates the album
        /// </summary>
        /// <param name="album">The album.</param>
        /// <returns>Albums</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id, Name, Genre, Price")] AlbumViewModel album)
        {
            if (ModelState.IsValid)
            {
                await Service.UpdateAsync(Mapper.Map<AlbumPOCO>(album));
                return RedirectToAction("Index");
            }
            return View();
        }


        /// <summary>
        /// Gets album by ID for deleting.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The album.</returns>
        public async Task<ActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IAlbum album = await Service.GetByIDAsync(id);

            if (album == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<AlbumViewModel>(album));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            await Service.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        #endregion Methods
    }
}
