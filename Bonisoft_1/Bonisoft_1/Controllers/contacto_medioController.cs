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
    public class contacto_medioController : Controller
    {
        private bonisoft_dbEntities db = new bonisoft_dbEntities();

        // GET: contacto_medio
        public ActionResult Index()
        {
            return View(db.contacto_medio.ToList());
        }

        // GET: contacto_medio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contacto_medio contacto_medio = db.contacto_medio.Find(id);
            if (contacto_medio == null)
            {
                return HttpNotFound();
            }
            return View(contacto_medio);
        }

        // GET: contacto_medio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: contacto_medio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Contacto_medio_ID,Direccion,Telefono_1,Telefono_2,Telefono_interno,Email,Comentarios")] contacto_medio contacto_medio)
        {
            if (ModelState.IsValid)
            {
                db.contacto_medio.Add(contacto_medio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contacto_medio);
        }

        // GET: contacto_medio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contacto_medio contacto_medio = db.contacto_medio.Find(id);
            if (contacto_medio == null)
            {
                return HttpNotFound();
            }
            return View(contacto_medio);
        }

        // POST: contacto_medio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Contacto_medio_ID,Direccion,Telefono_1,Telefono_2,Telefono_interno,Email,Comentarios")] contacto_medio contacto_medio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contacto_medio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contacto_medio);
        }

        // GET: contacto_medio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contacto_medio contacto_medio = db.contacto_medio.Find(id);
            if (contacto_medio == null)
            {
                return HttpNotFound();
            }
            return View(contacto_medio);
        }

        // POST: contacto_medio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contacto_medio contacto_medio = db.contacto_medio.Find(id);
            db.contacto_medio.Remove(contacto_medio);
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
