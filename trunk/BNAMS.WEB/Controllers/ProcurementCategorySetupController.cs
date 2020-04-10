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
        private readonly SmartRecordEntities _db;

        public ProcurementCategorySetupController()
        {
            _aManager = new ProcurementSetupManager();
            _db = new SmartRecordEntities();
        }
        // GET: ProcurementCategorySetup
        public ActionResult Index()
        {
            const string menuName = "ProcurementCategorySetup";
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