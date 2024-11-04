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
    public class DAT_HANGController : Controller
    {
        private tvtEntities db = new tvtEntities();

        // GET: DAT_HANG
        public ActionResult Index()
        {
            var dAT_HANG = db.DAT_HANG.Include(d => d.KHACH_HANG);
            return View(dAT_HANG.ToList());
        }

        // GET: DAT_HANG/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAT_HANG dAT_HANG = db.DAT_HANG.Find(id);
            if (dAT_HANG == null)
            {
                return HttpNotFound();
            }
            return View(dAT_HANG);
        }

        // GET: DAT_HANG/Create
        public ActionResult Create()
        {
            ViewBag.KHACH_HANG_ID = new SelectList(db.KHACH_HANG, "KHACH_HANG_ID", "HO_TEN");
            return View();
        }

        // POST: DAT_HANG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DAT_HANG_ID,KHACH_HANG_ID,NGAY_DAT,TONG_TIEN,TRANG_THAI")] DAT_HANG dAT_HANG)
        {
            if (ModelState.IsValid)
            {
                db.DAT_HANG.Add(dAT_HANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KHACH_HANG_ID = new SelectList(db.KHACH_HANG, "KHACH_HANG_ID", "HO_TEN", dAT_HANG.KHACH_HANG_ID);
            return View(dAT_HANG);
        }

        // GET: DAT_HANG/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAT_HANG dAT_HANG = db.DAT_HANG.Find(id);
            if (dAT_HANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.KHACH_HANG_ID = new SelectList(db.KHACH_HANG, "KHACH_HANG_ID", "HO_TEN", dAT_HANG.KHACH_HANG_ID);
            return View(dAT_HANG);
        }

        // POST: DAT_HANG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DAT_HANG_ID,KHACH_HANG_ID,NGAY_DAT,TONG_TIEN,TRANG_THAI")] DAT_HANG dAT_HANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dAT_HANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KHACH_HANG_ID = new SelectList(db.KHACH_HANG, "KHACH_HANG_ID", "HO_TEN", dAT_HANG.KHACH_HANG_ID);
            return View(dAT_HANG);
        }

        // GET: DAT_HANG/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAT_HANG dAT_HANG = db.DAT_HANG.Find(id);
            if (dAT_HANG == null)
            {
                return HttpNotFound();
            }
            return View(dAT_HANG);
        }

        // POST: DAT_HANG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DAT_HANG dAT_HANG = db.DAT_HANG.Find(id);
            db.DAT_HANG.Remove(dAT_HANG);
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
