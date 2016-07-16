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
    public class viajesController : Controller
    {
        private bonisoft_dbEntities db = new bonisoft_dbEntities();

        // GET: viajes
        public ActionResult Index()
        {
            return PartialView(db.viaje.ToList());
        }

        // GET: viajes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            viaje viaje = db.viaje.Find(id);
            if (viaje == null)
            {
                return HttpNotFound();
            }
            return View(viaje);
        }

        // GET: viajes/Create
        public ActionResult Create()
        {
            ViewBag.ListaForma_de_pago = new SelectList(db.forma_de_pago, "Forma_de_pago_ID", "Forma");
            ViewBag.ListaCargaDescarga = new SelectList(db.carga_descarga, "Carga_descarga_ID", "Fecha");
            ViewBag.ListaCargaDescarga = new SelectList(db.carga_descarga, "Carga_descarga_ID", "Fecha");
            ViewBag.ListaPesadas = new SelectList(db.pesada, "Pesada_ID", "Fecha");
            ViewBag.ListaPesadas = new SelectList(db.pesada, "Pesada_ID", "Fecha");
            ViewBag.ListaEmpresas = new SelectList(db.empresa, "Empresa_ID", "Nombre_fantasia");
            ViewBag.ListaCamiones = new SelectList(db.camion, "Camion_ID", "Marca");
            ViewBag.ListaChoferes = new SelectList(db.chofer, "Chofer_ID", "Comentarios");
            return View();
        }

        // POST: viajes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Viaje_ID,Precio_compra_por_tonelada,Precio_valor_total,Importe_viaje,Saldo,Forma_de_pago_ID,Carga_ID,Descarga_ID,Pesada_origen_ID,Pesada_destino_ID,Empresa_de_carga_ID,Fecha_partida,Fecha_llegada,Camion_ID,Chofer_ID,Comentarios")] viaje viaje)
        {
            if (ModelState.IsValid)
            {
                db.viaje.Add(viaje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viaje);
        }

        // GET: viajes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            viaje viaje = db.viaje.Find(id);
            if (viaje == null)
            {
                return HttpNotFound();
            }
            return View(viaje);
        }

        // POST: viajes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Viaje_ID,Precio_compra_por_tonelada,Precio_valor_total,Importe_viaje,Saldo,Forma_de_pago_ID,Carga_ID,Descarga_ID,Pesada_origen_ID,Pesada_destino_ID,Empresa_de_carga_ID,Fecha_partida,Fecha_llegada,Camion_ID,Chofer_ID,Comentarios")] viaje viaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viaje);
        }

        // GET: viajes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            viaje viaje = db.viaje.Find(id);
            if (viaje == null)
            {
                return HttpNotFound();
            }
            return View(viaje);
        }

        // POST: viajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            viaje viaje = db.viaje.Find(id);
            db.viaje.Remove(viaje);
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
