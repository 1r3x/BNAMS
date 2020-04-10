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
    public class NameOfGunController : Controller
    {
        private INameOfGunSetup _aManager;
        private readonly SmartRecordEntities _db;

        public NameOfGunController()
        {
            _aManager = new NameOfGunSetupManager();
            _db = new SmartRecordEntities();
        }

        // GET: NameOfGun
        public ActionResult Index()
        {
            const string menuName = "NameOfGun";
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


        // GET: NameOfGun/CreateNameOfGunSetup
        public JsonResult CreateNameOfGunSetup(M_NameOfWeapon aObj)
        {
            var data = _aManager.CreateNameOfGunSetup(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // SET: NameOfGun/IsDuplicate
        public JsonResult IsDuplicate(M_NameOfWeapon aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: NameOfGun/GetAllNameOfGunSetup
        public JsonResult GetAllNameOfGunSetup()
        {
            var data = _aManager.GetAllNameOfGunSetup();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: NameOfGun/LoadWeaponsType
        public JsonResult LoadWeaponsType()
        {
            var data = _aManager.LoadWeaponsType();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
    }
}