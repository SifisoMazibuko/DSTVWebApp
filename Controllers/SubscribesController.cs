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
    public class SubscribesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Subscribes
        public ActionResult Index()
        {
            var subscriber = (from sub in db.Subscribes
                              select sub).ToList();
            foreach (var item in subscriber)
            {
                Session["subscribersCount"] = subscriber.Count;
            }
            return View(subscriber.ToList());
        }

        // GET: Subscribes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscribe subscribe = db.Subscribes.Find(id);
            if (subscribe == null)
            {
                return HttpNotFound();
            }
            return View(subscribe);
        }

        // GET: Subscribes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subscribes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubscribeID,Email")] Subscribe subscribe)
        {
            if (ModelState.IsValid)
            {
                db.Subscribes.Add(subscribe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subscribe);
        }

        // GET: Subscribes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscribe subscribe = db.Subscribes.Find(id);
            if (subscribe == null)
            {
                return HttpNotFound();
            }
            return View(subscribe);
        }

        // POST: Subscribes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubscribeID,Email")] Subscribe subscribe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscribe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subscribe);
        }

        // GET: Subscribes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscribe subscribe = db.Subscribes.Find(id);
            if (subscribe == null)
            {
                return HttpNotFound();
            }
            return View(subscribe);
        }

        // POST: Subscribes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Subscribe subscribe = db.Subscribes.Find(id);
                db.Subscribes.Remove(subscribe);
                db.SaveChanges();
               
            }
            catch (Exception)
            {

            }
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
