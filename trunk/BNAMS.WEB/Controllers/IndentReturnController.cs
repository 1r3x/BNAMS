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
    public class IndentReturnController : Controller
    {
        private IIndentReturn _aManager;
        private readonly SmartRecordEntities _db;

        public IndentReturnController()
        {
            _aManager = new IndentReturnManager();
            _db=new SmartRecordEntities();
        }


        // GET: IndentReturn
        public ActionResult Index()
        {
            //return View();
            const string menuName = "IndentReturn";
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

        // GET: IndentReturn/CreateIndentReturn
        public JsonResult CreateIndentReturn(I_Indent aObj)
        {
            var data = _aManager.CreateIndentReturn(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }



        // GET: IndentReturn/GetAllIndent
        public JsonResult GetAllIndent()
        {
            var data = _aManager.GetAllIndent();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: IndentReturn/LoadAllItem
        public JsonResult LoadAllItem()
        {
            var data = _aManager.LoadAllItem();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }





    }
}