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
    public class AuthoritySetupController : Controller
    {
        private IAuthoritySetup _aManager;
        private readonly SmartRecordEntities _db;

        public AuthoritySetupController()
        {
            _aManager = new AuthoritySetupManager();
            _db = new SmartRecordEntities();
        }
        
        // GET: AuthoritySetup
        public ActionResult Index()
        {
            const string menuName = "AuthoritySetup";
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

        // SET: AuthoritySetup/CreateAuthority
        public JsonResult CreateAuthority(M_Authorirty aObj)
        {
            var data = _aManager.CreateAuthority(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: AuthoritySetup/IsDuplicate
        public JsonResult IsDuplicate(M_Authorirty aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: AuthoritySetup/LoadAllAuthority
        public JsonResult LoadAllAuthority()
        {
            var data = _aManager.GetAllAuthority();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: AuthoritySetup/LoadAllArea
        public JsonResult LoadAllArea()
        {
            var data = _aManager.LoadArea();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

    }
}