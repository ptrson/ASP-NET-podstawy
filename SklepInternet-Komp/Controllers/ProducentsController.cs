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
    public class ProducentsController : Controller
    {
        private SklepDataContext db = new SklepDataContext();

        // GET: Producents
        public ActionResult Index(string filter)
        {
            List<Producent> producent;
            if(filter != null)
            {
                producent = db.Producents.Where(a => a.NazwaProducenta.StartsWith(filter)).ToList();
                return View(producent);
            }
            return View(db.Producents.ToList());
        }

        // GET: Producents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producent producent = db.Producents.Find(id);
            if (producent == null)
            {
                return HttpNotFound();
            }
            return View(producent);
        }

        // GET: Producents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProducenta,NazwaProducenta,RokZalozenia,Panstwo")] Producent producent)
        {
            if (ModelState.IsValid)
            {
                db.Producents.Add(producent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producent);
        }

        // GET: Producents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producent producent = db.Producents.Find(id);
            if (producent == null)
            {
                return HttpNotFound();
            }
            return View(producent);
        }

        // POST: Producents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProducenta,NazwaProducenta,RokZalozenia,Panstwo")] Producent producent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producent);
        }

        // GET: Producents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producent producent = db.Producents.Find(id);
            if (producent == null)
            {
                return HttpNotFound();
            }
            return View(producent);
        }

        // POST: Producents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producent producent = db.Producents.Find(id);
            db.Producents.Remove(producent);
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
