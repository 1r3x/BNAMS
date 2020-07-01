using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BNAMS.Entities;
using BNAMS.Entities.ViewModels;
using BNAMS.Manager.Common;
using BNAMS.Manager.Interface;
using BNAMS.Manager.Manager;

namespace BNAMS.Controllers
{
    public class SetGunAmmoMaintainceController : Controller
    {
        private ISetGunAmmoMaintaince _aManager;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public SetGunAmmoMaintainceController()
        {
            _commonCode=new CommonManager();
            _aManager = new SetGunAmmoMaintainceManager();
            _db = new SmartRecordEntities();
        }


        // GET: SetGunAmmoMaintaince
        public ActionResult Index()
        {
            const string menuName = "SetGunAmmoMaintaince";
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


        // SET: SetGunAmmoMaintaince/CreateGunAmmoMaintaince
        public JsonResult CreateGunAmmoMaintaince(SetForMaintainceViewModel aObj)
        {

            var data = _aManager.CreateSetGunAmmoMaintaince(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: SetGunAmmoMaintaince/GetAllGunAmmoMaintaince
        public JsonResult GetAllGunAmmoMaintaince()
        {
            var data = _aManager.GetAllSetGunAmmoMaintaince();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: SetGunAmmoMaintaince/LoadRegistrationNo
        public JsonResult LoadRegistrationNo(string weaponType)
        {
            var data = _aManager.LoadRegistrationNo(weaponType);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: SetGunAmmoMaintaince/LoadWeaponDetails
        public JsonResult LoadWeaponDetails(string weaponId)
        {
            var data = _aManager.LoadWeaponDetails(weaponId);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: SetGunAmmoMaintaince/LoadDepot
        public JsonResult LoadDepot()
        {
            var data = _aManager.LoadDepot();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: SetGunAmmoMaintaince/LoadWareHouseUnderDepotId
        public JsonResult LoadWareHouseUnderDepotId(string depotId)
        {
            var data = _aManager.LoadWareHouseUnderDepotId(depotId);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: SetGunAmmoMaintaince/LoadShelfUnderWareHouseId
        public JsonResult LoadShelfUnderWareHouseId(string warehouseId)
        {
            var data = _aManager.LoadShelfUnderWareHouseId(warehouseId);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: SetGunAmmoMaintaince/LoadRowUnderWareHouseId
        public JsonResult LoadRowUnderWareHouseId(string warehouseId)
        {
            var data = _aManager.LoadRowUnderWareHouseId(warehouseId);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: SetGunAmmoMaintaince/LoadMaintainceType
        public JsonResult LoadMaintainceType()
        {
            var data = _aManager.LoadMaintainceType();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: SetGunAmmoMaintaince/GetYearForDropDown
        public JsonResult GetYearForDropDown()
        {
            var data = _commonCode.GetYearForDropDown();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }


    }
}