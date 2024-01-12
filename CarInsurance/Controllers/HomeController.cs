using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{
    public class HomeController : Controller
    {
        private object db;

        public Insuree Insurees { get; private set; }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insuree(string firstName,
            string lastName,
            string emailAddress)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
                using (InsuranceEntities db = new InsuranceEntities())
                {
                    var insuree = new Insuree();
                    insuree.FirstName = firstName;
                    insuree.LastName = lastName;
                    insuree.EmailAddress = emailAddress;

                    db.Insurees.Add(insuree);
                    db.SaveChanges();
                }

                     return View("Success");
        }   
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Admin()
        {

            return View();
        }

        public ActionResult Contact()
        {
            object ViewBag = new object();
            ViewBag = "Your contact page.";

            return View();
        }
    }
}