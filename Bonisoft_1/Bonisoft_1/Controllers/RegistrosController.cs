using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bonisoft_1.Controllers
{
    public class RegistrosController : Controller
    {
        private bonisoft_dbEntities db = new bonisoft_dbEntities();

        // Left panel Actions BEGIN
        public ActionResult Datos(string table)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("LoggedOut", "Cuenta", null);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(table))
                {
                    ViewBag.Table = table;
                }
            }
            return View();
        }

        public ActionResult Dashboard()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("LoggedOut", "Cuenta", null);
            }
            return View();
        }

        public ActionResult Recordatorios()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("LoggedOut", "Cuenta", null);
            }
            return View();
        }

        public ActionResult Contabilidad()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("LoggedOut", "Cuenta", null);
            }
            return View();
        }

        public ActionResult Baul()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("LoggedOut", "Cuenta", null);
            }
            return View();
        }
        public ActionResult Registros()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("LoggedOut", "Cuenta", null);
            }
            return View();
        }
        public ActionResult Ajustes()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("LoggedOut", "Cuenta", null);
            }
            return View();
        }

        // Left panel Actions END
    }
}