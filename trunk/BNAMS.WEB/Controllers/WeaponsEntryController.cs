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
    public class WeaponsEntryController : Controller
    {
        private IWeaponsEntry _aManager;
        private readonly CommonManager _commonCode;
        private readonly SmartRecordEntities _db;

        public WeaponsEntryController()
        {
            _aManager = new WeaponsEntryManager();
            _db = new SmartRecordEntities();
            _commonCode = new CommonManager();
        }

        // GET: WeaponsEntry
        public ActionResult Index()
        {
            const string menuName = "WeaponsEntry";
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
        // GET: WeaponsEntry/CreateBinLocation
        public JsonResult CreateWeaponsItem(I_WeaponsInfo aObj)
        {
            Session["WeaponsTypeId"] = aObj.WeaponsTypeId;
            Session["NameOfWeaponsId"] = aObj.NameOfWeaponsId;
            var data = _aManager.CreateWeaponsItem(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // SET: WeaponsEntry/UploadFiles
        [HttpPost]
        public ActionResult UploadFiles()
        {
            if (Request.Files.Count > 0)
            {
                var fileName = (string)System.Web.HttpContext.Current.Session["directorateId"]+
                               (string)System.Web.HttpContext.Current.Session["WeaponsTypeId"] +
                               (string)System.Web.HttpContext.Current.Session["NameOfWeaponsId"];
                var modifiedFile = fileName.Replace(@"/", "");
                var path = Server.MapPath("~/Uploads/");
                var files = Request.Files;
                for (var i = 0; i < files.Count; i++)
                {
                    var file = files[i];

                    file?.SaveAs(path + file.FileName.Replace(file.FileName, modifiedFile + file.ContentType).Replace(@"/", "."));
                }
                return Json(files.Count + " Files Uploaded!");
            }
            else
            {
                return Json("No files selected.");
            }
        }

        // GET: WeaponsEntry/GetAllWeaponsByTypeId
        public JsonResult GetAllWeaponsByTypeId(string weaponsTypeId)
        {
            var data = _aManager.GetWeaponsByWeaponType(weaponsTypeId);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: WeaponsEntry/DeleteWeapon
        public JsonResult DeleteWeapon(string weaponsInfoId)
        {
            var data = _aManager.DelWeaponsInfo(weaponsInfoId);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }


        // GET: WeaponsEntry/LoadWeaponsType
        public JsonResult LoadWeaponsType()
        {
            var data = _aManager.LoadWeaponsType();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: WeaponsEntry/LoadWeaponsByType
        public JsonResult LoadWeaponsByType(string weaponTypeId)
        {
            var data = _aManager.LoadWeaponsByType(weaponTypeId);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: WeaponsEntry/LoadWeaponModelByWeaponId
        public JsonResult LoadWeaponModelByWeaponId(string weaponTypeId)
        {
            var data = _aManager.LoadWeaponModelByWeaponId(weaponTypeId);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: WeaponsEntry/LoadFiscalYear
        public JsonResult LoadFiscalYear()
        {
            var data = _aManager.LoadFiscalYear();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: WeaponsEntry/LoadCountry
        public JsonResult LoadCountry()
        {
            var data = _aManager.LoadCountry();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: WeaponsEntry/LoadPriceType
        public JsonResult LoadPriceType()
        {
            var data = _aManager.LoadPriceType();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: WeaponsEntry/LoadLocalAgent
        public JsonResult LoadLocalAgent()
        {
            var data = _aManager.LoadLocalAgent();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: WeaponsEntry/LoadPrincipalAgent
        public JsonResult LoadPrincipalAgent()
        {
            var data = _aManager.LoadPrincipalAgent();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: WeaponsEntry/LoadManuAgent
        public JsonResult LoadManuAgent()
        {
            var data = _aManager.LoadManuAgent();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: WeaponsEntry/LoadQuantityCategory
        public JsonResult LoadQuantityCategory()
        {
            var data = _aManager.LoadQuantityCategory();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: WeaponsEntry/LoadDepot
        public JsonResult LoadDepot()
        {
            var data = _aManager.LoadDepot();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        } 
        // GET: WeaponsEntry/LoadProcurementCategory
        public JsonResult LoadProcurementCategory()
        {
            var data = _aManager.LoadProcurementCategory();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: WeaponsEntry/LoadWareHouseByDepotId
        public JsonResult LoadWareHouseByDepotId(string depotId)
        {
            var data = _aManager.LoadWareHouseByDepotId(depotId);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        } 
        // GET: WeaponsEntry/LoadShelfNameByWraehouseId
        public JsonResult LoadShelfNameByWraehouseId(string warehouseId)
        {
            var data = _aManager.LoadShelfNameByWraehouseId(warehouseId);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: WeaponsEntry/LoadRowNameByWraehouseId
        public JsonResult LoadRowNameByWraehouseId(string warehouseId)
        {
            var data = _aManager.LoadRowNameByWraehouseId(warehouseId);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: WeaponsEntry/LoadStatus
        public JsonResult LoadStatus()
        {
            var data = _aManager.LoadStatus();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: WeaponsEntry/LoadYear
        public JsonResult LoadYear()
        {
            var data = _commonCode.GetYearForDropDown();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: WeaponsEntry/LoadMissilePreparationTime
        public JsonResult LoadMissilePreparationTime()
        {
            var data = _aManager.LoadPreparationTime();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
    }
}