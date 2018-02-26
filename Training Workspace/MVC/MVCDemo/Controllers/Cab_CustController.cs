using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class Cab_CustController : Controller
    {
        private MVCDemoContext db = new MVCDemoContext();

        // GET: Cab_Cust
        public ActionResult Index()
        {
            var cab_Cust = db.Cab_Cust.Include(c => c.cabdata).Include(c => c.customer).Include(c => c.driver);
            return View(cab_Cust.ToList());
        }

        // GET: Cab_Cust/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cab_Cust cab_Cust = db.Cab_Cust.Find(id);
            if (cab_Cust == null)
            {
                return HttpNotFound();
            }
            return View(cab_Cust);
        }

        // GET: Cab_Cust/Create
        public ActionResult Create()
        {
            ViewBag.CabRefId = new SelectList(db.CabDatas, "CabNo", "CabNo");
            ViewBag.CustomerRefId = new SelectList(db.Customers, "CustomerID", "CustomerName");
            ViewBag.DriverRefId = new SelectList(db.Drivers, "DriverID", "DriverName");
            return View();
        }

        // POST: Cab_Cust/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CabRefId,CustomerRefId,DriverRefId")] Cab_Cust cab_Cust)
        {
            if (ModelState.IsValid)
            {
                db.Cab_Cust.Add(cab_Cust);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CabRefId = new SelectList(db.CabDatas, "CabNo", "CabNo", cab_Cust.CabRefId);
            ViewBag.CustomerRefId = new SelectList(db.Customers, "CustomerID", "CustomerName", cab_Cust.CustomerRefId);
            ViewBag.DriverRefId = new SelectList(db.Drivers, "DriverID", "DriverName", cab_Cust.DriverRefId);
            return View(cab_Cust);
        }

        // GET: Cab_Cust/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cab_Cust cab_Cust = db.Cab_Cust.Find(id);
            if (cab_Cust == null)
            {
                return HttpNotFound();
            }
            ViewBag.CabRefId = new SelectList(db.CabDatas, "CabNo", "CabNo", cab_Cust.CabRefId);
            ViewBag.CustomerRefId = new SelectList(db.Customers, "CustomerID", "CustomerName", cab_Cust.CustomerRefId);
            ViewBag.DriverRefId = new SelectList(db.Drivers, "DriverID", "DriverName", cab_Cust.DriverRefId);
            return View(cab_Cust);
        }

        // POST: Cab_Cust/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CabRefId,CustomerRefId,DriverRefId")] Cab_Cust cab_Cust)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cab_Cust).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CabRefId = new SelectList(db.CabDatas, "CabNo", "CabNo", cab_Cust.CabRefId);
            ViewBag.CustomerRefId = new SelectList(db.Customers, "CustomerID", "CustomerName", cab_Cust.CustomerRefId);
            ViewBag.DriverRefId = new SelectList(db.Drivers, "DriverID", "DriverName", cab_Cust.DriverRefId);
            return View(cab_Cust);
        }

        // GET: Cab_Cust/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cab_Cust cab_Cust = db.Cab_Cust.Find(id);
            if (cab_Cust == null)
            {
                return HttpNotFound();
            }
            return View(cab_Cust);
        }

        // POST: Cab_Cust/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cab_Cust cab_Cust = db.Cab_Cust.Find(id);
            db.Cab_Cust.Remove(cab_Cust);
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
