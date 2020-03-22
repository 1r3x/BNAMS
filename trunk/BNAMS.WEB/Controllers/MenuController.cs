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
    public class MenuController : Controller
    {
        private IMenu _aManager;

        public MenuController()
        {
            _aManager = new MenuManager();
        }
        

        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        // SET: Manu/CreateMenu
        public JsonResult CreateMenu(M_Menu aObj)
        {
            var data = _aManager.CreateMenu(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Manu/GetAllMenu
        public JsonResult GetAllMenu()
        {
            var data = _aManager.GetAllMenu();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Manu/LoadAllMenu
        public JsonResult LoadAllMenu()
        {
            var data = _aManager.LoadParentMenu();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
    }
}