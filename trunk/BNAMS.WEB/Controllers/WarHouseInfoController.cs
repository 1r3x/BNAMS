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
    public class WarHouseInfoController : Controller
    {
        private IWareHouseInfo _aManager;
        private readonly SmartRecordEntities _db;

        public WarHouseInfoController()
        {
            _aManager = new WareHouseManager();
            _db = new SmartRecordEntities();
        }

        // GET: WarHouseInfo
        public ActionResult Index()
        {
            const string menuName = "WarHouseInfo";
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


        // GET: WarHouseInfo/CreateWareHouse
        public JsonResult CreateWareHouse(O_WareHouse aObj)
        {
            var data = _aManager.CreateWareHouse(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // SET: WarHouseInfo/IsDuplicate
        public JsonResult IsDuplicate(O_WareHouse aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: WarHouseInfo/GetAllWareHouse
        public JsonResult GetAllWareHouse()
        {
            var data = _aManager.GetAllWareHouse();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: WarHouseInfo/LoadUnitDepotShip
        public JsonResult LoadUnitDepotShip()
        {
            var data = _aManager.LoadUnitDepotShip();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: WarHouseInfo/LoadWareHouseType
        public JsonResult LoadWareHouseType()
        {
            var data = _aManager.LoadWareHouseType();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

    }
}