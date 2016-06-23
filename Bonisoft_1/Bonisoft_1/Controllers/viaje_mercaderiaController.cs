using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bonisoft_1;

namespace Bonisoft_1.Controllers
{
    public class viaje_mercaderiaController : Controller
    {
        private bonisoft_dbEntities db = new bonisoft_dbEntities();

        // GET: viaje_mercaderia
        public ActionResult Index()
        {
            return View(db.viaje_mercaderia.ToList());
        }

        // GET: viaje_mercaderia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            viaje_mercaderia viaje_mercaderia = db.viaje_mercaderia.Find(id);
            if (viaje_mercaderia == null)
            {
                return HttpNotFound();
            }
            return View(viaje_mercaderia);
        }

        // GET: viaje_mercaderia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: viaje_mercaderia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Viaje_ID,Mercaderia_ID")] viaje_mercaderia viaje_mercaderia)
        {
            if (ModelState.IsValid)
            {
                db.viaje_mercaderia.Add(viaje_mercaderia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viaje_mercaderia);
        }

        // GET: viaje_mercaderia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            viaje_mercaderia viaje_mercaderia = db.viaje_mercaderia.Find(id);
            if (viaje_mercaderia == null)
            {
                return HttpNotFound();
            }
            return View(viaje_mercaderia);
        }

        // POST: viaje_mercaderia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Viaje_ID,Mercaderia_ID")] viaje_mercaderia viaje_mercaderia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viaje_mercaderia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viaje_mercaderia);
        }

        // GET: viaje_mercaderia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            viaje_mercaderia viaje_mercaderia = db.viaje_mercaderia.Find(id);
            if (viaje_mercaderia == null)
            {
                return HttpNotFound();
            }
            return View(viaje_mercaderia);
        }

        // POST: viaje_mercaderia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            viaje_mercaderia viaje_mercaderia = db.viaje_mercaderia.Find(id);
            db.viaje_mercaderia.Remove(viaje_mercaderia);
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
