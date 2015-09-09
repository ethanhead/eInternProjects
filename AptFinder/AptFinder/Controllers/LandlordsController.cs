using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AptFinder.DAL;
using AptFinder.Models;

namespace AptFinder.Controllers
{
    public class LandlordsController : Controller
    {
        private ApartmentContext db = new ApartmentContext();

        // GET: Landlords
        public ActionResult Index()
        {
            return View(db.Landlord.ToList());
        }

        // GET: Landlords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Landlord landlord = db.Landlord.Find(id);
            if (landlord == null)
            {
                return HttpNotFound();
            }
            return View(landlord);
        }

        // GET: Landlords/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Landlords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LandlordID,Name,Company,Phone,Email")] Landlord landlord)
        {
            if (ModelState.IsValid)
            {
                db.Landlord.Add(landlord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(landlord);
        }

        // GET: Landlords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Landlord landlord = db.Landlord.Find(id);
            if (landlord == null)
            {
                return HttpNotFound();
            }
            return View(landlord);
        }

        // POST: Landlords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LandlordID,Name,Company,Phone,Email")] Landlord landlord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(landlord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(landlord);
        }

        // GET: Landlords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Landlord landlord = db.Landlord.Find(id);
            if (landlord == null)
            {
                return HttpNotFound();
            }
            return View(landlord);
        }

        // POST: Landlords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Landlord landlord = db.Landlord.Find(id);
            db.Landlord.Remove(landlord);
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
