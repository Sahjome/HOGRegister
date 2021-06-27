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
        public ActionResult Workers()
        {
            return View("Workers/Workers");
        }
        public ActionResult WorkerDetail()
        {
            return View("Workers/WorkerDetail");
        }
        public ActionResult AddWorker()
        {
            return View("Workers/AddWorker");
        }
        public ActionResult EditWorker()
        {
            return View("Workers/EditWorker");
        }
        public ActionResult SuspendedWorkers()
        {
            return View("Workers/SuspendedWorkers");
        }
        public ActionResult DisabledWorkers()
        {
            return View("Workers/DisabledWorkers");
        }
        public ActionResult FingerPrint()
        {
            return View("Workers/FingerPrint");
        }
        public ActionResult Logs()
        {
            return View("Logs/Logs");
        }
        public ActionResult LogDetails()
        {
            return View("Logs/LogDetails");
        }
    }
}