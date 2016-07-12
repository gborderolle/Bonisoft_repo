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
    public class cuadrilla_descargasController : Controller
    {
        private bonisoft_dbEntities db = new bonisoft_dbEntities();

        // GET: cuadrilla_descargas
        public ActionResult Index()
        {
            return PartialView(db.cuadrilla_descarga.ToList());
        }

        // GET: cuadrilla_descargas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuadrilla_descarga cuadrilla_descarga = db.cuadrilla_descarga.Find(id);
            if (cuadrilla_descarga == null)
            {
                return HttpNotFound();
            }
            return View(cuadrilla_descarga);
        }

        // GET: cuadrilla_descargas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cuadrilla_descargas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cuadrilla_descarga_ID,Empresa_ID,Comentarios")] cuadrilla_descarga cuadrilla_descarga)
        {
            if (ModelState.IsValid)
            {
                db.cuadrilla_descarga.Add(cuadrilla_descarga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cuadrilla_descarga);
        }

        // GET: cuadrilla_descargas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuadrilla_descarga cuadrilla_descarga = db.cuadrilla_descarga.Find(id);
            if (cuadrilla_descarga == null)
            {
                return HttpNotFound();
            }
            return View(cuadrilla_descarga);
        }

        // POST: cuadrilla_descargas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cuadrilla_descarga_ID,Empresa_ID,Comentarios")] cuadrilla_descarga cuadrilla_descarga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuadrilla_descarga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cuadrilla_descarga);
        }

        // GET: cuadrilla_descargas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cuadrilla_descarga cuadrilla_descarga = db.cuadrilla_descarga.Find(id);
            if (cuadrilla_descarga == null)
            {
                return HttpNotFound();
            }
            return View(cuadrilla_descarga);
        }

        // POST: cuadrilla_descargas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cuadrilla_descarga cuadrilla_descarga = db.cuadrilla_descarga.Find(id);
            db.cuadrilla_descarga.Remove(cuadrilla_descarga);
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
