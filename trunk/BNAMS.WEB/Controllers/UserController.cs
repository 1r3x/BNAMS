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
    public class UserController : Controller
    {
        private IUser _aManager;

        public UserController()
        {
            _aManager = new UserManager();
        }
        

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // SET: Manu/CreateUser
        public JsonResult CreateUser(UserLogin aObj)
        {
            var data = _aManager.CreateUser(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Manu/GetAllUser
        public JsonResult GetAllUser()
        {
            var data = _aManager.GetAllUser();
            var dataView = data.Data.ToString();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Manu/LoadAllUser
        public JsonResult LoadAllRole()
        {
            var data = _aManager.LoadUserRole();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
    }
}