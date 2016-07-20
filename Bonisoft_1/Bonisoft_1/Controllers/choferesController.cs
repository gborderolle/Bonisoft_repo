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
            return View(db.chofer.ToList());
        }

        // GET: choferes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chofer chofer = db.chofer.Find(id);
            if (chofer == null)
            {
                return HttpNotFound();
            }
            return View(chofer);
        }

        // GET: choferes/Create
        public ActionResult Create()
        {
            ViewBag.ListaPersonas = new SelectList(db.persona, "Persona_ID", "Apellidos");
            ViewBag.ListaEmpresas = new SelectList(db.empresa, "Empresa_ID", "Nombre_fantasia");
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
                db.chofer.Add(chofer);
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
            chofer chofer = db.chofer.Find(id);
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
            chofer chofer = db.chofer.Find(id);
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
            chofer chofer = db.chofer.Find(id);
            db.chofer.Remove(chofer);
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

        public ActionResult GetPersona(int id)
        {
            var modelo = from p in db.persona where p.Persona_ID == id select p;
            var modelo_obj = modelo.SingleOrDefault();
            if (modelo_obj == null)
            {
                return new EmptyResult();
            }

            ViewBag.PersonaName = modelo_obj.Nombres + " " + modelo_obj.Apellidos;
            return PartialView(modelo_obj);
        }

        public ActionResult GetEmpresa(int id)
        {
            var modelo = from p in db.empresa where p.Empresa_ID == id select p;
            var modelo_obj = modelo.SingleOrDefault();
            if (modelo_obj == null)
            {
                return new EmptyResult();
            }

            ViewBag.EmpresaName = modelo_obj.Nombre_fantasia;
            return PartialView(modelo_obj);
        }
    }
}
