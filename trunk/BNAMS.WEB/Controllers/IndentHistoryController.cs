using BNAMS.Entities;
using BNAMS.Manager.Interface;
using BNAMS.Manager.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BNAMS.Controllers
{
    public class IndentHistoryController : Controller
    {
        private IIndentHistory _aManager;
        private readonly SmartRecordEntities _db;

        public IndentHistoryController()
        {
            _aManager = new IndentHistoryManger();
            _db = new SmartRecordEntities();
        }


        // GET: IndentHistory
        public ActionResult Index()
        {
            const string menuName = "IndentHistory";
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


        // GET: IndentHistory/GetAllIndentHistory
        public JsonResult GetAllIndentHistory(string weaponType,string weaponName,string weaponModel)
        {
            var data = _aManager.GetAllIndent(weaponType,weaponName,weaponModel);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

    }
}