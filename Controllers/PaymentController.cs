using DSTVWebApp.Context;
using DSTVWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult MyDstv(FormCollection collection,Payment model)
        {
            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                 .ToArray();

            var check = (from u in context.Customers
                       where u.CustomerNumber == model.CustomerNumber || u.SmartCardNumber == model.smartCardNumber
                       select u).ToList();

            if (ModelState.IsValid)
            {
                if (check.Count > 0)
                {
                    ViewBag.Message = "Successfully linked!";
                    return RedirectToAction("MyDstv", "Payment");
                }
                else
                {
                    
                    ViewBag.error = "Customer or smartcard details are incorrect. \n Smartcards already linked to other profile.";
                    return RedirectToAction("MyDstv","Payment");
                }               
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
    }
}