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
    public class RoleSetupController : Controller
    {
        private IRoleSetup _aManager;

        public RoleSetupController()
        {
            _aManager = new RoleSetupManager();
        }

        // GET: RoleSetup
        public ActionResult Index()
        {
            return View();
        }

        // GET: RoleSetup/CreateRole
        public JsonResult CreateRole(UserRole aObj)
        {
            var data = _aManager.CreateRole(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // SET: RoleSetup/IsDuplicate
        public JsonResult IsDuplicate(UserRole aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: RoleSetup/LoadAllRole
        public JsonResult LoadAllRole()
        {
            var data = _aManager.GetAllRole();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }


    }
}