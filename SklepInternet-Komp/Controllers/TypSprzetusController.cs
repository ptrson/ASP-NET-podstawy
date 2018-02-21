using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SklepInternet_Komp.Models
{
    public class TypSprzetusController : Controller
    {
        private SklepDataContext db = new SklepDataContext();

        // GET: TypSprzetus
        public ActionResult Index(string filter)
        {
            List<TypSprzetu> typSprzetu;
            if (filter != null)
            {
                typSprzetu = db.TypSprzetus.Where(a => a.NazwaTypu.StartsWith(filter)).ToList();
                return View(typSprzetu);
            }
            return View(db.TypSprzetus.ToList());
        }

        // GET: TypSprzetus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypSprzetu typSprzetu = db.TypSprzetus.Find(id);
            if (typSprzetu == null)
            {
                return HttpNotFound();
            }
            return View(typSprzetu);
        }

        // GET: TypSprzetus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypSprzetus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTypu,NazwaTypu")] TypSprzetu typSprzetu)
        {
            if (ModelState.IsValid)
            {
                db.TypSprzetus.Add(typSprzetu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typSprzetu);
        }

        // GET: TypSprzetus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypSprzetu typSprzetu = db.TypSprzetus.Find(id);
            if (typSprzetu == null)
            {
                return HttpNotFound();
            }
            return View(typSprzetu);
        }

        // POST: TypSprzetus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTypu,NazwaTypu")] TypSprzetu typSprzetu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typSprzetu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typSprzetu);
        }

        // GET: TypSprzetus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypSprzetu typSprzetu = db.TypSprzetus.Find(id);
            if (typSprzetu == null)
            {
                return HttpNotFound();
            }
            return View(typSprzetu);
        }

        // POST: TypSprzetus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypSprzetu typSprzetu = db.TypSprzetus.Find(id);
            db.TypSprzetus.Remove(typSprzetu);
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
