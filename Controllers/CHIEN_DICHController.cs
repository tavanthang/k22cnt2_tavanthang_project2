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
    public class CHIEN_DICHController : Controller
    {
        private tvtEntities db = new tvtEntities();

        // GET: CHIEN_DICH
        public ActionResult Index()
        {
            return View(db.CHIEN_DICH.ToList());
        }

        // GET: CHIEN_DICH/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHIEN_DICH cHIEN_DICH = db.CHIEN_DICH.Find(id);
            if (cHIEN_DICH == null)
            {
                return HttpNotFound();
            }
            return View(cHIEN_DICH);
        }

        // GET: CHIEN_DICH/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CHIEN_DICH/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CHIEN_DICH_ID,TEN_CHIEN_DICH,MO_TA,THOI_GIAN_BAT_DAU,THOI_GIAN_KET_THUC,DIEN_TICH,MAX_THAM_GIA,SO_NGUOI_DA_DANG_KY")] CHIEN_DICH cHIEN_DICH)
        {
            if (ModelState.IsValid)
            {
                db.CHIEN_DICH.Add(cHIEN_DICH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cHIEN_DICH);
        }

        // GET: CHIEN_DICH/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHIEN_DICH cHIEN_DICH = db.CHIEN_DICH.Find(id);
            if (cHIEN_DICH == null)
            {
                return HttpNotFound();
            }
            return View(cHIEN_DICH);
        }

        // POST: CHIEN_DICH/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CHIEN_DICH_ID,TEN_CHIEN_DICH,MO_TA,THOI_GIAN_BAT_DAU,THOI_GIAN_KET_THUC,DIEN_TICH,MAX_THAM_GIA,SO_NGUOI_DA_DANG_KY")] CHIEN_DICH cHIEN_DICH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHIEN_DICH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cHIEN_DICH);
        }

        // GET: CHIEN_DICH/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHIEN_DICH cHIEN_DICH = db.CHIEN_DICH.Find(id);
            if (cHIEN_DICH == null)
            {
                return HttpNotFound();
            }
            return View(cHIEN_DICH);
        }

        // POST: CHIEN_DICH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHIEN_DICH cHIEN_DICH = db.CHIEN_DICH.Find(id);
            db.CHIEN_DICH.Remove(cHIEN_DICH);
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
