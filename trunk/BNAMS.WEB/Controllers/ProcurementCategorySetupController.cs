using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BNAMS.Entities;
using BNAMS.Manager.Interface;
using BNAMS.Manager.Manager;

namespace BNAMS.Controllers
{
    public class ProcurementCategorySetupController : Controller
    {
        private IProcurementSetup _aManager;

        public ProcurementCategorySetupController()
        {
            _aManager = new ProcurementSetupManager();
        }
        // GET: ProcurementCategorySetup
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProcurementCategorySetup/CreateProcurementSetup
        public JsonResult CreateProcurementSetup(M_ProcurementCategory aObj)
        {
            var data = _aManager.CreateProcurementSetup(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // SET: ProcurementCategorySetup/IsDuplicate
        public JsonResult IsDuplicate(M_ProcurementCategory aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: ProcurementCategorySetup/GetAllProcurementSetup
        public JsonResult GetAllProcurementSetup()
        {
            var data = _aManager.GetAllProcurementSetup();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

    }
}