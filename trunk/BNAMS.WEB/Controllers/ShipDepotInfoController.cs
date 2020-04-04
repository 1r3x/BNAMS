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
    public class ShipDepotInfoController : Controller
    {

        private IShipOrDepotSetup _aManager;

        public ShipDepotInfoController()
        {
            _aManager = new ShipOrDepotManager();
        }


        // GET: ShipDepotInfo
        public ActionResult Index()
        {
            return View();
        }

        // GET: ShipDepotInfo/CreateShipOrDepotSetup
        public JsonResult CreateShipOrDepotSetup(O_ShipOrDepotInfo aObj)
        {
            var data = _aManager.CreateShipOrDepotSetup(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // SET: ShipDepotInfo/IsDuplicate
        public JsonResult IsDuplicate(O_ShipOrDepotInfo aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: ShipDepotInfo/GetAllShipOrDepotSetup
        public JsonResult GetAllShipOrDepotSetup()
        {
            var data = _aManager.GetAllShipOrDepotSetup();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: ShipDepotInfo/LoadCapbilityOfWeapons
        public JsonResult LoadCapbilityOfWeapons()
        {
            var data = _aManager.LoadCapbilityOfWeapons();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: ShipDepotInfo/LoadShipOrdepoType
        public JsonResult LoadShipOrdepoType()
        {
            var data = _aManager.LoadShipOrdepoType();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: ShipDepotInfo/LoadShipOrdepotCategory
        public JsonResult LoadShipOrdepotCategory()
        {
            var data = _aManager.LoadShipOrdepotCategory();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }



    }

}