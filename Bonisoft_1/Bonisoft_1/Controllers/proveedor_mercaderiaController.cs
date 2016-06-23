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
    public class proveedor_mercaderiaController : Controller
    {
        private bonisoft_dbEntities db = new bonisoft_dbEntities();

        // GET: proveedor_mercaderia
        public ActionResult Index()
        {
            return View(db.proveedor_mercaderia.ToList());
        }

        // GET: proveedor_mercaderia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor_mercaderia proveedor_mercaderia = db.proveedor_mercaderia.Find(id);
            if (proveedor_mercaderia == null)
            {
                return HttpNotFound();
            }
            return View(proveedor_mercaderia);
        }

        // GET: proveedor_mercaderia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: proveedor_mercaderia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Proveedor_ID,Mercaderia_ID")] proveedor_mercaderia proveedor_mercaderia)
        {
            if (ModelState.IsValid)
            {
                db.proveedor_mercaderia.Add(proveedor_mercaderia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proveedor_mercaderia);
        }

        // GET: proveedor_mercaderia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor_mercaderia proveedor_mercaderia = db.proveedor_mercaderia.Find(id);
            if (proveedor_mercaderia == null)
            {
                return HttpNotFound();
            }
            return View(proveedor_mercaderia);
        }

        // POST: proveedor_mercaderia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Proveedor_ID,Mercaderia_ID")] proveedor_mercaderia proveedor_mercaderia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedor_mercaderia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proveedor_mercaderia);
        }

        // GET: proveedor_mercaderia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proveedor_mercaderia proveedor_mercaderia = db.proveedor_mercaderia.Find(id);
            if (proveedor_mercaderia == null)
            {
                return HttpNotFound();
            }
            return View(proveedor_mercaderia);
        }

        // POST: proveedor_mercaderia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            proveedor_mercaderia proveedor_mercaderia = db.proveedor_mercaderia.Find(id);
            db.proveedor_mercaderia.Remove(proveedor_mercaderia);
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
