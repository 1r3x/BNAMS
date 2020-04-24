using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BNAMS.Entities;
using BNAMS.Manager.Common;
using BNAMS.Manager.Interface;
using BNAMS.Manager.Manager;

namespace BNAMS.Controllers
{
    public class GunAmmoMaintainceController : Controller
    {
        private IGunAmmoMaintaince _aManager;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public GunAmmoMaintainceController()
        {
            _commonCode=new CommonManager();
            _aManager = new GunAmmoMaintainceManager();
            _db = new SmartRecordEntities();
        }


        // GET: GunAmmoMaintaince
        public ActionResult Index()
        {
            return View();
        }


        // SET: GunAmmoMaintaince/CreateGunAmmoMaintaince
        public JsonResult CreateGunAmmoMaintaince(I_MaintenanceInfo aObj)
        {

            var data = _aManager.CreateGunAmmoMaintaince(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: GunAmmoMaintaince/GetAllGunAmmoMaintaince
        public JsonResult GetAllGunAmmoMaintaince()
        {
            var data = _aManager.GetAllGunAmmoMaintaince();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: GunAmmoMaintaince/LoadRegistrationNo
        public JsonResult LoadRegistrationNo(string weaponType)
        {
            var data = _aManager.LoadRegistrationNo(weaponType);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: GunAmmoMaintaince/LoadWeaponDetails
        public JsonResult LoadWeaponDetails(string weaponId)
        {
            var data = _aManager.LoadWeaponDetails(weaponId);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: GunAmmoMaintaince/LoadDepot
        public JsonResult LoadDepot()
        {
            var data = _aManager.LoadDepot();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: GunAmmoMaintaince/LoadWareHouseUnderDepotId
        public JsonResult LoadWareHouseUnderDepotId(string depotId)
        {
            var data = _aManager.LoadWareHouseUnderDepotId(depotId);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: GunAmmoMaintaince/LoadShelfUnderWareHouseId
        public JsonResult LoadShelfUnderWareHouseId(string warehouseId)
        {
            var data = _aManager.LoadShelfUnderWareHouseId(warehouseId);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: GunAmmoMaintaince/LoadRowUnderWareHouseId
        public JsonResult LoadRowUnderWareHouseId(string warehouseId)
        {
            var data = _aManager.LoadRowUnderWareHouseId(warehouseId);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: GunAmmoMaintaince/LoadMaintainceType
        public JsonResult LoadMaintainceType()
        {
            var data = _aManager.LoadMaintainceType();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: GunAmmoMaintaince/GetYearForDropDown
        public JsonResult GetYearForDropDown()
        {
            var data = _commonCode.GetYearForDropDown();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }


    }
}