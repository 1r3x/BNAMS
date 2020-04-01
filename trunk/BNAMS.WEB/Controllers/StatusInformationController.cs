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
    public class StatusInformationController : Controller
    {
        private IStatusInformationSetup _aManager;

        public StatusInformationController()
        {
            _aManager = new StatusInformationSetipManager();
        }
        
        // GET: StatusInformation
        public ActionResult Index()
        {
            return View();
        }

        // GET: StatusInformation/CreateStatusInformationSetup
        public JsonResult CreateStatusInformationSetup(M_StatusInformation aObj)
        {
            var data = _aManager.CreateStatusInformationSetup(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // SET: StatusInformation/IsDuplicate
        public JsonResult IsDuplicate(M_StatusInformation aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: StatusInformation/GetAllStatusInformationSetup
        public JsonResult GetAllStatusInformationSetup()
        {
            var data = _aManager.GetAllStatusInformationSetup();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

    }
}