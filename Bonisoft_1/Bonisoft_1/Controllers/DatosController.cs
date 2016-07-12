using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bonisoft_1.Controllers
{
    public class DatosController : Controller
    {
        private bonisoft_dbEntities db = new bonisoft_dbEntities();

        // GET: Datos
        public ActionResult Datos()
        {
            return View();
        }

        public PartialViewResult Personas()
        {
            return PartialView(db.personas.ToList());
        }

        public PartialViewResult Proveedores()
        {
            return PartialView(db.proveedores.ToList());
        }

        public PartialViewResult Viajes()
        {
            return PartialView(db.viajes.ToList());
        }

        public PartialViewResult Camiones()
        {
            return PartialView(db.camiones.ToList());
        }

        public PartialViewResult Choferes()
        {
            return PartialView(db.choferes.ToList());
        }

        public PartialViewResult Cuadrillas_descarga()
        {
            return PartialView(db.cuadrilla_descarga.ToList());
        }

        public PartialViewResult Internos()
        {
            return PartialView(db.internos.ToList());
        }




    }
}