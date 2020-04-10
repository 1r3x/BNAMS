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
    public class CountrySetupController : Controller
    {

        private ICountrySetup _aManager;
        private readonly SmartRecordEntities _db;

        public CountrySetupController()
        {
            _aManager = new CountrySetupManager();
            _db = new SmartRecordEntities();
        }


        // GET: CountrySetup
        public ActionResult Index()
        {
            const string menuName = "CountrySetup";
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


        // GET: CountrySetup/CreateCountrySetup
        public JsonResult CreateCountrySetup(M_Country aObj)
        {
            var data = _aManager.CreateCountrySetup(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // SET: CountrySetup/IsDuplicate
        public JsonResult IsDuplicate(M_Country aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: CountrySetup/GetAllCountrySetup
        public JsonResult GetAllCountrySetup()
        {
            var data = _aManager.GetAllCountrySetup();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

    }
}