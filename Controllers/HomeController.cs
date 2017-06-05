using DSTVWebApp.Context;
using DSTVWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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

            var spotlight = (from d in context.Shows
                             where d.Category == "Spotlight"
                             select d).ToList();
            ViewBag.spotlight = spotlight;

            int userID = Convert.ToInt32(Session["userID"]);
            Profile profile = new DSTVWebApp.Models.Profile();
            var pp = (from p in context.Profiles
                      where p.CustomerID == userID
                      join pd in context.Customers 
                      on p.CustomerID equals pd.CustomerID
                      select p).ToList();
          
            //ViewBag.pp = pp;
            foreach (var item in pp)
            {
                ViewBag.profilePic = item.ProfileImage;
                Session["userID"] = item.CustomerID;
            }

            var mustSee = (from ms in context.Shows
                           where ms.Genre == "Documentary" || ms.Genre == "Drama"
                           select ms).ToList();
            ViewBag.mustSee = mustSee;
           
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
            ViewBag.search = search;
            if (!String.IsNullOrEmpty(searchString))
            {
                search.Where(f => f.ShowName.Contains(searchString)
                || f.ShowDescription.StartsWith(searchString)
                || f.ShowName.StartsWith(searchString)
                || f.ShowDescription.Contains(searchString)
                || f.Category.Contains(searchString)
                || f.Category.StartsWith(searchString));
                return View("Search","Home");
            }            
            else
            {
                return RedirectToAction("SearchView", "Home");
            }
           
        }

        public ActionResult SearchView()
        {
            return View();
        }

        //public ActionResult MovieCalendar()
        //{
        //    var mc = (from m in context.Shows
        //              where m.Genre == "Genre"
        //             select m).ToList();
        //    ViewBag.movieCalendar = mc;
        //    return View();
        //}
        public ActionResult LogOut()
        {
            var response = new HttpStatusCodeResult(HttpStatusCode.Created);
            FormsAuthentication.SignOut();

            Session["admin"] = null;
            Session.Abandon();
            return RedirectToAction("AdminLogin", "Account");
        }
    }
}