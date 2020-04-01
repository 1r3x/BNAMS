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
    public class FiscalYearSetupController : Controller
    {
        private IFiscalYearSetup _aManager;

        public FiscalYearSetupController()
        {
            _aManager = new FiscalYearSetupManager();
        }


        // GET: FiscalYearSetup
        public ActionResult Index()
        {
            return View();
        }

        // GET: FiscalYearSetup/CreateFiscalYear
        public JsonResult CreateFiscalYear(M_FiscalYear aObj)
        {
            var data = _aManager.CreateFiscalYear(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // SET: FiscalYearSetup/IsDuplicate
        public JsonResult IsDuplicate(M_FiscalYear aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: FiscalYearSetup/LoadAllFiscalYear
        public JsonResult LoadAllFiscalYear()
        {
            var data = _aManager.GetAllFiscalYear();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }


    }
}