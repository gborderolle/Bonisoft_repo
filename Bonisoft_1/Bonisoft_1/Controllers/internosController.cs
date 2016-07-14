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
    public class internosController : Controller
    {
        private bonisoft_dbEntities db = new bonisoft_dbEntities();

        // GET: internos
        public ActionResult Index()
        {
            return PartialView(db.interno.ToList());
        }

        // GET: internos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            interno interno = db.interno.Find(id);
            if (interno == null)
            {
                return HttpNotFound();
            }
            return View(interno);
        }

        // GET: internos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: internos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Interno_ID,Persona_ID,Fecha_ingreso,Fecha_egreso,Cargo,Comentarios")] interno interno)
        {
            if (ModelState.IsValid)
            {
                db.interno.Add(interno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(interno);
        }

        // GET: internos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            interno interno = db.interno.Find(id);
            if (interno == null)
            {
                return HttpNotFound();
            }
            return View(interno);
        }

        // POST: internos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Interno_ID,Persona_ID,Fecha_ingreso,Fecha_egreso,Cargo,Comentarios")] interno interno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(interno);
        }

        // GET: internos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            interno interno = db.interno.Find(id);
            if (interno == null)
            {
                return HttpNotFound();
            }
            return View(interno);
        }

        // POST: internos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            interno interno = db.interno.Find(id);
            db.interno.Remove(interno);
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
