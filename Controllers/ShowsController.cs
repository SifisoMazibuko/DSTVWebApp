using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DSTVWebApp.Context;
using DSTVWebApp.Models;

namespace DSTVWebApp.Controllers
{
    public class ShowsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Shows
        public ActionResult Index()
        {
            var shows = db.Shows.Include(s => s.Admin).Include(s => s.Customer);
            return View(shows.ToList());
        }

        // GET: Shows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        // GET: Shows/Create
        public ActionResult Create()
        {
            ViewBag.AdminID = new SelectList(db.Admins, "adminID", "userName");
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "UserName");
            ViewBag.Genre = new SelectList(db.Shows, "", "");
            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection, Show show, HttpPostedFileBase loadImage)
        {
            if (loadImage != null)
            {
                show.ShowImage = new byte[loadImage.ContentLength];
                loadImage.InputStream.Read(show.ShowImage, 0, loadImage.ContentLength);
            }

            if (ModelState.IsValid)
            {
                
                db.Shows.Add(show);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.AdminID = new SelectList(db.Admins, "adminID", "userName", show.AdminID);
            //ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "UserName", show.CustomerID);
            ViewBag.Genre = new SelectList(db.Shows, "", "", show.Genre);
            return View(show);
        }

        // GET: Shows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            //ViewBag.AdminID = new SelectList(db.Admins, "adminID", "userName", show.AdminID);
            //ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "UserName", show.CustomerID);
            return View(show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShowID,AdminID,CustomerID,ShowImage,ShowName,ShowDescription,Category,StartDate,EndDate,Genre,Duration,Channel,AgeRestriction")] Show show)
        {
            if (ModelState.IsValid)
            {
                db.Entry(show).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.AdminID = new SelectList(db.Admins, "adminID", "userName", show.AdminID);
            //ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "UserName", show.CustomerID);
            return View(show);
        }

        // GET: Shows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Show show = db.Shows.Find(id);
            db.Shows.Remove(show);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
