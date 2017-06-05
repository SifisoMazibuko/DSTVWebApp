using DSTVWebApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSTVWebApp.Controllers
{
    public class MoviesController : Controller
    {
        DataContext context = new DataContext();
        // GET: Movies
        public ActionResult MovieCalendar()
        {
            var mc = (from m in context.Shows
                      where m.Genre == "Movie"
                      select m).ToList();
            ViewBag.movieCalendar = mc;
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}