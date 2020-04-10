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
    public class GunModelTypeController : Controller
    {

        private IGunModel _aManager;
        private readonly SmartRecordEntities _db;

        public GunModelTypeController()
        {
            _aManager = new GunModelTypeSetupManager();
            _db = new SmartRecordEntities();
        }

        // GET: GunModelType
        public ActionResult Index()
        {
            const string menuName = "GunModelType";
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


        // GET: GunModelType/CreateGunModelTypeSetup
        public JsonResult CreateGunModelTypeSetup(M_WeaponsModelType aObj)
        {
            var data = _aManager.CreateGunModelTypeSetup(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // SET: GunModelType/IsDuplicate
        public JsonResult IsDuplicate(M_WeaponsModelType aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: GunModelType/GetAllGunModelTypeSetup
        public JsonResult GetAllGunModelTypeSetup()
        {
            var data = _aManager.GetAllGunModelTypeSetup();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: GunModelType/LoadWeaponsType
        public JsonResult LoadWeaponsType()
        {
            var data = _aManager.LoadWeaponsType();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }


    }
}