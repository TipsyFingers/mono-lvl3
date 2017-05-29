using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mono_lvl3.DAL.DbContext;
using mono_lvl3.DAL.EntityModels;
using mono_lvl3.Repository.Repositories;
using mono_lvl3.Repository;
using mono_lvl3.Repository.Common;

namespace Mono_lvl3.MVC_WebAPI.Controllers
{
    public class ArtistsController : Controller
    {
        private IGenericRepository<Artist> repository; 

        // GET: Artists
        public ActionResult Index()
        {
            return View(repository.GetAll().ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
