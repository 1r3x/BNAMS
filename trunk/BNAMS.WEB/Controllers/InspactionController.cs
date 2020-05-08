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
    public class InspactionController : Controller
    {
        private IInspection _aManager;
        private readonly SmartRecordEntities _db;

        public InspactionController()
        {
            _aManager = new InspactionManager();
            _db = new SmartRecordEntities();
        }
        // GET: Inspaction
        public ActionResult Index()
        {
            const string menuName = "Inspaction";
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

        // GET: Inspaction/CreateInspection
        public JsonResult CreateInspection(W_Inspection aObj)
        {
            var data = _aManager.CreateInspection(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Inspaction/GetInspectionAll
        public JsonResult GetInspectionAll()
        {
            var data = _aManager.GetInspectionAll();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Inspaction/LoadDepot
        public JsonResult LoadDepot()
        {
            var data = _aManager.LoadDepot();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Inspaction/LoadItemType
        public JsonResult LoadItemType()
        {
            var data = _aManager.LoadItemType();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Inspaction/LoadLastMaintainceDate
        public JsonResult LoadLastMaintainceDate(string itemId)
        {
            var data = _aManager.LoadLastMaintainceDate(itemId);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Inspaction/LoadRegistrationNo
        public JsonResult LoadRegistrationNo(string itemTypeId,string depotId)
        {
            var data = _aManager.LoadRegistrationNo(itemTypeId,depotId);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Inspaction/LoadWeaponDetails
        public JsonResult LoadWeaponDetails(string itemId)
        {
            var data = _aManager.LoadWeaponDetails(itemId);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }


    }
}