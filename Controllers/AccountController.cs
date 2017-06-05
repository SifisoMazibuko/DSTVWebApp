using DSTVWebApp.Context;
using DSTVWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DSTVWebApp.Controllers
{
    public class AccountController : Controller
    {
        DataContext context = new DataContext();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        public bool isValid(string email, string password)
        {
            var cus = (from u in context.Customers
                       where u.Email == email && u.Password == password
                       select u).ToList();
            if (cus.Count > 0)
                return true;
            else
                return false;

        }
        [HttpPost]
        public ActionResult Login(Customer model)
        {
            var errors = ModelState
                  .Where(x => x.Value.Errors.Count > 0)
                  .Select(x => new { x.Key, x.Value.Errors })
                   .ToArray();

            var cus = (from u in context.Customers
                       where u.Email == model.Email && u.Password == model.Password
                       select u).ToList();
            //if (ModelState.IsValid)
            //{
            if (isValid(model.Email,model.Password))
                {
                    foreach (var item in cus)
                    {
                        Session["username"] = item.UserName;
                        Session["userID"] = item.CustomerID;
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Invalid Email/Password";
                    return RedirectToAction("Login", "Account");
                }
               

            //}

            //return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection collection, RegisterFlow model)
        {
            var errors = ModelState
                  .Where(x => x.Value.Errors.Count > 0)
                  .Select(x => new { x.Key, x.Value.Errors })
                   .ToArray();
            
            if (ModelState.IsValid)
            {
                context.RegisterFlows.Add(model);
                context.SaveChanges();
                ViewBag.Message = "Successfully Registered!";
                return RedirectToAction("RegisterCustomer", "Account");
            }
            else
            {
                ViewBag.Message = "Not registered, Try again!";
                return RedirectToAction("Register","Account");
            }

            //return View();
        }

        public ActionResult RegisterCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterCustomer(FormCollection collection, Customer model)
        {
            var errors = ModelState
                  .Where(x => x.Value.Errors.Count > 0)
                  .Select(x => new { x.Key, x.Value.Errors })
                   .ToArray();
            
            if (ModelState.IsValid)
            {
                context.Customers.Add(model);
                context.SaveChanges();
                
                MailMessage message = new MailMessage();
                message.From = new System.Net.Mail.MailAddress("mazibujo19@gmail.com");
                message.To.Add(new System.Net.Mail.MailAddress(model.Email));
                message.Subject = "WELCOME TO DSTV!!";
                message.Body = string.Format("Welcome {0} ,<br /><br />Enjoy the best Entertainment money can buy!! :) <br />Your password is: {1} .<br /><br />Thank You. <br /> <br /> Best Regards, <br />  DSTV <br/><img src=cid:DSLogo.PNG/>", model.FirstName, model.Password);
                message.IsBodyHtml = true;
                // SmtpClient smtp = new SmtpClient();
                // smtp.Host = "smtp.gmail.com";
                // smtp.EnableSsl = true;
                //NetworkCredential NetworkCred = new NetworkCredential();
                //  smtp.UseDefaultCredentials = true;
                //smtp.Credentials = NetworkCred;
                //smtp.Port = 587;
                
                //add our attachment
                Attachment imgAtt = new Attachment(Server.MapPath(@"/Images/DSLogo.PNG"));
                //give it a content id that corresponds to the src we added in the body img tag
                imgAtt.ContentId = "DSLogo.PNG";
                //add the attachment to the email
                message.Attachments.Add(imgAtt);

                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                client.Send(message);

                ViewBag.Message = "Successfully Registered!";
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
        public ActionResult Logout()
        {
            var response = new HttpStatusCodeResult(HttpStatusCode.Created);
            FormsAuthentication.SignOut();

            Session["username"] = null;
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
       

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ForgotPassword(Customer model)
        {
            var pd = (from e in context.Customers
                      where e.Email == model.Email
                      select e).ToList();
            string pass = "";
            string name = "";
            foreach (var item in pd)
            {
                pass = item.Password;
                name = item.FirstName;
            }

            if(model.Email == null)
            {
                ViewBag.Message = "";
            }
            else
            {
                MailMessage message = new MailMessage();
                message.From = new System.Net.Mail.MailAddress("mazibujo19@gmail.com");
                message.To.Add(new System.Net.Mail.MailAddress(model.Email));
                message.Subject = "WELCOME TO DSTV!!";
                message.Body = string.Format("Hi " + name + ",<br /><br />Your password is: " + pass + "<br /><br />Thank You. <br /> Regards, <br /> DSTV  <img src=cid:DSLogo.PNG/>");
                message.IsBodyHtml = true;
                Attachment imgAtt = new Attachment(Server.MapPath(@"/Images/DSLogo.PNG"));
                imgAtt.ContentId = "DSLogo.PNG";
                message.Attachments.Add(imgAtt);

                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                client.Send(message);
                ViewBag.Message = "Password sent to your email!";
                model.Email = string.Empty;
                model.Email = "";
            }
            

            return View();
        }


        public bool islogValid(string username, string password)
        {
            var cus = (from a in context.Admins
                       where a.userName == username && a.password == password 
                       select a).ToList();
            if (cus.Count > 0)
                return true;
            else
                return false;

        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View("AdminLogin");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin(Admin model)
        {
            var log = (from a in context.Admins
                      where a.userName == model.userName && a.password ==  model.password
                      select a).ToList();
            if (islogValid(model.userName, model.password))
            {
                foreach (var item in log)
                {
                    Session["admin"] = item.FirstName;
                }
                ViewBag.Message = "Successfully logged in!";
                return RedirectToAction("Index", "Shows");
            }
            else
            {
                ViewBag.Message = "Incorrect details, Please Try again!";
                return RedirectToAction("AdminLogin", "Account");
            }
           // return View();
        }
        [HttpGet]
        public ActionResult AdminRegister()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminRegister(FormCollection collection, Admin model)
        {
            if (ModelState.IsValid)
            {
                context.Admins.Add(model);
                context.SaveChanges();
                ViewBag.Message = "Successfully Registered!";
                return RedirectToAction("AdminLogin", "Account");
            }
            return View();
        }
        //public ActionResult LogOut()
        //{
        //    var response = new HttpStatusCodeResult(HttpStatusCode.Created);
        //    FormsAuthentication.SignOut();

        //    Session["admin"] = null;
        //    Session.Abandon();
        //    return RedirectToAction("AdminLogin", "Account");
        //}
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