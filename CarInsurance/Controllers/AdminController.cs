using CarInsurance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsurance.Controllers
{
    public class AdminController : Controller
    {
        public Insuree Insurees { get; private set; }

        // GET: Admin
        public ActionResult Index()
        {
            using (InsuranceEntities db = new InsuranceEntities())
            {
                var insurees = db.Insurees;
                var insureeVms = new List<InsureeVms>();
                foreach (var insuree in insurees)
                {
                    var insureeVm = new InsureeVm();
                    insureeVm.FirstName = insureeVm.FirstName;
                    insureeVm.LastName = insureeVm.LastName;
                    insureeVm.EmailAddress = insureeVm.EmailAddress;
                    insureeVm.Add(insureeVm);
                    db.Insurees.Add(Insurees);
                    db.SaveChanges();
                }

                return View(insureeVms);
            }
        }
    }
}