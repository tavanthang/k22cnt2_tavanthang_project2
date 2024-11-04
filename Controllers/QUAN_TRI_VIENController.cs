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
    public class QUAN_TRI_VIENController : Controller
    {
        private tvtEntities db = new tvtEntities();

        // GET: QUAN_TRI_VIEN
        public ActionResult Index()
        {
            return View(db.QUAN_TRI_VIEN.ToList());
        }

        // GET: QUAN_TRI_VIEN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUAN_TRI_VIEN qUAN_TRI_VIEN = db.QUAN_TRI_VIEN.Find(id);
            if (qUAN_TRI_VIEN == null)
            {
                return HttpNotFound();
            }
            return View(qUAN_TRI_VIEN);
        }

        // GET: QUAN_TRI_VIEN/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QUAN_TRI_VIEN/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QUAN_TRI_ID,HO_TEN,EMAIL,MAT_KHAU,TRANG_THAI")] QUAN_TRI_VIEN qUAN_TRI_VIEN)
        {
            if (ModelState.IsValid)
            {
                db.QUAN_TRI_VIEN.Add(qUAN_TRI_VIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qUAN_TRI_VIEN);
        }

        // GET: QUAN_TRI_VIEN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUAN_TRI_VIEN qUAN_TRI_VIEN = db.QUAN_TRI_VIEN.Find(id);
            if (qUAN_TRI_VIEN == null)
            {
                return HttpNotFound();
            }
            return View(qUAN_TRI_VIEN);
        }

        // POST: QUAN_TRI_VIEN/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QUAN_TRI_ID,HO_TEN,EMAIL,MAT_KHAU,TRANG_THAI")] QUAN_TRI_VIEN qUAN_TRI_VIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qUAN_TRI_VIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qUAN_TRI_VIEN);
        }

        // GET: QUAN_TRI_VIEN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUAN_TRI_VIEN qUAN_TRI_VIEN = db.QUAN_TRI_VIEN.Find(id);
            if (qUAN_TRI_VIEN == null)
            {
                return HttpNotFound();
            }
            return View(qUAN_TRI_VIEN);
        }

        // POST: QUAN_TRI_VIEN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QUAN_TRI_VIEN qUAN_TRI_VIEN = db.QUAN_TRI_VIEN.Find(id);
            db.QUAN_TRI_VIEN.Remove(qUAN_TRI_VIEN);
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

        // GET: QUAN_TRI_VIEN/DangNhap
        public ActionResult dang_nhap()
        {
            var model = new QUAN_TRI_VIEN();
            return View(model);
        }

        // POST: QUAN_TRI_VIEN/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult dang_nhap(QUAN_TRI_VIEN QUAN_TRI_VIEN)
        {
            var check = db.QUAN_TRI_VIEN.Where(x => x.EMAIL.Equals(x.EMAIL) && x.MAT_KHAU.Equals(x.MAT_KHAU)).FirstOrDefault();

            if (check != null)
            {
                Session["QUAN_TRI_VIEN"] = check;
                return RedirectToAction("Index"); // Hoặc trang nào đó sau khi đăng nhập thành công
            }

            ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            return View("DangNhap", QUAN_TRI_VIEN);
        }
    }
}
