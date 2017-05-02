using DSTVWebApp.Context;
using DSTVWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DSTVWebApp.Controllers
{
    public class HomeController : Controller
    {
        DataContext context = new DataContext();
        public ActionResult Index()
        {
            var catchUp = (from d in context.Shows
                           where d.Category == "CatchUp"
                          select d).ToList();
            ViewBag.catchUp = catchUp;

            var boxOffice = (from d in context.Shows
                           where d.Category == "BoxOffice"
                             select d).ToList();
            ViewBag.boxOffice = boxOffice;

            var tv = (from d in context.Shows
                           where d.Category == "TV"
                           select d).ToList();
            ViewBag.tv = tv;

            var sportlight = (from d in context.Shows
                             where d.Category == "Sportlight"
                             select d).ToList();
            ViewBag.sportlight = sportlight;                   
            

            return View();
        }
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Show show = context.Shows.Find(id);
            var show = (from s in context.Shows
                       where s.ShowName == id
                       select s).FirstOrDefault();

            //var sho = context.Shows.Where(s => s.ShowName == id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }
        public ActionResult Search(string searchString)
        {
            var search = (from sc in context.Shows
                          where sc.ShowName == searchString 
                          || sc.ShowDescription == searchString
                          || sc.Category == searchString
                          select sc).ToList();
            Session["search"] = search;
            if (!String.IsNullOrEmpty(searchString) || !String.IsNullOrWhiteSpace(searchString))
            {
                search.Where(f => f.ShowName.Contains(searchString)
                || f.ShowDescription.StartsWith(searchString)
                || f.ShowName.StartsWith(searchString)
                || f.ShowDescription.Contains(searchString)
                || f.Category.Contains(searchString)
                || f.Category.StartsWith(searchString));
                           
                return View(search);
            }
            
            else
            {
                return RedirectToRoute("SearchView", "Home");
            }
        }

       
    }
}