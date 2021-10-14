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
    public class TrainTimeTablesController : Controller
    {
        private NJData1 db = new NJData1();

        // GET: TrainTimeTables
        public ActionResult Index()
        {
            var trainTimeTables = db.TrainTimeTables.Include(t => t.City).Include(t => t.StationPlatform).Include(t => t.Station).Include(t => t.Status);
            return View(trainTimeTables.ToList());
        }

        // GET: TrainTimeTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainTimeTable trainTimeTable = db.TrainTimeTables.Find(id);
            if (trainTimeTable == null)
            {
                return HttpNotFound();
            }
            return View(trainTimeTable);
        }

        // GET: TrainTimeTables/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.Cities1, "CityID", "City");
            ViewBag.PlatformID = new SelectList(db.StationPlatforms, "PlatformID", "Platform");
            ViewBag.StationID = new SelectList(db.Stations1, "StationID", "Station");
            ViewBag.StatusID = new SelectList(db.StatusTables, "StatusID", "Status");
            return View();
        }

        // POST: TrainTimeTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GenID,StationID,SchuduleTime,CityID,PlatformID,StatusID")] TrainTimeTable trainTimeTable)
        {
            if (ModelState.IsValid)
            {
                db.TrainTimeTables.Add(trainTimeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.Cities1, "CityID", "City", trainTimeTable.CityID);
            ViewBag.PlatformID = new SelectList(db.StationPlatforms, "PlatformID", "Platform", trainTimeTable.PlatformID);
            ViewBag.StationID = new SelectList(db.Stations1, "StationID", "Station", trainTimeTable.StationID);
            ViewBag.StatusID = new SelectList(db.StatusTables, "StatusID", "Status", trainTimeTable.StatusID);
            return View(trainTimeTable);
        }

        // GET: TrainTimeTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainTimeTable trainTimeTable = db.TrainTimeTables.Find(id);
            if (trainTimeTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Cities1, "CityID", "City", trainTimeTable.CityID);
            ViewBag.PlatformID = new SelectList(db.StationPlatforms, "PlatformID", "Platform", trainTimeTable.PlatformID);
            ViewBag.StationID = new SelectList(db.Stations1, "StationID", "Station", trainTimeTable.StationID);
            ViewBag.StatusID = new SelectList(db.StatusTables, "StatusID", "Status", trainTimeTable.StatusID);
            return View(trainTimeTable);
        }

        // POST: TrainTimeTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GenID,StationID,SchuduleTime,CityID,PlatformID,StatusID")] TrainTimeTable trainTimeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainTimeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Cities1, "CityID", "City", trainTimeTable.CityID);
            ViewBag.PlatformID = new SelectList(db.StationPlatforms, "PlatformID", "Platform", trainTimeTable.PlatformID);
            ViewBag.StationID = new SelectList(db.Stations1, "StationID", "Station", trainTimeTable.StationID);
            ViewBag.StatusID = new SelectList(db.StatusTables, "StatusID", "Status", trainTimeTable.StatusID);
            return View(trainTimeTable);
        }

        // GET: TrainTimeTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainTimeTable trainTimeTable = db.TrainTimeTables.Find(id);
            if (trainTimeTable == null)
            {
                return HttpNotFound();
            }
            return View(trainTimeTable);
        }

        // POST: TrainTimeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainTimeTable trainTimeTable = db.TrainTimeTables.Find(id);
            db.TrainTimeTables.Remove(trainTimeTable);
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
