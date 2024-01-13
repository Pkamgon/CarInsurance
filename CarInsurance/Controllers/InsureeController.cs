using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();
        private string carModel;
        private int carYear;
        private int speedingTickets;
        private string carMake;
        private bool isFullCoverage;
        private bool hasDUI;
        private int now;

        public object Insurees { get; private set; }

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

         //GET: Insuree/Create
        public ActionResult Create(string firstName, string lastName, string emailAddress)
        {
            return View();
        }


        // POST: Insuree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            //Quote based on quidelines
            decimal baseQuote = 50;

            //Age logic
            db.Insurees.Add(insuree);

            Insuree.DateOfBirth.Value.Year.
            var age = now - insuree.DateOfBirth.Value.Year.

            age.basequote = age;
            if (age <= 18)
                baseQuote += 100;

            else if (age >= 19 && age <= 25)
                baseQuote += 25;

            //Car year logic


            if (carYear < 2000)
                baseQuote += 25;
            else if (age >= 19 && age <= 25)
                baseQuote += 50;

            //Car make and model loig

            if (carMake == "Porche")

            {
                baseQuote += 25;

                if (carModel == "911 Carrera")
                    baseQuote += 25;
            }

            //Speeding tickets logic
            baseQuote += 10 * speedingTickets;

            //DUI logic

            if (hasDUI)
                baseQuote *= 1.25m; //25% increase

            //Full Coverage logic

            if (isFullCoverage)
                baseQuote *= 1.5m; //50% increase

            //Save Quote
            db.SaveChanges();


            return View();
              
            if (ModelState.IsValid)
            {
                db.Insurees.Add(insuree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insuree);
        }

                // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
            {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insuree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insuree insuree = db.Insurees.Find(id);
            db.Insurees.Remove(insuree);
            db.SaveChanges();
            return RedirectToAction("Index");
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
