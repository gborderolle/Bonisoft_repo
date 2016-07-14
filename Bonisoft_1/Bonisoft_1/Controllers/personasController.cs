using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bonisoft_1;
using Bonisoft_1.Models;

namespace Bonisoft_1.Controllers
{
    public class personasController : Controller
    {
        private bonisoft_dbEntities db = new bonisoft_dbEntities();

        // GET: personas
        public ActionResult Index()
        {
            return PartialView(db.persona.ToList());
            //return View(db.personas.ToList());
        }

        // GET: personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = db.persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: personas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: personas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Persona_ID,Apellidos,Nombres,Fecha_nacimiento,CI,Contacto_medio_1_ID,Contacto_medio_2_ID,Ciudad,Departamento,Comentarios")] persona persona)
        {
            if (ModelState.IsValid)
            {
                db.persona.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(persona);
        }

        // GET: personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = db.persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: personas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Persona_ID,Apellidos,Nombres,Fecha_nacimiento,CI,Contacto_medio_1_ID,Contacto_medio_2_ID,Ciudad,Departamento,Comentarios")] persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(persona);
        }

        // GET: personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = db.persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            persona persona = db.persona.Find(id);
            db.persona.Remove(persona);
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

        // ----------------------------------------------------------------------------------------------

        public ActionResult Personas_custom()
        {
            var modelo = from p in db.persona
                         join m1 in db.contacto_medio
                         on p.Contacto_medio_1_ID equals m1.Contacto_medio_ID
                         join m2 in db.contacto_medio
                         on p.Contacto_medio_2_ID equals m2.Contacto_medio_ID

                         select new _Persona
                         {
                             Apellidos = p.Apellidos,
                             Nombres = p.Nombres,
                             Fecha_nacimiento = p.Fecha_nacimiento,
                             CI = p.CI,
                             Contacto_medio_1_ID = m1.Comentarios,
                             Contacto_medio_2_ID = m2.Comentarios,
                             Ciudad = p.Ciudad,
                             Departamento = p.Departamento,
                             Comentarios = p.Comentarios,
                         };

            return PartialView(modelo.ToList());
        }

        public ActionResult Contacto_medio(int id)
        {
            var modelo = from p in db.contacto_medio where p.Contacto_medio_ID == id select p;
            var modelo_obj = modelo.SingleOrDefault();
            if (modelo_obj == null)
            {
                return new EmptyResult();
            }
            return PartialView(modelo_obj);
        }
    }
}
