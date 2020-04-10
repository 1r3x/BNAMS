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
    public class CapabilityOfWeaponsController : Controller
    {

        private ICapabilityOfWaeponsSetup _aManager;
        private readonly SmartRecordEntities _db;

        public CapabilityOfWeaponsController()
        {
            _aManager = new CapabilityOfWaeponsSetupManager();
            _db = new SmartRecordEntities();
        }

        // GET: CapabilityOfWeapons
        public ActionResult Index()
        {
            const string menuName = "CapabilityOfWeapons";
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


        // GET: CapabilityOfWeapons/CreateCapabilityOfWeapons
        public JsonResult CreateCapabilityOfWeapons(M_CapabilityOfWeapons aObj)
        {
            var data = _aManager.CreateCapabilityOfWaeponsSetup(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // SET: CapabilityOfWeapons/IsDuplicate
        public JsonResult IsDuplicate(M_CapabilityOfWeapons aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: CapabilityOfWeapons/LoadAllCapabilityOfWeapons
        public JsonResult LoadAllCapabilityOfWeapons()
        {
            var data = _aManager.GetAllCapabilityOfWaeponsSetup();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }


    }
}