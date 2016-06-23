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
    public class cliente_preferencias_clienteController : Controller
    {
        private bonisoft_dbEntities db = new bonisoft_dbEntities();

        // GET: cliente_preferencias_cliente
        public ActionResult Index()
        {
            return View(db.cliente_preferencias_cliente.ToList());
        }

        // GET: cliente_preferencias_cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente_preferencias_cliente cliente_preferencias_cliente = db.cliente_preferencias_cliente.Find(id);
            if (cliente_preferencias_cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente_preferencias_cliente);
        }

        // GET: cliente_preferencias_cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cliente_preferencias_cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cliente_ID,Cliente_Preferencias_cliente_ID")] cliente_preferencias_cliente cliente_preferencias_cliente)
        {
            if (ModelState.IsValid)
            {
                db.cliente_preferencias_cliente.Add(cliente_preferencias_cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente_preferencias_cliente);
        }

        // GET: cliente_preferencias_cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente_preferencias_cliente cliente_preferencias_cliente = db.cliente_preferencias_cliente.Find(id);
            if (cliente_preferencias_cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente_preferencias_cliente);
        }

        // POST: cliente_preferencias_cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cliente_ID,Cliente_Preferencias_cliente_ID")] cliente_preferencias_cliente cliente_preferencias_cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente_preferencias_cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente_preferencias_cliente);
        }

        // GET: cliente_preferencias_cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente_preferencias_cliente cliente_preferencias_cliente = db.cliente_preferencias_cliente.Find(id);
            if (cliente_preferencias_cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente_preferencias_cliente);
        }

        // POST: cliente_preferencias_cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cliente_preferencias_cliente cliente_preferencias_cliente = db.cliente_preferencias_cliente.Find(id);
            db.cliente_preferencias_cliente.Remove(cliente_preferencias_cliente);
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
