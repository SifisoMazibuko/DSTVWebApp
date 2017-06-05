using DSTVWebApp.Context;
using DSTVWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DSTVWebApp.Controllers
{
    public class PaymentController : Controller
    {
        DataContext context = new DataContext();
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyDstv()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MyDstv(FormCollection collection,Payment model, Profile pic, HttpPostedFileBase Uploadfile)
        {
            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                 .ToArray();
            try
            {
                //start
                Profile profile = new Profile();
                string image = collection["preview"];

                if (Uploadfile != null)
                {
                    profile.ProfileImage = new byte[Uploadfile.ContentLength];
                    Uploadfile.InputStream.Read(profile.ProfileImage, 0, Uploadfile.ContentLength);
                }
                profile.CustomerID = Convert.ToInt32(Session["userID"]);
                context.Profiles.Add(profile);
                context.SaveChanges();

                int usd = Convert.ToInt32(Session["useID"]);

                var check = (from u in context.Customers
                             where u.CustomerNumber == model.CustomerNumber && u.Payment_paymentID == usd
                             select u).ToList();

                if (check != null)
                {
                    context.Payments.Add(model);
                    context.SaveChanges();
                    ViewBag.Message = "Successfully linked!";
                    return RedirectToAction("CustomerInformation", "Payment");
                }
                else
                {
                    ViewBag.Message = "Customer or smartcard details are incorrect. \n Smartcards already linked to other profile.";
                    return RedirectToAction("MyDstv", "Payment");
                }
            }
            catch (Exception)
            {
                
            }
            return View();
         }

        [HttpGet]
        public ActionResult Customer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Customer(FormCollection collection,dsCustomer model)
        {
            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                 .ToArray();

            if (ModelState.IsValid)
            {
                dsCustomer pay = new dsCustomer();
                pay.CustomerNumber = model.CustomerNumber;
                pay.accountHolderSurname = model.accountHolderSurname;
                pay.accountHolderCountry = model.accountHolderCountry;

                context.dsCustomers.Add(model);
                context.SaveChanges();
            }
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

        [HttpPost]
        public ActionResult CustomerInformation()
        {
            int usd = Convert.ToInt32(Session["userID"]);
            return View();
        }
        [HttpGet]
        public ActionResult CustomerInformation(Customer model)
        {
            int usd = Convert.ToInt32(Session["userID"]);

            var cus = (from c in context.Customers
                       where c.CustomerID == usd
                       select c).ToList();
            foreach (var item in cus)
            {
                ViewBag.FirstName = item.FirstName;
                ViewBag.SurName = item.SurName;
                ViewBag.CustomerNumber = item.CustomerNumber;
                ViewBag.Balance = item.Balance;
            }
            return View();
        }

        public void SaveImage(HttpPostedFileBase Uploadfile, FormCollection fc)
        {
            Profile profile = new Profile();
            string image = fc["preview"];           

            if (Uploadfile != null)
            {

                profile.ProfileImage = new byte[Uploadfile.ContentLength];
                Uploadfile.InputStream.Read(profile.ProfileImage, 0, Uploadfile.ContentLength);

            }
            profile.CustomerID = Convert.ToInt32(Session["userID"]);

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(image))
                {
                    context.Profiles.Add(profile);
                    context.SaveChanges();
                }
                    
            }


        }

        
       
    }
}