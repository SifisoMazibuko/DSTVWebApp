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
    public class RewardsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Rewards
        public ActionResult Index()
        {
           
            var rewards = (from r in db.Rewards
                           select r).ToList();
            ViewBag.rewards = rewards;
            foreach (var item in rewards)
            {
                Session["RewardsCount"] = rewards.Count;
            }
            return View();
        }
        public ActionResult Rewards()
        {
            var rewards = (from r in db.Rewards
                           select r).ToList();

            //ViewBag.rewards = rewards;
            return View(rewards);
        }

        public ActionResult Rewards2()
        {
            var rewards = (from r in db.Rewards
                           select r).ToList();

            var rw = new Rewards();

            foreach (var r in rewards)
            {
                rw.RewardsID = r.RewardsID;
                rw.RewardName = r.RewardName;
                rw.Image = r.Image;
                rw.Description = r.Description;
                rw.ClosingDate = r.ClosingDate;

            }
            //Rewards rw = new Rewards();
            ViewBag.rw = rw;
           
            return View(rw);
            
        }

        // GET: Rewards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rewards rewards = db.Rewards.Find(id);
            if (rewards == null)
            {
                return HttpNotFound();
            }
            return View(rewards);
        }

        // GET: Rewards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rewards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RewardsID,RewardName,Description,Image,ClosingDate")] Rewards rewards, HttpPostedFileBase loadImage)
        {
            if (loadImage != null)
            {
                rewards.Image = new byte[loadImage.ContentLength];
                loadImage.InputStream.Read(rewards.Image, 0, loadImage.ContentLength);
            }
            if (ModelState.IsValid)
            {
                db.Rewards.Add(rewards);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rewards);
        }

        // GET: Rewards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rewards rewards = db.Rewards.Find(id);
            if (rewards == null)
            {
                return HttpNotFound();
            }
            return View(rewards);
        }

        // POST: Rewards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RewardsID,RewardName,Description,Image,ClosingDate")] Rewards rewards, HttpPostedFileBase loadImage)
        {
            if (loadImage != null)
            {
                rewards.Image = new byte[loadImage.ContentLength];
                loadImage.InputStream.Read(rewards.Image, 0, loadImage.ContentLength);
            }
            if (ModelState.IsValid)
            {
                db.Entry(rewards).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rewards);
        }

        // GET: Rewards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rewards rewards = db.Rewards.Find(id);
            if (rewards == null)
            {
                return HttpNotFound();
            }
            return View(rewards);
        }

        // POST: Rewards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rewards rewards = db.Rewards.Find(id);
            db.Rewards.Remove(rewards);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Rewards/MoreDetails/
        //public ActionResult MoreDetails(string searchString)
         public ActionResult MoreDetails(string searchString, int Id)
        {

            DataContext  us = new DataContext();
            //#region MyRegion
            //if (searchString == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //var reward = (from rew in db.Rewards
            //              where rew.RewardName == searchString
            //              select rew).ToList();
            //#endregion

            //Rewards rw = new Rewards();

            //foreach(var r in reward){
            //    rw.RewardsID = r.RewardsID;
            //    rw.RewardName = r.RewardName;
            //    rw.Image = r.Image;
            //    rw.Description = r.Description;
            //    rw.ClosingDate = r.ClosingDate;

            //}
          
            Rewards ns = us.Rewards.Find(Id);

            var related = (from r in db.Rewards
                           where r.RewardsID == Id
                           select r).ToList();

            ViewBag.related = related; 
                   
            return View(ns);
         }

        public ActionResult RewardDetails(string searchString)
        {
            Rewards rw = new Rewards();

            //Models.Rewards reward =  new Models.Rewards(id);
            ////if (id > 0)
            ////{
                var rewards = (from rew in db.Rewards
                              where rew.RewardName == searchString
                               select rew).ToList();



               foreach (var r in rewards)
                {
                    rw.RewardsID = r.RewardsID;
                    rw.RewardName = r.RewardName;
                    rw.Image = r.Image;
                    rw.Description = r.Description;
                    rw.ClosingDate = r.ClosingDate;

                }

            ////}

            
            return View(rw);
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
