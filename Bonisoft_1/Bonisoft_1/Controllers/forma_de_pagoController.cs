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
    public class forma_de_pagoController : Controller
    {
        private bonisoft_dbEntities db = new bonisoft_dbEntities();

        // GET: forma_de_pago
        public ActionResult Index()
        {
            return View(db.forma_de_pago.ToList());
        }

        // GET: forma_de_pago/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            forma_de_pago forma_de_pago = db.forma_de_pago.Find(id);
            if (forma_de_pago == null)
            {
                return HttpNotFound();
            }
            return View(forma_de_pago);
        }

        // GET: forma_de_pago/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: forma_de_pago/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Forma_de_pago_ID,Forma,Comentarios")] forma_de_pago forma_de_pago)
        {
            if (ModelState.IsValid)
            {
                db.forma_de_pago.Add(forma_de_pago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(forma_de_pago);
        }

        // GET: forma_de_pago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            forma_de_pago forma_de_pago = db.forma_de_pago.Find(id);
            if (forma_de_pago == null)
            {
                return HttpNotFound();
            }
            return View(forma_de_pago);
        }

        // POST: forma_de_pago/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Forma_de_pago_ID,Forma,Comentarios")] forma_de_pago forma_de_pago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forma_de_pago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(forma_de_pago);
        }

        // GET: forma_de_pago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            forma_de_pago forma_de_pago = db.forma_de_pago.Find(id);
            if (forma_de_pago == null)
            {
                return HttpNotFound();
            }
            return View(forma_de_pago);
        }

        // POST: forma_de_pago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            forma_de_pago forma_de_pago = db.forma_de_pago.Find(id);
            db.forma_de_pago.Remove(forma_de_pago);
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
