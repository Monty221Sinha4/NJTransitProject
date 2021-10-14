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
    public class StationPlatformsController : Controller
    {
        private NJData1 db = new NJData1();

        // GET: StationPlatforms
        public ActionResult Index()
        {
            return View(db.StationPlatforms.ToList());
        }

        // GET: StationPlatforms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationPlatform stationPlatform = db.StationPlatforms.Find(id);
            if (stationPlatform == null)
            {
                return HttpNotFound();
            }
            return View(stationPlatform);
        }

        // GET: StationPlatforms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StationPlatforms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlatformID,Platform")] StationPlatform stationPlatform)
        {
            if (ModelState.IsValid)
            {
                db.StationPlatforms.Add(stationPlatform);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stationPlatform);
        }

        // GET: StationPlatforms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationPlatform stationPlatform = db.StationPlatforms.Find(id);
            if (stationPlatform == null)
            {
                return HttpNotFound();
            }
            return View(stationPlatform);
        }

        // POST: StationPlatforms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlatformID,Platform")] StationPlatform stationPlatform)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stationPlatform).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stationPlatform);
        }

        // GET: StationPlatforms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StationPlatform stationPlatform = db.StationPlatforms.Find(id);
            if (stationPlatform == null)
            {
                return HttpNotFound();
            }
            return View(stationPlatform);
        }

        // POST: StationPlatforms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StationPlatform stationPlatform = db.StationPlatforms.Find(id);
            db.StationPlatforms.Remove(stationPlatform);
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
