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
    public class TraineePersonBioSetupController : Controller
    {
        private ITraineePersonBioSetup _aManager;
        private readonly SmartRecordEntities _db;

        public TraineePersonBioSetupController()
        {
            _aManager = new TraineePersonBioSetupManager();
            _db = new SmartRecordEntities();
        }

        // GET: TraineePersonBioSetup
        public ActionResult Index()
        {

            const string menuName = "TraineePersonBioSetup";
            var roleId = (int?)System.Web.HttpContext.Current.Session["roleId"];

            var menuId = (from a in _db.M_Menu
                where a.MenuUrl == menuName
                select a.Id).Single();


            var permission = (from a in _db.UserPermissions
                where a.RoleId == roleId && a.MenuId == menuId
                select new
                {
                    a.PermId
                }).Any();

            return permission ? (ActionResult)View() : RedirectToAction("Login", "Userlogins");
        }

        // SET: TraineePersonBioSetup/CreateTraineeBio
        public JsonResult CreateTraineeBio(HR_TraineePersonBio aObj)
        {
            var data = _aManager.CreateTraineeBio(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: TraineePersonBioSetup/IsDuplicate
        public JsonResult IsDuplicate(HR_TraineePersonBio aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: TraineePersonBioSetup/GetAllTraineeBio
        public JsonResult GetAllTraineeBio()
        {
            var data = _aManager.GetAllTraineeBio();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: TraineePersonBioSetup/LoadRank
        public JsonResult LoadRank()
        {
            var data = _aManager.LoadRank();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

    }
}