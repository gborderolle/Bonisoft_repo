using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bonisoft_1.Controllers
{
    public class DatosController : Controller
    {
        private bonisoft_dbEntities db = new bonisoft_dbEntities();

        #region Left panel Actions BEGIN

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

        #endregion 

        #region Box Actions BEGIN

        public PartialViewResult Proveedores()
        {
            return PartialView("~/views/Proveedores/Index.cshtml", db.proveedor.ToList());
        }

        public PartialViewResult Clientes()
        {
            return PartialView("~/views/Clientes/Index.cshtml", db.cliente.ToList());
        }

        public PartialViewResult Viajes()
        {
            return PartialView("~/views/Viajes/Index.cshtml", db.viaje.ToList());
        }

        public PartialViewResult Choferes()
        {
            return PartialView("~/views/Choferes/Index.cshtml", db.chofer.ToList());
        }

        public PartialViewResult Cuadrillas_descarga()
        {
            return PartialView("~/views/Cuadrillas_descarga/Index.cshtml", db.cuadrilla_descarga.ToList());
        }

        public PartialViewResult Internos()
        {
            return PartialView("~/views/Internos/Index.cshtml", db.interno.ToList());
        }

        public PartialViewResult Pesadas()
        {
            return PartialView("~/views/Pesadas/Index.cshtml", db.pesada.ToList());
        }
        public PartialViewResult Camiones()
        {
            return PartialView("~/views/Camiones/Index.cshtml", db.camion.ToList());
        }
        public PartialViewResult Personas()
        {
            return PartialView("~/views/Personas/Index.cshtml", db.persona.ToList());
        }
        public PartialViewResult Contacto_medio()
        {
            return PartialView("~/views/Contacto_medio/Index.cshtml", db.contacto_medio.ToList());
        }

        #endregion 


        public string GetUserNameComplete()
        {
            string ret = string.Empty;
            if (Session["UserID"] != null)
            {
                int userID = 0;
                if (!int.TryParse(Session["UserID"].ToString(), out userID))
                {
                    userID = 0;
                }
                else
                {
                    var model = from p in db.usuario where p.Usuario_ID == userID select p.Nombres + " " + p.Apellidos;
                    ret = model.SingleOrDefault().ToString();
                }
            }
            return ret;
        }

        public string GetUserAvatar()
        {
            string ret = string.Empty;
            if (Session["Username"] != null)
            {
                string Username = Session["Username"].ToString();
                if (!string.IsNullOrWhiteSpace(Username))
                {
                    if (ConfigurationManager.AppSettings != null)
                    {
                        ret = ConfigurationManager.AppSettings["UserAvatarURLs"].ToString() + Username;
                        if (System.IO.File.Exists(ret + ".png"))
                        {
                            ret += ".png";
                        }
                        else if (System.IO.File.Exists(ret + ".jpg"))
                        {
                            ret += ".jpg";
                        }
                    }
                }
            }
            return ret;
        }


        public string GetTableCount(string table)
        {
            string ret = string.Empty;

            if (!string.IsNullOrWhiteSpace(table))
            {
                int count = 0;
                switch (table.ToLowerInvariant())
                {
                    case "proveedores":
                        {
                            count = (from p in db.proveedor select p).Count();
                            break;
                        }
                    case "clientes":
                        {
                            count = (from p in db.cliente select p).Count();
                            break;
                        }
                    case "viajes":
                        {
                            count = (from p in db.viaje select p).Count();
                            break;
                        }
                    case "choferes":
                        {
                            count = (from p in db.chofer select p).Count();
                            break;
                        }
                    case "cuadrillas":
                        {
                            count = (from p in db.cuadrilla_descarga select p).Count();
                            break;
                        }
                    case "internos":
                        {
                            count = (from p in db.interno select p).Count();
                            break;
                        }
                    case "pesadas":
                        {
                            count = (from p in db.pesada select p).Count();
                            break;
                        }
                    case "camiones":
                        {
                            count = (from p in db.camion select p).Count();
                            break;
                        }
                }
                ret = count.ToString();
            }
            
            return ret;
        }



    }
}