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
    public class LocalAgentSetupController : Controller
    {
        private ILocalAgent _aManager;

        public LocalAgentSetupController()
        {
            _aManager = new LocalAgentSetupManager();
        }

        // GET: LocalAgentSetup
        public ActionResult Index()
        {
            return View();
        }

        // GET: LocalAgentSetup/CreateLocalAgentSetup
        public JsonResult CreateLocalAgentSetup(M_LocalAgent aObj)
        {
            var data = _aManager.CreateLocalAgentSetup(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // SET: LocalAgentSetup/IsDuplicate
        public JsonResult IsDuplicate(M_LocalAgent aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: LocalAgentSetup/GetAllLocalAgentSetup
        public JsonResult GetAllLocalAgentSetup()
        {
            var data = _aManager.GetAllLocalAgentSetup();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: LocalAgentSetup/LoadCountry
        public JsonResult LoadCountry()
        {
            var data = _aManager.LoadCountry();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
    }
}