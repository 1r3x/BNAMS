using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SR.Controllers.login;
using SR.Entities;
using SR.Manager;
using SR.Manager.Interface;
using SR.Manager.Manager;

namespace SR.Controllers
{
    [Authorization]
    public class RoleWiseMenuController : Controller
    {
        private IRoleWiseMenu _aManager;

        public RoleWiseMenuController()
        {
            _aManager = new RoleWiseMenuManger();
        }

        // GET: RoleWiseMenu/GetAllMenuByRoleId
        public JsonResult GetAllMenuByRoleId(int roleId)
        {
            var data = _aManager.GetAllMenuByRoleId(roleId);
            var redableData = data.Data.ToString();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }


        // GET: RoleWiseMenu/LoadSessionForMenu
        public object LoadSessionForMenu()
        {
            var data= GetAllMenuByRoleId(Convert.ToInt32(HttpContext.Session["roleId"]));
            Session["roleWiseMenu"] = GetAllMenuByRoleId(Convert.ToInt32(HttpContext.Session["roleId"]));
            return Session["roleWiseMenu"];
        }

        
    }
}