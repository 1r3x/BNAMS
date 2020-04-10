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
        private readonly SmartRecordEntities _db;

        public RoleSetupController()
        {
            _aManager = new RoleSetupManager();
            _db = new SmartRecordEntities();
        }

        // GET: RoleSetup
        public ActionResult Index()
        {
            const string menuName = "RoleSetup";
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

            return permission ? (ActionResult) View() : RedirectToAction("Login", "Userlogins");
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