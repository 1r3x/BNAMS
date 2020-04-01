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
    public class CapabilityOfWeaponsController : Controller
    {

        private ICapabilityOfWaeponsSetup _aManager;

        public CapabilityOfWeaponsController()
        {
            _aManager = new CapabilityOfWaeponsSetupManager();
        }

        // GET: CapabilityOfWeapons
        public ActionResult Index()
        {
            return View();
        }


        // GET: CapabilityOfWeapons/CreateCapabilityOfWeapons
        public JsonResult CreateCapabilityOfWeapons(M_CapabilityOfWeapons aObj)
        {
            var data = _aManager.CreateCapabilityOfWaeponsSetup(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // SET: CapabilityOfWeapons/IsDuplicate
        public JsonResult IsDuplicate(M_CapabilityOfWeapons aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: CapabilityOfWeapons/LoadAllCapabilityOfWeapons
        public JsonResult LoadAllCapabilityOfWeapons()
        {
            var data = _aManager.GetAllCapabilityOfWaeponsSetup();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }


    }
}