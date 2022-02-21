using HOGRegister.Data;
using HOGRegister.Data.Helper;
using HOGRegister.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HOGRegister.Controllers
{
    public class AdminController : Controller
    {
        private BaseModelData dataModel;

        #region Views

        public ActionResult Index()
        {
            var procedure = "spHomePageMetrics";
            dataModel = new BaseModelData();
            var result = dataModel.QueryProcedureForDataTable(procedure, null);
            var metrics = new List<HomeMetrics>();
            metrics = Converter<HomeMetrics>.DataTableToObject(result);
            return View(metrics);
        }
        public ActionResult Units()
        {
            ViewBag.Title = "All Units";
            var procedure = "spUnits";
            var parameters = new Dictionary<string, object>
            {
                {"ID", 0 },
                {"RESPONSIBILITY", string.Empty },
                {"UNITS", string.Empty },
                {"NAME", string.Empty },
                {"LEADER", string.Empty },
                {"OVERVIEW", string.Empty },
                { "TRANSTYPE", 100 }
            };
            dataModel = new BaseModelData();
            var result = dataModel.QueryProcedureForDataTable(procedure, parameters);
            var units = new List<Unit>();
            units = Converter<Unit>.DataTableToObject(result);
            return View("Units/Units", units);
        }
        public ActionResult UnitDetail(int Id)
        {
            var procedure = "spUnits";
            var parameters = new Dictionary<string, object>
            {
                {"ID", Id },
                {"RESPONSIBILITY", string.Empty },
                {"UNITS", string.Empty },
                {"NAME", string.Empty },
                {"LEADER", string.Empty },
                {"OVERVIEW", string.Empty },
                { "TRANSTYPE", 102 }
            };
            dataModel = new BaseModelData();
            var result = dataModel.QueryProcedureForDataTable(procedure, parameters);
            var units = new List<Unit>();
            units = Converter<Unit>.DataTableToObject(result);
            var name = units.Select(c => c.Name).FirstOrDefault();
            ViewBag.Title = name;
            return View("Units/UnitDetail", units[0]);
        }
        public ActionResult AddUnit()
        {
            return View("Units/AddUnit");
        }
        public ActionResult Workers()
        {
            var procedure = "spWorkers";
            var parameters = new Dictionary<string, object>
            {
                { "ID", 0 },
                { "TITLE", string.Empty },
                { "FIRSTNAME", string.Empty },
                { "MIDNAME", string.Empty },
                { "LASTNAME", string.Empty },
                { "PHONE", string.Empty },
                { "EMAIL", string.Empty },
                { "ADDRESS", string.Empty },
                { "GENDER", string.Empty },
                { "STATUS", 0 },
                { "ROLE", 0 },
                { "FINGERPRINT", string.Empty },
                { "UNITS", string.Empty },
                { "TRANSTYPE", 100 }
            };
            dataModel = new BaseModelData();
            var result = dataModel.QueryProcedureForDataTable(procedure, parameters);
            //var units = 
            var model = Converter<Worker>.DataTableToObject(result);
            return View("Workers/Workers", model);
        }
        public ActionResult WorkerDetail(int id)
        {
            var procedure = "spWorkers";
            var parameters = new Dictionary<string, object>
            {
                 { "ID", id },
                { "TITLE", string.Empty },
                { "FIRSTNAME", string.Empty },
                { "MIDNAME", string.Empty },
                { "LASTNAME", string.Empty },
                { "PHONE", string.Empty },
                { "EMAIL", string.Empty },
                { "ADDRESS", string.Empty },
                { "GENDER", string.Empty },
                { "STATUS", 0 },
                { "ROLE", 0 },
                { "FINGERPRINT", string.Empty },
                { "UNITS", string.Empty },
                { "TRANSTYPE", 102 }
            };
            dataModel = new BaseModelData();
            var workers = dataModel.QueryProcedureForDataTable(procedure, parameters);
            var unitIds = workers.Rows[0]["Units"].ToString();
            workers.Columns.Remove("Units");
            var units = dataModel.QueryProcedureForDataTable("spUnits", new Dictionary<string, object>
            {
                {"ID", 0 },
                {"RESPONSIBILITY", string.Empty },
                {"UNITS", unitIds },
                {"NAME", string.Empty },
                {"LEADER", string.Empty },
                {"OVERVIEW", string.Empty },
                { "TRANSTYPE", 104 }
            });
            var workerUnits = Converter<Unit>.DataTableToObject(units);

            var result = Converter<Worker>.DataTableToObject(workers);
            result[0].Units = workerUnits;
            return View("Workers/WorkerDetail", result[0]);
        }
        public ActionResult AddWorker()
        {
            var procedure = "spUnits";
            var parameters = new Dictionary<string, object>
            {
                {"ID", 0 },
                {"RESPONSIBILITY", string.Empty },
                {"UNITS", string.Empty },
                {"NAME", string.Empty },
                {"LEADER", string.Empty },
                {"OVERVIEW", string.Empty },
                { "TRANSTYPE", 100 }
            };
            dataModel = new BaseModelData();
            var result = dataModel.QueryProcedureForDataTable(procedure, parameters);
            var units = Converter<Unit>.DataTableToObject(result);
            ViewBag.Units = units;
            return View("Workers/AddWorker", new Worker());
        }
        public ActionResult EditWorker(int Id)
        {
            var procedure = "spWorkers";
            var parameters = new Dictionary<string, object>
            {
                { "ID", Id },
                { "TITLE", string.Empty },
                { "FIRSTNAME", string.Empty },
                { "MIDNAME", string.Empty },
                { "LASTNAME", string.Empty },
                { "PHONE", string.Empty },
                { "EMAIL", string.Empty },
                { "ADDRESS", string.Empty },
                { "GENDER", string.Empty },
                { "STATUS", 0 },
                { "ROLE", 0 },
                { "FINGERPRINT", string.Empty },
                { "UNITS", string.Empty },
                { "TRANSTYPE", 102 }
            };
            dataModel = new BaseModelData();
            var workers = dataModel.QueryProcedureForDataTable(procedure, parameters);
            var unitIds = workers.Rows[0]["Units"].ToString();
            workers.Columns.Remove("Units");
            var units = dataModel.QueryProcedureForDataTable("spUnits", new Dictionary<string, object>
            {
                {"ID", 0 },
                {"RESPONSIBILITY", string.Empty },
                {"UNITS", unitIds },
                {"NAME", string.Empty },
                {"LEADER", string.Empty },
                {"OVERVIEW", string.Empty },
                { "TRANSTYPE", 104 }
            });
            var workerUnits = Converter<Unit>.DataTableToObject(units);
            var result = Converter<Worker>.DataTableToObject(workers);
            result[0].Units = workerUnits;
            var unitList = dataModel.QueryProcedureForDataTable("spUnits", new Dictionary<string, object>
            {
                {"ID", 0 },
                {"RESPONSIBILITY", string.Empty },
                {"UNITS", string.Empty },
                {"NAME", string.Empty },
                {"LEADER", string.Empty },
                {"OVERVIEW", string.Empty },
                { "TRANSTYPE", 100 }
            });
            ViewBag.Units = Converter<Unit>.DataTableToObject(unitList);
            return View("Workers/EditWorker", result[0]);
        }
        public ActionResult StatusWorkers(int statusId)
        {
            var procedure = "spWorkers";
            var parameters = new Dictionary<string, object>
            {
                { "ID", 0 },
                { "TITLE", string.Empty },
                { "FIRSTNAME", string.Empty },
                { "MIDNAME", string.Empty },
                { "LASTNAME", string.Empty },
                { "PHONE", string.Empty },
                { "EMAIL", string.Empty },
                { "ADDRESS", string.Empty },
                { "GENDER", string.Empty },
                { "STATUS", statusId },
                { "ROLE", 0 },
                { "FINGERPRINT", string.Empty },
                { "UNITS", string.Empty },
                { "TRANSTYPE", 105 }
            };
            dataModel = new BaseModelData();
            var result = dataModel.QueryProcedureForDataTable(procedure, parameters);
            ViewBag.Title = (WorkerStatus)statusId;
            var model = Converter<Worker>.DataTableToObject(result);
            return View("Workers/StatusWorkers", model);
        }
        public ActionResult DisabledWorkers()
        {
            return View("Workers/DisabledWorkers");
        }
        public ActionResult FingerPrint(Worker worker)
        {
            return View("Workers/FingerPrint", worker);
        }
        public ActionResult Logs()
        {
            dataModel = new BaseModelData();
            var res = dataModel.QueryProcedureForDataTable("spLogs", new Dictionary<string, object>
            {
                { "ID", 0 },
                { "WORKERID", 0 },
                { "SIGNIN", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "SIGNOUT", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "TAGNO", 0 },
                { "TAGCATEGORY", string.Empty },
                { "TRANSTYPE", 106}
            });

            var model = Converter<Logs>.DataTableToObject(res);
            return View("Logs/Logs", model);
        }
        public ActionResult LogDetails(int Id)
        {
            dataModel = new BaseModelData();
            var res = dataModel.QueryProcedureForDataTable("spLogs", new Dictionary<string, object>
            {
                { "ID", Id },
                { "WORKERID", 0 },
                { "SIGNIN", string.Empty },
                { "SIGNOUT", string.Empty },
                { "TAGNO", 0 },
                { "TAGCATEGORY", string.Empty },
                { "TRANSTYPE", 104}
            });

            var model = Converter<Logs>.DataTableToObject(res);
            return View("Logs/LogDetails", model);
        }
        public ActionResult Settings()
        {
            var procedure = "spSettings";
            var parameters = new Dictionary<string, object>
            {
                { "SID", 1000},
                { "ACTIONVALUE", 0},
                { "ACTIONPERIOD", 0},
                { "STATUS", 0},
                { "FREQUENCY", 0},
                { "NAME", string.Empty},
                 { "LASTRUN", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "NEXTRUN", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "TRANSTYPE", 100}
            };
            dataModel = new BaseModelData();
            var result = dataModel.QueryProcedureForDataTable(procedure, parameters);
            var model = Converter<Settings>.DataTableToObject(result);
            return View("Settings/Settings", model[0]);
        }

        public ActionResult Tester()
        {
            var procedure = "spTestering";
            var parameters = new Dictionary<string, object>
            {
                {"NAME", "Nektunes" },
                {"NUMBER", 103 },
                {"WORD", "My number is 103" }
            };
            dataModel = new BaseModelData();
            var result = dataModel.QueryProcedureForDataTable(procedure, parameters);
            var testers = new List<Tester>();
            testers = Converter<Tester>.DataTableToObject(result);

            return View("Tester", testers);
        }

        #endregion

        #region Utilities
        [HttpPost]
        public ActionResult AddUnit(Unit unit)
        {
            var procedure = "spUnits";
            var parameters = new Dictionary<string, object>
            {
                {"ID", unit.Id },
                {"RESPONSIBILITY", unit.Responsibilities },
                {"UNITS", string.Empty },
                {"NAME", unit.Name },
                {"LEADER", unit.Leader },
                {"OVERVIEW", unit.Overview },
                { "TRANSTYPE", 101 }
            };
            dataModel = new BaseModelData();
            var result = dataModel.QueryProcedureForDataTable(procedure, parameters);
            ViewBag.Message = result.Rows.Count > 0 ? "Created" : "Not Created";
            return View("Units/AddUnit");
        }

        [HttpPost]
        public ActionResult EditUnit(Unit unit)
        {
            var procedure = "spUnits";
            var parameters = new Dictionary<string, object>
            {
                {"ID", unit.Id },
                {"RESPONSIBILITY", unit.Responsibilities },
                {"UNITS", string.Empty },
                {"NAME", unit.Name },
                {"LEADER", unit.Leader },
                {"OVERVIEW", unit.Overview },
                { "TRANSTYPE", 103 }
            };
            dataModel = new BaseModelData();
            var result = dataModel.QueryProcedureForDataTable(procedure, parameters);
            ViewBag.Message = result.Rows.Count > 0 ? "Created" : "Not Created";
            return View("Units/AddUnit");
        }

        [HttpPost]
        public ActionResult AddWorker(FormCollection formval, Worker worker)
        {
            var procedure = "spWorkers";
            var units = formval["units"];
            var parameters = new Dictionary<string, object>
            {
                { "ID", worker.Id },
                { "TITLE", worker.Title ?? string.Empty },
                { "FIRSTNAME", worker.Firstname },
                { "MIDNAME", worker.Midname ?? string.Empty },
                { "LASTNAME", worker.Lastname },
                { "PHONE", worker.Phone },
                { "EMAIL", worker.Email ?? string.Empty },
                { "ADDRESS", worker.Address ?? string.Empty },
                { "GENDER", worker.Gender },
                { "STATUS", (int)WorkerStatus.Active },
                { "ROLE", worker.Role },
                { "FINGERPRINT", string.Empty },
                { "UNITS", units ?? string.Empty },
                { "TRANSTYPE", 101 }
            };
           
            dataModel = new BaseModelData();
            var workers = dataModel.QueryProcedureForDataTable(procedure, parameters);
            ViewBag.Message = workers.Rows.Count > 0 ? "Created" : "Not Created";
            
            if (ViewBag.Message == "Created")
                return View("Workers/FingerPrint", workers);
           
            return RedirectToAction("AddWorker");
        }

        [HttpPost]
        public ActionResult EditWorker(FormCollection formval, Worker worker)
        {
            var procedure = "spWorkers";
            var units = formval["units"].Trim(',');
            var parameters = new Dictionary<string, object>
            {
                { "ID", worker.Id },
                { "TITLE", worker.Title ?? string.Empty },
                { "FIRSTNAME", worker.Firstname },
                { "MIDNAME", worker.Midname ?? string.Empty },
                { "LASTNAME", worker.Lastname },
                { "PHONE", worker.Phone },
                { "EMAIL", worker.Email ?? string.Empty },
                { "ADDRESS", worker.Address ?? string.Empty },
                { "GENDER", worker.Gender },
                { "STATUS", (int)WorkerStatus.Active },
                { "ROLE", worker.Role },
                { "FINGERPRINT", string.Empty },
                { "UNITS", units ?? string.Empty },
                { "TRANSTYPE", 103 }
            };
            dataModel = new BaseModelData();
            var workers = dataModel.QueryProcedureForDataTable(procedure, parameters);
            ViewBag.Message = workers.Rows.Count > 0 ? "Updated" : "Not Updated";
            return RedirectToAction("EditWorker", worker.Id);
        }

        [HttpPost]
        public ActionResult FingerPrintUpload(Worker worker)
        {
            var procedure = "spWorkers";
            var parameters = new Dictionary<string, object>
            {
                { "ID", worker.Id },
                { "TITLE", string.Empty },
                { "FIRSTNAME", string.Empty },
                { "MIDNAME", string.Empty },
                { "LASTNAME", string.Empty },
                { "PHONE", string.Empty },
                { "EMAIL", string.Empty },
                { "ADDRESS", string.Empty },
                { "GENDER", string.Empty },
                { "STATUS", 0 },
                { "ROLE", 0 },
                { "FINGERPRINT", worker.FingerPrint },
                { "UNITS", string.Empty },
                { "TRANSTYPE", 104 }
            };
            dataModel = new BaseModelData();
            var workers = dataModel.QueryProcedureForDataTable(procedure, parameters);
            ViewBag.Message = workers.Rows.Count > 0 ? "Created" : "Not Created";
            return RedirectToAction("EditWorker", worker.Id);

            #endregion
        }

        [HttpPost]
        public ActionResult Settings(Settings settings)
        {
            var status = settings.Status == "ON" ? 1 : 0;
            var procedure = "spSettings";
            var parameters = new Dictionary<string, object>
            {
                { "SID", 1000},
                { "ACTIONVALUE", settings.Action},
                { "ACTIONPERIOD", settings.ActionPeriod},
                { "STATUS", status },
                { "FREQUENCY", settings.Frequency },
                { "NAME", string.Empty},
                { "LASTRUN", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "NEXTRUN", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "TRANSTYPE", 102}
            };
            dataModel = new BaseModelData();
            var result = dataModel.QueryProcedureForDataTable(procedure, parameters);
            //var model = Converter<Settings>.DataTableToObject(result);
            return RedirectToAction("Settings");
        }

    }
}