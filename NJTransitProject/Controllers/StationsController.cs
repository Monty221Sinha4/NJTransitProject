using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NJTransitProject;

namespace NJTransitProject.Controllers
{
    public class StationsController : Controller
    {
        private NJData1 db = new NJData1();

        // GET: Stations
        public ActionResult Index()
        {
            return View(db.Stations1.ToList());
        }

        // GET: Stations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stations stations = db.Stations1.Find(id);
            if (stations == null)
            {
                return HttpNotFound();
            }
            return View(stations);
        }

        // GET: Stations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StationID,Station")] Stations stations)
        {
            if (ModelState.IsValid)
            {
                db.Stations1.Add(stations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stations);
        }

        // GET: Stations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stations stations = db.Stations1.Find(id);
            if (stations == null)
            {
                return HttpNotFound();
            }
            return View(stations);
        }

        // POST: Stations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StationID,Station")] Stations stations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stations);
        }

        // GET: Stations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stations stations = db.Stations1.Find(id);
            if (stations == null)
            {
                return HttpNotFound();
            }
            return View(stations);
        }

        // POST: Stations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stations stations = db.Stations1.Find(id);
            db.Stations1.Remove(stations);
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
