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
        private readonly SmartRecordEntities _db;

        public FiscalYearSetupController()
        {
            _aManager = new FiscalYearSetupManager();
            _db = new SmartRecordEntities();
        }


        // GET: FiscalYearSetup
        public ActionResult Index()
        {
            const string menuName = "FiscalYearSetup";
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