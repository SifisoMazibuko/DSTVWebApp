using DSTVWebApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DSTVWebApp.Models;
using System.Web.Mvc;

namespace DSTVWebApp.Controllers
{
    public class SelfServiceController : Controller
    {
        DataContext context = new DataContext();
        // GET: SelfService
        public ActionResult SelfService()
        {
            return View();
        }
        
        public ActionResult Fix()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Fix(FixEnquire model)
        {
            if (ModelState.IsValid)
            {
                context.FixEnquires.Add(model);
                context.SaveChanges();
                ViewBag.Message = "Well get the Error Fixed!!";
            }
            
            return View();
        }
        public ActionResult MakePayment(int? id)
         {
            int usd = Convert.ToInt32(Session["userID"]);
            var check = (from s in context.Customers
                         where s.CustomerID == usd
                         select s).ToList();

           
            foreach(var item in check)
            {
                //id = item.CustomerID;               
                ViewBag.email = item.Email;
                ViewBag.cusNumber = item.CustomerNumber;
                ViewBag.phone = item.Phone;

            }
            //Customer customer = context.Customers.Find(id);
            return View();
        }
        [HttpPost]
        public ActionResult MakePayment(Billing model, string CustomerNumber, string Email, string Phone, string Amount)
        {
            int usd = Convert.ToInt32(Session["userID"]);
            var pay = (from p in context.Billings
                       where p.BillingID == usd
                       join pb in context.Customers
                       on p.CustomerNumber equals pb.CustomerID
                       select p).ToList();

            model.Phone = Phone;
            model.Email = Email;
            model.CustomerNumber = Convert.ToInt32(CustomerNumber);
            model.Amount = Convert.ToDouble(Amount);

            foreach (var item in pay)
            {
                Session["userID"] = item.BillingID;
            }

            if (ModelState.IsValid)
            {
                context.Billings.Add(model);
                context.SaveChanges();
            }
            

            return View();
        }
    }
}