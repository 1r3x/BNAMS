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
        private readonly SmartRecordEntities _db;

        public QuantitySetupController()
        {
            _aManager = new QuantitySetupManager();
            _db = new SmartRecordEntities();
        }

        // GET: QuantitySetup
        public ActionResult Index()
        {
            const string menuName = "QuantitySetup";
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