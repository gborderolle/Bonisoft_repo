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
    public class proveedor_cargaController : Controller
    {
        private bonisoft_dbEntities db = new bonisoft_dbEntities();

        // GET: proveedor_carga
        public ActionResult Index()
        {
            return View(db.proveedor_carga.ToList());
        }

        // GET: proveedor_carga/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor_carga proveedor_carga = db.proveedor_carga.Find(id);
            if (proveedor_carga == null)
            {
                return HttpNotFound();
            }
            return View(proveedor_carga);
        }

        // GET: proveedor_carga/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: proveedor_carga/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Proveedor_ID,Carga_ID")] proveedor_carga proveedor_carga)
        {
            if (ModelState.IsValid)
            {
                db.proveedor_carga.Add(proveedor_carga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proveedor_carga);
        }

        // GET: proveedor_carga/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor_carga proveedor_carga = db.proveedor_carga.Find(id);
            if (proveedor_carga == null)
            {
                return HttpNotFound();
            }
            return View(proveedor_carga);
        }

        // POST: proveedor_carga/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Proveedor_ID,Carga_ID")] proveedor_carga proveedor_carga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedor_carga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proveedor_carga);
        }

        // GET: proveedor_carga/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor_carga proveedor_carga = db.proveedor_carga.Find(id);
            if (proveedor_carga == null)
            {
                return HttpNotFound();
            }
            return View(proveedor_carga);
        }

        // POST: proveedor_carga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            proveedor_carga proveedor_carga = db.proveedor_carga.Find(id);
            db.proveedor_carga.Remove(proveedor_carga);
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
