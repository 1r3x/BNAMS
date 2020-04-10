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
    public class StatusInformationController : Controller
    {
        private IStatusInformationSetup _aManager;
        private readonly SmartRecordEntities _db;

        public StatusInformationController()
        {
            _aManager = new StatusInformationSetipManager();
            _db = new SmartRecordEntities();
        }
        
        // GET: StatusInformation
        public ActionResult Index()
        {
            const string menuName = "StatusInformation";
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

        // GET: StatusInformation/CreateStatusInformationSetup
        public JsonResult CreateStatusInformationSetup(M_StatusInformation aObj)
        {
            var data = _aManager.CreateStatusInformationSetup(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // SET: StatusInformation/IsDuplicate
        public JsonResult IsDuplicate(M_StatusInformation aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: StatusInformation/GetAllStatusInformationSetup
        public JsonResult GetAllStatusInformationSetup()
        {
            var data = _aManager.GetAllStatusInformationSetup();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

    }
}