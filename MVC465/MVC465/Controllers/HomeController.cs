using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC465.Models;
using MVC465.ViewModel;

namespace MVC465.Controllers
{
    public class HomeController : Controller
    {
        public int NewsletterSignup { get; private set; }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(string firstName, string lastName, string emailAddress)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (NewsletterEntities db = new NewsletterEntities())
                {
                    var signup = new Signup();
                    signup.FirstName = firstName;
                    signup.LastName = lastName;
                    signup.EmailAddress = emailAddress;

                    db.Signups.Add(signup);
                    db.SaveChanges();
                }
                return View("Success");
            }   
        }
    }
}