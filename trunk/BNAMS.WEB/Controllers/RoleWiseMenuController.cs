using System;
using System.Web.Mvc;
using BNAMS.Manager.Interface;
using BNAMS.Manager.Manager;
using SR.Controllers.login;

namespace BNAMS.Controllers
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