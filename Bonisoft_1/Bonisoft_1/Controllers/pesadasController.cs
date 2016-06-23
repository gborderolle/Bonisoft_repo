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
    public class pesadasController : Controller
    {
        private bonisoft_dbEntities db = new bonisoft_dbEntities();

        // GET: pesadas
        public ActionResult Index()
        {
            return View(db.pesadas.ToList());
        }

        // GET: pesadas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pesada pesada = db.pesadas.Find(id);
            if (pesada == null)
            {
                return HttpNotFound();
            }
            return View(pesada);
        }

        // GET: pesadas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: pesadas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pesada_ID,Lugar,Fecha,Nombre_balanza,Valor_pesada,Comentarios")] pesada pesada)
        {
            if (ModelState.IsValid)
            {
                db.pesadas.Add(pesada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pesada);
        }

        // GET: pesadas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pesada pesada = db.pesadas.Find(id);
            if (pesada == null)
            {
                return HttpNotFound();
            }
            return View(pesada);
        }

        // POST: pesadas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pesada_ID,Lugar,Fecha,Nombre_balanza,Valor_pesada,Comentarios")] pesada pesada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pesada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pesada);
        }

        // GET: pesadas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pesada pesada = db.pesadas.Find(id);
            if (pesada == null)
            {
                return HttpNotFound();
            }
            return View(pesada);
        }

        // POST: pesadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pesada pesada = db.pesadas.Find(id);
            db.pesadas.Remove(pesada);
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
