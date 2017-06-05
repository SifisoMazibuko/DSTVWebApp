using DSTVWebApp.Context;
using DSTVWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSTVWebApp.Controllers
{
    public class SupportController : Controller
    {
        DataContext context = new DataContext();
        // GET: Support
        public ActionResult Support()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SupportQuery()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SupportQuery(FormCollection collection, SupportQuery model)
        {
            if (ModelState.IsValid)
            {
                context.SupportQuerys.Add(model);
                context.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = "Query sent successfully!! Will get back to you soon!!"; 
            }
            return View();
        }
    }
}