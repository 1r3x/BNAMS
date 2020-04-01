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
    public class GunModelTypeController : Controller
    {

        private IGunModel _aManager;

        public GunModelTypeController()
        {
            _aManager = new GunModelTypeSetupManager();
        }

        // GET: GunModelType
        public ActionResult Index()
        {
            return View();
        }


        // GET: GunModelType/CreateGunModelTypeSetup
        public JsonResult CreateGunModelTypeSetup(M_GunModelType aObj)
        {
            var data = _aManager.CreateGunModelTypeSetup(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // SET: GunModelType/IsDuplicate
        public JsonResult IsDuplicate(M_GunModelType aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: GunModelType/GetAllGunModelTypeSetup
        public JsonResult GetAllGunModelTypeSetup()
        {
            var data = _aManager.GetAllGunModelTypeSetup();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }



    }
}