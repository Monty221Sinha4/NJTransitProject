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
    public class StatusTablesController : Controller
    {
        private NJData1 db = new NJData1();

        // GET: StatusTables
        public ActionResult Index()
        {
            return View(db.StatusTables.ToList());
        }

        // GET: StatusTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusTable statusTable = db.StatusTables.Find(id);
            if (statusTable == null)
            {
                return HttpNotFound();
            }
            return View(statusTable);
        }

        // GET: StatusTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatusID,Status")] StatusTable statusTable)
        {
            if (ModelState.IsValid)
            {
                db.StatusTables.Add(statusTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusTable);
        }

        // GET: StatusTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusTable statusTable = db.StatusTables.Find(id);
            if (statusTable == null)
            {
                return HttpNotFound();
            }
            return View(statusTable);
        }

        // POST: StatusTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatusID,Status")] StatusTable statusTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusTable);
        }

        // GET: StatusTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusTable statusTable = db.StatusTables.Find(id);
            if (statusTable == null)
            {
                return HttpNotFound();
            }
            return View(statusTable);
        }

        // POST: StatusTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatusTable statusTable = db.StatusTables.Find(id);
            db.StatusTables.Remove(statusTable);
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
