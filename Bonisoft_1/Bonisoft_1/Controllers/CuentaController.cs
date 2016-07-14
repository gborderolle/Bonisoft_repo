using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bonisoft_1.Controllers
{
    public class CuentaController : Controller
    {
        private bonisoft_dbEntities db = new bonisoft_dbEntities();

        // GET: Cuenta
        public ActionResult Index()
        {
            return View(db.usuario.ToList());
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(usuario user)
        {
            if (ModelState.IsValid)
            {
                db.usuario.Add(user);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = user.Usuario1 + " se registró correctamente.";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(usuario user)
        {
            var usr = db.usuario.SingleOrDefault(u => u.Usuario1 == user.Usuario1 && u.Clave == user.Clave);
            if (usr != null)
            {
                Session["UserID"] = usr.Usuario_ID.ToString();
                Session["Username"] = usr.Usuario1;
                return RedirectToAction("Datos", "Datos", null);
            }
            else
            {
                ModelState.AddModelError("", "Usuario o Contraseña son incorrectos.");
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult LoggedOut()
        {
            Session["UserID"] = null;
            Session["Username"] = null;

            return RedirectToAction("Login");
        }


        public ActionResult Rol_usuario(int ID)
        {
            var model = from p in db.roles_usuario where p.Roles_usuario_ID == ID select p;
            return View(model.SingleOrDefault());
        }



    }
}