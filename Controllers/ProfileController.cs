using DSTVWebApp.Context;
using DSTVWebApp.Models;
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
        public ActionResult Overview(int? id)
        {
            Customer cust = context.Customers.Find(id);
            //var customer = new Customer();

            //var cus = context.Customers.W here(c => c.CustomerID == id).ToList();
            //foreach (var item in cus)
            //{
            //    customer.UserName = item.UserName;
            //    customer.CustomerID = item.CustomerID;
            //    customer.FirstName = item.FirstName;
            //    customer.SurName = item.SurName;
            //    customer.DOB = item.DOB;
            //    customer.Gender = item.Gender;
            //    customer.Country = item.Country;
            //    customer.Province = item.Province;
            //    customer.Phone = item.Phone;
            //    customer.Email = item.Email;
            //    customer.Password = item.Email;  
            //}

            return View(cust);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Overview(Customer model)
        {
            int cusID = Convert.ToInt32(Session["userID"]);
            if (ModelState.IsValid)
            {
                context.Customers.Add(model);
                context.SaveChanges();
                ViewBag.Message = "Successfully Updated";
            }
            return View(model);
        }

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