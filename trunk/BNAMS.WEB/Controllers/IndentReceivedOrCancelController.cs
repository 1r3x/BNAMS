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
    public class IndentReceivedOrCancelController : Controller
    {
        private IIndentReceiveOrCancel _aManager;
        private readonly SmartRecordEntities _db;

        public IndentReceivedOrCancelController()
        {
            _aManager = new IndentReceiveOrCancelManager();
            _db = new SmartRecordEntities();
        }


        // GET: IndentReceivedOrCancel
        public ActionResult Index()
        {
            const string menuName = "IndentReceivedOrCancel";
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

        // GET: IndentReceivedOrCancel/CreateIndentReceive
        public JsonResult CreateIndentReceive(I_Indent aObj)
        {
            var data = _aManager.CreateIndentReceive(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: IndentReceivedOrCancel/CreateIndentCancel
        public JsonResult CreateIndentCancel(I_Indent aObj)
        {
            var data = _aManager.CreateIndentCancel(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: IndentReceivedOrCancel/GetAllIndent
        public JsonResult GetAllIndent()
        {
            var data = _aManager.GetAllIndent();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: IndentReceivedOrCancel/LoadAllItem
        public JsonResult LoadAllItem()
        {
            var data = _aManager.LoadAllItem();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

    }
}