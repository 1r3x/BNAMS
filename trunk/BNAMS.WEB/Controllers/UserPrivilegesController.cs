using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SR.Controllers.login;
using SR.Entities;
using SR.Manager.Interface;
using SR.Manager.Manager;

namespace SR.Controllers
{
    [Authorization]
    public class UserPrivilegesController : Controller
    {
        private IUserPrivileges _aManager;

        public UserPrivilegesController()
        {
            _aManager = new UserPrivilegesManager();
        }
        // GET: UserPrivileges
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserPrivileges/CreateUserPrivileges
        public JsonResult CreateUserPrivileges(List<UserPermission> aObj)
        {
            var data = _aManager.CreateUserPrivileges(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: UserPrivileges/GetAllRoleType
        public JsonResult GetAllRoleType()
        {
            var data = _aManager.GetAllRoleType();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: UserPrivileges/GetAllMenuAndSubMenu
        public JsonResult GetAllMenuAndSubMenu()
        {
            var data = _aManager.GetAllMenuAndSubmenu();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }


        //for selected the selected checkbox
        // GET: UserPrivileges/GetAllSelectedMenuAndSubMenu
        public JsonResult GetAllSelectedMenuAndSubMenu(int roleId)
        {
            var data = _aManager.GetAllSelectedMenuAndSubmenu(roleId);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
    }
}