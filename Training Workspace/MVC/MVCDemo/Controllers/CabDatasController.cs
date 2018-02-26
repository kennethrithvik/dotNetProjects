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
    public class CabDatasController : Controller
    {
        private MVCDemoContext db = new MVCDemoContext();

        // GET: CabDatas
        public ActionResult Index()
        {
            return View(db.CabDatas.ToList());
        }

        // GET: CabDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CabData cabData = db.CabDatas.Find(id);
            if (cabData == null)
            {
                return HttpNotFound();
            }
            return View(cabData);
        }

        // GET: CabDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CabDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CabNo,CabType,Capacity")] CabData cabData)
        {
            if (ModelState.IsValid)
            {
                db.CabDatas.Add(cabData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cabData);
        }

        // GET: CabDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CabData cabData = db.CabDatas.Find(id);
            if (cabData == null)
            {
                return HttpNotFound();
            }
            return View(cabData);
        }

        // POST: CabDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CabNo,CabType,Capacity")] CabData cabData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cabData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cabData);
        }

        // GET: CabDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CabData cabData = db.CabDatas.Find(id);
            if (cabData == null)
            {
                return HttpNotFound();
            }
            return View(cabData);
        }

        // POST: CabDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CabData cabData = db.CabDatas.Find(id);
            db.CabDatas.Remove(cabData);
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
