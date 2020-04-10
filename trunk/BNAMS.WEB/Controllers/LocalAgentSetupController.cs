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
        private readonly SmartRecordEntities _db;

        public LocalAgentSetupController()
        {
            _aManager = new LocalAgentSetupManager();
            _db = new SmartRecordEntities();
        }

        // GET: LocalAgentSetup
        public ActionResult Index()
        {
            const string menuName = "LocalAgentSetup";
            var roleId = (int?)System.Web.HttpContext.Current.Session["roleId"];

            var menuId = (from a in _db.M_Menu
                where a.MenuUrl == menuName
                select a.Id).Single();


            var permission = (from a in _db.UserPermissions
                where a.RoleId == roleId && a.MenuId == menuId
                select new
                {
                    a.PermId
                }).Any();

            return permission ? (ActionResult)View() : RedirectToAction("Login", "Userlogins");
        }

        // GET: LocalAgentSetup/CreateLocalAgentSetup
        public JsonResult CreateLocalAgentSetup(M_Agent aObj)
        {
            var data = _aManager.CreateLocalAgentSetup(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // SET: LocalAgentSetup/IsDuplicate
        public JsonResult IsDuplicate(M_Agent aObj)
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
        // GET: LocalAgentSetup/LoadAgentType
        public JsonResult LoadAgentType()
        {
            var data = _aManager.LoadAgentType();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: LocalAgentSetup/LoadEstimationTypeType
        public JsonResult LoadEstimationTypeType()
        {
            var data = _aManager.LoadEstimationTypeType();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
    }
}