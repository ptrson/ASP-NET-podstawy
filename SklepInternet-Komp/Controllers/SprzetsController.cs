using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SklepInternet_Komp.Models;

namespace SklepInternet_Komp.Controllers
{
    public class SprzetsController : Controller
    {
        private SklepDataContext db = new SklepDataContext();

        // GET: Sprzets
        public ActionResult Index()
        {
            var sprzets = db.Sprzets.Include(s => s.Producents).Include(s => s.TypSprzetus);
            return View(sprzets.ToList());
        }

        // GET: Sprzets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sprzet sprzet = db.Sprzets.Find(id);
            if (sprzet == null)
            {
                return HttpNotFound();
            }
            return View(sprzet);
        }

        // GET: Sprzets/Create
        public ActionResult Create()
        {
            ViewBag.IdProducenta = new SelectList(db.Producents, "IdProducenta", "NazwaProducenta");
            ViewBag.IdTypu = new SelectList(db.TypSprzetus, "IdTypu", "NazwaTypu");
            return View();
        }

        // POST: Sprzets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSprzetu,Nazwa,RokProdukcji,Kolor,Cena,IdProducenta,IdTypu")] Sprzet sprzet)
        {
            if (ModelState.IsValid)
            {
                db.Sprzets.Add(sprzet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProducenta = new SelectList(db.Producents, "IdProducenta", "NazwaProducenta", sprzet.IdProducenta);
            ViewBag.IdTypu = new SelectList(db.TypSprzetus, "IdTypu", "NazwaTypu", sprzet.IdTypu);
            return View(sprzet);
        }

        // GET: Sprzets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sprzet sprzet = db.Sprzets.Include(s => s.Producents).FirstOrDefault(s => s.IdProducenta == id);
            //Sprzet sprzet = db.Sprzets.Find(id);
            if (sprzet == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProducenta = new SelectList(db.Producents, "IdProducenta", "NazwaProducenta", sprzet.IdProducenta);
            ViewBag.IdTypu = new SelectList(db.TypSprzetus, "IdTypu", "NazwaTypu", sprzet.IdTypu);
            return View(sprzet);
        }

        // POST: Sprzets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSprzetu,Nazwa,RokProdukcji,Kolor,Cena,IdProducenta,IdTypu")] Sprzet sprzet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sprzet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProducenta = new SelectList(db.Producents, "IdProducenta", "NazwaProducenta", sprzet.IdProducenta);
            ViewBag.IdTypu = new SelectList(db.TypSprzetus, "IdTypu", "NazwaTypu", sprzet.IdTypu);
            return View(sprzet);
        }

        // GET: Sprzets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sprzet sprzet = db.Sprzets.Find(id);
            if (sprzet == null)
            {
                return HttpNotFound();
            }
            return View(sprzet);
        }

        // POST: Sprzets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sprzet sprzet = db.Sprzets.Find(id);
            db.Sprzets.Remove(sprzet);
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
