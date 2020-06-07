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
    public class CompositeCodeMasterController : Controller
    {
        private ICompositeCodeMaster _aManager;
        private readonly SmartRecordEntities _db;

        public CompositeCodeMasterController()
        {
            _aManager = new CompositeCodeManager();
            _db = new SmartRecordEntities();
        }

        // GET: CompositeCodeMaster
        public ActionResult Index()
        {
            const string menuName = "CompositeCodeMaster";
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


        // GET: CompositeCodeMaster/CreateCompositeCodeMasterSetup
        public JsonResult CreateCompositeCodeMasterSetup(M_Composite aObj)
        {
            var data = _aManager.CreateCompositeCodeMasterSetup(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // SET: CompositeCodeMaster/IsDuplicate
        public JsonResult IsDuplicate(M_Composite aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: CompositeCodeMaster/GetAllCompositeCodeMasterSetup
        public JsonResult GetAllCompositeCodeMasterSetup()
        {
            var data = _aManager.GetAllCompositeCodeMasterSetup();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }





    }
}