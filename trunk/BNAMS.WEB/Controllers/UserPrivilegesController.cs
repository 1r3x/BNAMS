using System.Collections.Generic;
using System.Web.Mvc;
using BNAMS.Controllers.login;
using BNAMS.Entities;
using BNAMS.Manager.Interface;
using BNAMS.Manager.Manager;

namespace BNAMS.Controllers
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