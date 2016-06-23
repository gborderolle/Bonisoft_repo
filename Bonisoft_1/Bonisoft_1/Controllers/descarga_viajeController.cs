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
    public class descarga_viajeController : Controller
    {
        private bonisoft_dbEntities db = new bonisoft_dbEntities();

        // GET: descarga_viaje
        public ActionResult Index()
        {
            return View(db.descarga_viaje.ToList());
        }

        // GET: descarga_viaje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            descarga_viaje descarga_viaje = db.descarga_viaje.Find(id);
            if (descarga_viaje == null)
            {
                return HttpNotFound();
            }
            return View(descarga_viaje);
        }

        // GET: descarga_viaje/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: descarga_viaje/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Descarga_viaje_ID,Viaje_ID,Cuadrilla_ID,Fecha,Demora,Comentarios")] descarga_viaje descarga_viaje)
        {
            if (ModelState.IsValid)
            {
                db.descarga_viaje.Add(descarga_viaje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(descarga_viaje);
        }

        // GET: descarga_viaje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            descarga_viaje descarga_viaje = db.descarga_viaje.Find(id);
            if (descarga_viaje == null)
            {
                return HttpNotFound();
            }
            return View(descarga_viaje);
        }

        // POST: descarga_viaje/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Descarga_viaje_ID,Viaje_ID,Cuadrilla_ID,Fecha,Demora,Comentarios")] descarga_viaje descarga_viaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(descarga_viaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(descarga_viaje);
        }

        // GET: descarga_viaje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            descarga_viaje descarga_viaje = db.descarga_viaje.Find(id);
            if (descarga_viaje == null)
            {
                return HttpNotFound();
            }
            return View(descarga_viaje);
        }

        // POST: descarga_viaje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            descarga_viaje descarga_viaje = db.descarga_viaje.Find(id);
            db.descarga_viaje.Remove(descarga_viaje);
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
