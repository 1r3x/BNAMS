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
    public class StatusAfterMaintainceController : Controller
    {
        private IStatusAfterMaintaince _aManager;
        private readonly SmartRecordEntities _db;

        public StatusAfterMaintainceController()
        {
            _aManager = new StatusAfterMaintainceManager();
            _db = new SmartRecordEntities();
        }

        // GET: StatusAfterMaintaince
        public ActionResult Index()
        {
            const string menuName = "StatusAfterMaintaince";
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

        // GET: StatusAfterMaintaince/CreateStatusAfterMaintaince
        public JsonResult CreateStatusAfterMaintaince(I_StatusAfterMaintaince aObj)
        {
            var data = _aManager.CreateStatusAfterMaintaince(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: StatusAfterMaintaince/GetAllStatusAfterMaintaince
        public JsonResult GetAllStatusAfterMaintaince()
        {
            var data = _aManager.GetAllStatusAfterMaintaince();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: StatusAfterMaintaince/LoadRegistrationNo
        public JsonResult LoadRegistrationNo()
        {
            var data = _aManager.LoadRegistrationNo();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: StatusAfterMaintaince/LoadMaintainceDetailsByRegistrationNo
        public JsonResult LoadMaintainceDetailsByRegistrationNo(string weaponsInfoId)
        {
            var data = _aManager.LoadMaintainceDetailsByRegistrationNo(weaponsInfoId);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: StatusAfterMaintaince/LoadStatus
        public JsonResult LoadStatus()
        {
            var data = _aManager.LoadStatus();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }


    }
}