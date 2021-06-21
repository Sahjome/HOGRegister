using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HOGRegister.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Units(string name)
        {
            ViewBag.Title = "All Units " + name;
            return View("Units/Units");
        }
        public ActionResult UnitDetail()
        {
            return View("Units/UnitDetail");
        }
        public ActionResult AddUnit()
        {
            return View("Units/AddUnit");
        }
    }
}