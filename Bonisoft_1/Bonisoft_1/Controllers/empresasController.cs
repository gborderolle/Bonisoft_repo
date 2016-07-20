﻿using System;
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
    public class empresasController : Controller
    {
        private bonisoft_dbEntities db = new bonisoft_dbEntities();

        // GET: empresas
        public ActionResult Index()
        {
            return View(db.empresa.ToList());
        }

        // GET: empresas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empresa empresa = db.empresa.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // GET: empresas/Create
        public ActionResult Create()
        {
            ViewBag.ListaMedioContactos = new SelectList(db.contacto_medio, "Contacto_medio_ID", "Telefono_1");
            ViewBag.ListaPersonas = new SelectList(db.persona, "Persona_ID", "Apellidos");
            ViewBag.ListaBancos = new SelectList(db.banco, "Contacto_medio_ID", "Nombre");
            return View();
        }

        // POST: empresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Empresa_ID,Nombre_fantasia,Nombre_real,RUT,Contacto_medio_1_ID,Contacto_medio_2_ID,Contacto_persona_1_ID,Contacto_persona_2_ID,Banco_ID,Ciudad,Departamento,Comentarios")] empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.empresa.Add(empresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empresa);
        }

        // GET: empresas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empresa empresa = db.empresa.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: empresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Empresa_ID,Nombre_fantasia,Nombre_real,RUT,Contacto_medio_1_ID,Contacto_medio_2_ID,Contacto_persona_1_ID,Contacto_persona_2_ID,Banco_ID,Ciudad,Departamento,Comentarios")] empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empresa);
        }

        // GET: empresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empresa empresa = db.empresa.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            empresa empresa = db.empresa.Find(id);
            db.empresa.Remove(empresa);
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
