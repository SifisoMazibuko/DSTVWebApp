using DSTVWebApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSTVWebApp.Controllers
{
    public class ProfileController : Controller
    {
        DataContext context = new DataContext();
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Overview()
        {
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Overview()
        //{
        //    return View();
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SmartCart()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Newsletters()
        {
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