using DSTVWebApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSTVWebApp.Controllers
{
    public class SeriesController : Controller
    {
        DataContext context = new DataContext();
        // GET: Series
        public ActionResult SeriesCalendar()
        {
            var scd = (from sc in context.Shows
                     where sc.Genre == "Series"
                     select sc).ToList();
            ViewBag.seriesCalendar = scd;
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