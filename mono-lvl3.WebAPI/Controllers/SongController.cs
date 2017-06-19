using AutoMapper;
using mono_lvl3.Model.Common;
using mono_lvl3.Model.DomainModels;
using mono_lvl3.Service.Common;
using mono_lvl3.WebAPI.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace mono_lvl3.WebAPI.Controllers
{
    public class SongController : Controller
    {
        #region Properites

        protected ISongService Service { get; private set; }
        protected IAlbumService AService { get; private set; }

        #endregion Properties


        #region Constructors

        public SongController(ISongService service, IAlbumService aservice)
        {
            this.Service = service;
            this.AService = aservice;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Gets songs
        /// </summary>
        /// <returns>Songs paged list</returns>
        public async Task<ActionResult> Index(string searchString, int pageNumber = 1, int pageSize = 5)
        {
            var songs = Mapper.Map<IEnumerable<SongViewModel>>(
                await Service.GetAsync(new Common.Filters.Filter(searchString, pageNumber, pageSize)))
                .ToPagedList(pageNumber, pageSize);

            var songPagedList = new StaticPagedList<SongViewModel>(songs, songs.GetMetaData());
            return View(songPagedList);
        }


        /// <summary>
        /// Gets song by ID
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Song</returns>
        public async Task<ActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ISong song = await Service.GetByIDAsync(id);

            if (song == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<SongViewModel>(song));
        }


        /// <summary>
        /// Gets user interface for creating new song
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var albums = Service.GetAlbumsAsync();
            ViewBag.Albums = albums;

            return View();
        }


        /// <summary>
        /// Creates new song
        /// </summary>
        /// <param name="song">The song.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id, Name, Duration, Genre, AlbumId")] SongViewModel song)
        {
            song.Id = Guid.NewGuid();

            if (ModelState.IsValid)
            {
                await Service.AddAsync(Mapper.Map<SongPOCO>(song));
                return RedirectToAction("Index");
            }

            return View();
        }


        /// <summary>
        /// Gets song by ID for editing
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var song = await Service.GetByIDAsync(id);

            if (song == null)
            {
                return HttpNotFound();
            }

            var albums = Service.GetAlbumsAsync();
            ViewBag.Albums = albums;

            return View(Mapper.Map<SongViewModel>(song));
        }


        /// <summary>
        /// Updates the song
        /// </summary>
        /// <param name="song">The song.</param>
        /// <returns>Songs</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id, Name, Duration, Genre, AlbumId")] SongViewModel song)
        {
            if (ModelState.IsValid)
            {
                await Service.UpdateAsync(Mapper.Map<SongPOCO>(song));
                return RedirectToAction("Index");
            }
            return View();
        }


        /// <summary>
        /// Gets song by ID for deleting.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The song.</returns>
        public async Task<ActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ISong song = await Service.GetByIDAsync(id);

            if (song == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<SongViewModel>(song));
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