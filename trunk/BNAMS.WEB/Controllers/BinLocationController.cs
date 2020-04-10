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
    public class BinLocationController : Controller
    {
        private IBinLocation _aManager;
        private readonly SmartRecordEntities _db;

        public BinLocationController()
        {
            _aManager = new BinLocationManager();
            _db = new SmartRecordEntities();
        }

        // GET: BinLocation
        public ActionResult Index()
        {
            const string menuName = "BinLocation";
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

        // GET: BinLocation/CreateBinLocation
        public JsonResult CreateBinLocation(I_BinLocation aObj)
        {
            var data = _aManager.CreateBinLocation(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: BinLocation/GetAllBinLocation
        public JsonResult GetAllBinLocation()
        {
            var data = _aManager.GetAllBinLocation();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: BinLocation/LoadProductCategory
        public JsonResult LoadProductCategory()
        {
            var data = _aManager.LoadProductCategory();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: BinLocation/LoadWareHouseByCode
        public JsonResult LoadWareHouseByCode(string wareHouseCode)
        {
            var data = _aManager.LoadWareHouseByCode(wareHouseCode);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

    }
}