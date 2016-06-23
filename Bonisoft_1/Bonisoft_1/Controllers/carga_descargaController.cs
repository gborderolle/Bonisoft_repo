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
    public class carga_descargaController : Controller
    {
        private bonisoft_dbEntities db = new bonisoft_dbEntities();

        // GET: carga_descarga
        public ActionResult Index()
        {
            return View(db.carga_descarga.ToList());
        }

        // GET: carga_descarga/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carga_descarga carga_descarga = db.carga_descarga.Find(id);
            if (carga_descarga == null)
            {
                return HttpNotFound();
            }
            return View(carga_descarga);
        }

        // GET: carga_descarga/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: carga_descarga/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Carga_descarga_ID,Lugar,Fecha,Comentarios")] carga_descarga carga_descarga)
        {
            if (ModelState.IsValid)
            {
                db.carga_descarga.Add(carga_descarga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carga_descarga);
        }

        // GET: carga_descarga/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carga_descarga carga_descarga = db.carga_descarga.Find(id);
            if (carga_descarga == null)
            {
                return HttpNotFound();
            }
            return View(carga_descarga);
        }

        // POST: carga_descarga/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Carga_descarga_ID,Lugar,Fecha,Comentarios")] carga_descarga carga_descarga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carga_descarga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carga_descarga);
        }

        // GET: carga_descarga/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carga_descarga carga_descarga = db.carga_descarga.Find(id);
            if (carga_descarga == null)
            {
                return HttpNotFound();
            }
            return View(carga_descarga);
        }

        // POST: carga_descarga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            carga_descarga carga_descarga = db.carga_descarga.Find(id);
            db.carga_descarga.Remove(carga_descarga);
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
