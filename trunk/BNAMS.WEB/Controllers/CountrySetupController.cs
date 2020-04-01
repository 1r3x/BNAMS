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
    public class CountrySetupController : Controller
    {

        private ICountrySetup _aManager;

        public CountrySetupController()
        {
            _aManager = new CountrySetupManager();
        }


        // GET: CountrySetup
        public ActionResult Index()
        {
            return View();
        }


        // GET: CountrySetup/CreateCountrySetup
        public JsonResult CreateCountrySetup(M_Country aObj)
        {
            var data = _aManager.CreateCountrySetup(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // SET: CountrySetup/IsDuplicate
        public JsonResult IsDuplicate(M_Country aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: CountrySetup/GetAllCountrySetup
        public JsonResult GetAllCountrySetup()
        {
            var data = _aManager.GetAllCountrySetup();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

    }
}