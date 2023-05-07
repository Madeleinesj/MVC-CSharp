using MVC465.Models;
using MVC465.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC465.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (NewsletterEntities db = new NewsletterEntities())
            {
                //var signups = db.Signups.Where(x => x.Removed == null).ToList(); This line works of the next one down. 
                var signups = (from c in db.Signups
                               where c.Removed == null
                               select c).ToList();
                var signupVMs = new List<SignupVM>();
                foreach (var signup in signups)
                {

                    var signupVM = new SignupVM();
                    signupVM.Id = signup.Id;
                    signupVM.FirstName = signup.FirstName;
                    signupVM.LastName = signup.LastName;
                    signupVM.EmailAddress = signup.EmailAddress;
                    signupVMs.Add(signupVM);

                }
                return View(signupVMs);
            }
           
        }

        public ActionResult Unsubscribe(int Id)
        {
            using (NewsletterEntities db = new NewsletterEntities())
            {
                var signup = db.Signups.Find(Id);
                signup.Removed = DateTime.Now;
                db.SaveChanges();

            }

            return RedirectToAction("Index");
        }
        }

}