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
    public class choferesController : Controller
    {
        private bonisoft_dbEntities db = new bonisoft_dbEntities();

        // GET: choferes
        public ActionResult Index()
        {
            return View(db.choferes.ToList());
        }

        // GET: choferes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chofer chofer = db.choferes.Find(id);
            if (chofer == null)
            {
                return HttpNotFound();
            }
            return View(chofer);
        }

        // GET: choferes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: choferes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Chofer_ID,Persona_ID,Empresa_pertenece_ID,Comentarios")] chofer chofer)
        {
            if (ModelState.IsValid)
            {
                db.choferes.Add(chofer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chofer);
        }

        // GET: choferes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chofer chofer = db.choferes.Find(id);
            if (chofer == null)
            {
                return HttpNotFound();
            }
            return View(chofer);
        }

        // POST: choferes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Chofer_ID,Persona_ID,Empresa_pertenece_ID,Comentarios")] chofer chofer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chofer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chofer);
        }

        // GET: choferes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chofer chofer = db.choferes.Find(id);
            if (chofer == null)
            {
                return HttpNotFound();
            }
            return View(chofer);
        }

        // POST: choferes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            chofer chofer = db.choferes.Find(id);
            db.choferes.Remove(chofer);
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
