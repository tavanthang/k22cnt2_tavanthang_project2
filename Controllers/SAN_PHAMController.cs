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
    public class SAN_PHAMController : Controller
    {
        private tvtEntities db = new tvtEntities();

        // GET: SAN_PHAM
        public ActionResult Index()
        {
            var sAN_PHAM = db.SAN_PHAM.Include(s => s.CHIEN_DICH);
            return View(sAN_PHAM.ToList());
        }

        // GET: SAN_PHAM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            if (sAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(sAN_PHAM);
        }

        // GET: SAN_PHAM/Create
        public ActionResult Create()
        {
            ViewBag.CHIEN_DICH_ID = new SelectList(db.CHIEN_DICH, "CHIEN_DICH_ID", "TEN_CHIEN_DICH");
            return View();
        }

        // POST: SAN_PHAM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SAN_PHAM_ID,TEN_SAN_PHAM,MO_TA,GIA,SO_LUONG,TRANG_THAI,CHIEN_DICH_ID")] SAN_PHAM sAN_PHAM)
        {
            if (ModelState.IsValid)
            {
                db.SAN_PHAM.Add(sAN_PHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CHIEN_DICH_ID = new SelectList(db.CHIEN_DICH, "CHIEN_DICH_ID", "TEN_CHIEN_DICH", sAN_PHAM.CHIEN_DICH_ID);
            return View(sAN_PHAM);
        }

        // GET: SAN_PHAM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            if (sAN_PHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.CHIEN_DICH_ID = new SelectList(db.CHIEN_DICH, "CHIEN_DICH_ID", "TEN_CHIEN_DICH", sAN_PHAM.CHIEN_DICH_ID);
            return View(sAN_PHAM);
        }

        // POST: SAN_PHAM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SAN_PHAM_ID,TEN_SAN_PHAM,MO_TA,GIA,SO_LUONG,TRANG_THAI,CHIEN_DICH_ID")] SAN_PHAM sAN_PHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sAN_PHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CHIEN_DICH_ID = new SelectList(db.CHIEN_DICH, "CHIEN_DICH_ID", "TEN_CHIEN_DICH", sAN_PHAM.CHIEN_DICH_ID);
            return View(sAN_PHAM);
        }

        // GET: SAN_PHAM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            if (sAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(sAN_PHAM);
        }

        // POST: SAN_PHAM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SAN_PHAM sAN_PHAM = db.SAN_PHAM.Find(id);
            db.SAN_PHAM.Remove(sAN_PHAM);
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
