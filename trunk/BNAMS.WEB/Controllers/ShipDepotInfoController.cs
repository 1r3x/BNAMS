﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BNAMS.Entities;
using BNAMS.Manager.Interface;
using BNAMS.Manager.Manager;

namespace BNAMS.Controllers
{
    public class ShipDepotInfoController : Controller
    {

        private IShipOrDepotSetup _aManager;
        private readonly SmartRecordEntities _db;

        public ShipDepotInfoController()
        {
            _aManager = new ShipOrDepotManager();
            _db = new SmartRecordEntities();
        }


        // GET: ShipDepotInfo
        public ActionResult Index()
        {
            const string menuName = "ShipDepotInfo";
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

        // GET: ShipDepotInfo/CreateShipOrDepotSetup
        public JsonResult CreateShipOrDepotSetup(O_ShipOrDepotInfo aObj)
        {
            var data = _aManager.CreateShipOrDepotSetup(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // SET: ShipDepotInfo/IsDuplicate
        public JsonResult IsDuplicate(O_ShipOrDepotInfo aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: ShipDepotInfo/GetAllShipOrDepotSetup
        public JsonResult GetAllShipOrDepotSetup()
        {
            var data = _aManager.GetAllShipOrDepotSetup();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: ShipDepotInfo/LoadCapbilityOfWeapons
        public JsonResult LoadCapbilityOfWeapons()
        {
            var data = _aManager.LoadCapbilityOfWeapons();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: ShipDepotInfo/LoadShipOrdepoType
        public JsonResult LoadShipOrdepoType()
        {
            var data = _aManager.LoadShipOrdepoType();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: ShipDepotInfo/LoadShipOrdepotCategory
        public JsonResult LoadShipOrdepotCategory()
        {
            var data = _aManager.LoadShipOrdepotCategory();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: ShipDepotInfo/LoadAdminAuth
        public JsonResult LoadAdminAuth()
        {
            var data = _aManager.LoadAdminAuth();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }


    }

}