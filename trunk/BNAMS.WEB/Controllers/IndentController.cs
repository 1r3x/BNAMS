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
    public class IndentController : Controller
    {
        private IIndent _aManager;
        private readonly SmartRecordEntities _db;

        public IndentController()
        {
            _aManager = new IndentManager();
            _db = new SmartRecordEntities();
        }


        // GET: Indent
        public ActionResult Index()
        {
            const string menuName = "Indent";
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



        // GET: Indent/CreateIndent
        public JsonResult CreateIndent(I_Indent aObj)
        {
            var data = _aManager.CreateIndent(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Indent/GetAllIndent
        public JsonResult GetAllIndent()
        {
            var data = _aManager.GetAllIndent();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Indent/LoadAllDepotAndShipForIndentFrom
        public JsonResult LoadAllDepotAndShipForIndentFrom()
        {
            var data = _aManager.LoadAllDepotAndShipForIndentFrom();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Indent/LoadAllDepotAndShipForIssue
        public JsonResult LoadAllDepotAndShipForIssue()
        {
            var data = _aManager.LoadAllDepotAndShipForIssue();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Indent/LoadItemCode
        public JsonResult LoadItemCode(string depotShipId)
        {
            var data = _aManager.LoadItemCode(depotShipId);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Indent/LoadItemDetails
        public JsonResult LoadItemDetails(string itemId)
        {
            var data = _aManager.LoadItemDetails(itemId);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Indent/LoadCompositCode
        public JsonResult LoadCompositCode()
        {
            var data = _aManager.LoadCompositCode();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }




        // GET: Indent/LoadCompositNameByCompositId
        public JsonResult LoadCompositNameByCompositId(string compositCodeId)
        {
            var data = _aManager.LoadCompositNameByCompositId(compositCodeId);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

       


        // GET: Indent/LoadIndentType
        public JsonResult LoadIndentType()
        {
            var data = _aManager.LoadIndentType();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Indent/CheckIsItAmmo
        public JsonResult CheckIsItAmmo(string itemId)
        {
            var data = _aManager.CheckIsItAmmo(itemId);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }




    }
}