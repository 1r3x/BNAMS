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
    public class NameOfGunController : Controller
    {
        private INameOfGunSetup _aManager;

        public NameOfGunController()
        {
            _aManager = new NameOfGunSetupManager();
        }

        // GET: NameOfGun
        public ActionResult Index()
        {
            return View();
        }


        // GET: NameOfGun/CreateNameOfGunSetup
        public JsonResult CreateNameOfGunSetup(M_NameOfGun aObj)
        {
            var data = _aManager.CreateNameOfGunSetup(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // SET: NameOfGun/IsDuplicate
        public JsonResult IsDuplicate(M_NameOfGun aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: NameOfGun/GetAllNameOfGunSetup
        public JsonResult GetAllNameOfGunSetup()
        {
            var data = _aManager.GetAllNameOfGunSetup();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
    }
}