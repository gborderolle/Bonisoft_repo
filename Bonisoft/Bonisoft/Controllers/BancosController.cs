using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bonisoft.Controllers
{
    public class BancosController : Controller
    {
        // GET: Bancos
        public ActionResult Index()
        {
            return View();
        }
    }
}