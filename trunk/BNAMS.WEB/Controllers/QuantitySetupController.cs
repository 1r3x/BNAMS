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
    public class QuantitySetupController : Controller
    {

        private IQuantitySetup _aManager;

        public QuantitySetupController()
        {
            _aManager = new QuantitySetupManager();
        }

        // GET: QuantitySetup
        public ActionResult Index()
        {
            return View();
        }


        // GET: QuantitySetup/CreateQuantitySetup
        public JsonResult CreateQuantitySetup(M_QuantityCategory aObj)
        {
            var data = _aManager.CreateQuantitySetup(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // SET: QuantitySetup/IsDuplicate
        public JsonResult IsDuplicate(M_QuantityCategory aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: QuantitySetup/GetAllQuantitySetup
        public JsonResult GetAllQuantitySetup()
        {
            var data = _aManager.GetAllQuantitySetup();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
    }
}