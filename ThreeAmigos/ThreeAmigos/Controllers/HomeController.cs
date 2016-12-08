using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeAmigos.Interfaces;

namespace ThreeAmigos.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public ActionResult Index()
        {
            TempData["Error"] = "Testing";
            return View();
        }
    }
}
