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
    public class ArtistController : Controller
    {
        #region Properites

        protected IArtistService Service { get; private set; }

        #endregion Properties


        #region Constructors

        public ArtistController(IArtistService service)
        {
            this.Service = service;
        }

        #endregion Constructors


        #region Methods

        /// <summary>
        /// Gets artists
        /// </summary>
        /// <returns>Artists paged list</returns>
        public async Task<ActionResult> Index(string searchString, int pageNumber = 1, int pageSize = 10)
        {
            var artists = Mapper.Map<IEnumerable<ArtistViewModel>>(
                await Service.GetAsync(new Common.Filters.Filter(searchString, pageNumber, pageSize)))
                .ToPagedList(pageNumber, pageSize);

            var artistPagedList = new StaticPagedList<ArtistViewModel>(artists, artists.GetMetaData());
            return View(artistPagedList);
        }


        /// <summary>
        /// Gets artist by ID
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Artist</returns>
        public async Task<ActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IArtist artist = await Service.GetByIDAsync(id);

            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<ArtistViewModel>(artist));
        }


        /// <summary>
        /// Gets user interface for creating new artist
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }


        /// <summary>
        /// Creates new artist
        /// </summary>
        /// <param name="artist">The artist.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id, ArtistName, FName, LName, From")] ArtistViewModel artist)
        {
            artist.Id = Guid.NewGuid();

            if (ModelState.IsValid)
            {
                await Service.AddAsync(Mapper.Map<ArtistPOCO>(artist));
                return RedirectToAction("Index");
            }

            return View();
        }


        /// <summary>
        /// Gets artist by ID for editing
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var artist = await Service.GetByIDAsync(id);

            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<ArtistViewModel>(artist));
        }


        /// <summary>
        /// Updates the artist
        /// </summary>
        /// <param name="artist">The artist.</param>
        /// <returns>Artists</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id, ArtistName, FName, LName, From")] ArtistViewModel artist)
        {
            if (ModelState.IsValid)
            {
                await Service.UpdateAsync(Mapper.Map<ArtistPOCO>(artist));
                return RedirectToAction("Index");
            }
            return View();
        }


        /// <summary>
        /// Gets artist by ID for deleting.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The artist.</returns>
        public async Task<ActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IArtist artist = await Service.GetByIDAsync(id);

            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<ArtistViewModel>(artist));
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