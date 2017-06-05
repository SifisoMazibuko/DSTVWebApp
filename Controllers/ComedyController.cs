using DSTVWebApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSTVWebApp.Controllers
{
    public class ComedyController : Controller
    {
        DataContext context = new DataContext();
        // GET: Comedy
        public ActionResult ComedyCalendar()
        {
            var cc = from c in context.Shows
                     where c.Genre == "Comedy"
                     select c;
            ViewBag.comedyCalendar = cc;
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