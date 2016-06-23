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
    public class camionesController : Controller
    {
        private bonisoft_dbEntities db = new bonisoft_dbEntities();

        // GET: camiones
        public ActionResult Index()
        {
            return View(db.camions.ToList());
        }

        // GET: camiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            camion camion = db.camions.Find(id);
            if (camion == null)
            {
                return HttpNotFound();
            }
            return View(camion);
        }

        // GET: camiones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: camiones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Camion_ID,Matricula_camion,Matricula_zorra,Numero_ejes,Peso_Tara_origen,Peso_Tara_destino,Marca,Modelo,Comentarios,Peso_Neto")] camion camion)
        {
            if (ModelState.IsValid)
            {
                db.camions.Add(camion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(camion);
        }

        // GET: camiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            camion camion = db.camions.Find(id);
            if (camion == null)
            {
                return HttpNotFound();
            }
            return View(camion);
        }

        // POST: camiones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Camion_ID,Matricula_camion,Matricula_zorra,Numero_ejes,Peso_Tara_origen,Peso_Tara_destino,Marca,Modelo,Comentarios,Peso_Neto")] camion camion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(camion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(camion);
        }

        // GET: camiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            camion camion = db.camions.Find(id);
            if (camion == null)
            {
                return HttpNotFound();
            }
            return View(camion);
        }

        // POST: camiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            camion camion = db.camions.Find(id);
            db.camions.Remove(camion);
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
