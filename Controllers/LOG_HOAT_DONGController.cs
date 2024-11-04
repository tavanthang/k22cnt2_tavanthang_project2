using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using newmoi2.Models;

namespace newmoi2.Controllers
{
    public class LOG_HOAT_DONGController : Controller
    {
        private tvtEntities db = new tvtEntities();

        // GET: LOG_HOAT_DONG
        public ActionResult Index()
        {
            var lOG_HOAT_DONG = db.LOG_HOAT_DONG.Include(l => l.QUAN_TRI_VIEN);
            return View(lOG_HOAT_DONG.ToList());
        }

        // GET: LOG_HOAT_DONG/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOG_HOAT_DONG lOG_HOAT_DONG = db.LOG_HOAT_DONG.Find(id);
            if (lOG_HOAT_DONG == null)
            {
                return HttpNotFound();
            }
            return View(lOG_HOAT_DONG);
        }

        // GET: LOG_HOAT_DONG/Create
        public ActionResult Create()
        {
            ViewBag.QUAN_TRI_ID = new SelectList(db.QUAN_TRI_VIEN, "QUAN_TRI_ID", "HO_TEN");
            return View();
        }

        // POST: LOG_HOAT_DONG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LOG_ID,QUAN_TRI_ID,NOI_DUNG,THOI_GIAN")] LOG_HOAT_DONG lOG_HOAT_DONG)
        {
            if (ModelState.IsValid)
            {
                db.LOG_HOAT_DONG.Add(lOG_HOAT_DONG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QUAN_TRI_ID = new SelectList(db.QUAN_TRI_VIEN, "QUAN_TRI_ID", "HO_TEN", lOG_HOAT_DONG.QUAN_TRI_ID);
            return View(lOG_HOAT_DONG);
        }

        // GET: LOG_HOAT_DONG/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOG_HOAT_DONG lOG_HOAT_DONG = db.LOG_HOAT_DONG.Find(id);
            if (lOG_HOAT_DONG == null)
            {
                return HttpNotFound();
            }
            ViewBag.QUAN_TRI_ID = new SelectList(db.QUAN_TRI_VIEN, "QUAN_TRI_ID", "HO_TEN", lOG_HOAT_DONG.QUAN_TRI_ID);
            return View(lOG_HOAT_DONG);
        }

        // POST: LOG_HOAT_DONG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LOG_ID,QUAN_TRI_ID,NOI_DUNG,THOI_GIAN")] LOG_HOAT_DONG lOG_HOAT_DONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOG_HOAT_DONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QUAN_TRI_ID = new SelectList(db.QUAN_TRI_VIEN, "QUAN_TRI_ID", "HO_TEN", lOG_HOAT_DONG.QUAN_TRI_ID);
            return View(lOG_HOAT_DONG);
        }

        // GET: LOG_HOAT_DONG/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOG_HOAT_DONG lOG_HOAT_DONG = db.LOG_HOAT_DONG.Find(id);
            if (lOG_HOAT_DONG == null)
            {
                return HttpNotFound();
            }
            return View(lOG_HOAT_DONG);
        }

        // POST: LOG_HOAT_DONG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOG_HOAT_DONG lOG_HOAT_DONG = db.LOG_HOAT_DONG.Find(id);
            db.LOG_HOAT_DONG.Remove(lOG_HOAT_DONG);
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
