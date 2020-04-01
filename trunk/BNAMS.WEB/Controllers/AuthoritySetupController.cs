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
    public class AuthoritySetupController : Controller
    {
        private IAuthoritySetup _aManager;

        public AuthoritySetupController()
        {
            _aManager = new AuthoritySetupManager();
        }
        
        // GET: AuthoritySetup
        public ActionResult Index()
        {
            return View();
        }

        // SET: AuthoritySetup/CreateAuthority
        public JsonResult CreateAuthority(M_Authorirty aObj)
        {
            var data = _aManager.CreateAuthority(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: AuthoritySetup/IsDuplicate
        public JsonResult IsDuplicate(M_Authorirty aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: AuthoritySetup/LoadAllAuthority
        public JsonResult LoadAllAuthority()
        {
            var data = _aManager.GetAllAuthority();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: AuthoritySetup/LoadAllArea
        public JsonResult LoadAllArea()
        {
            var data = _aManager.LoadArea();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

    }
}