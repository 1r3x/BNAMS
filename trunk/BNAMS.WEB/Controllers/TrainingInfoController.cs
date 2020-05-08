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
    public class TrainingInfoController : Controller
    {
        private ITrainingInfo _aManager;
        private readonly SmartRecordEntities _db;

        public TrainingInfoController()
        {
            _aManager = new TrainingInfoManager();
            _db = new SmartRecordEntities();
        }

        // GET: TrainingInfo
        public ActionResult Index()
        {
            const string menuName = "TrainingInfo";
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

        // SET: TrainingInfo/CreateTrainingInfo
        public JsonResult CreateTrainingInfo(HR_TraningInformation aObj)
        {
            var data = _aManager.CreateTrainingInfo(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: TrainingInfo/GetAllTrainingInfo
        public JsonResult GetAllTrainingInfo()
        {
            var data = _aManager.GetAllTrainingInfo();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: TrainingInfo/LoadCounry
        public JsonResult LoadCounry()
        {
            var data = _aManager.LoadCounry();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: TrainingInfo/LoadEquipment
        public JsonResult LoadEquipment()
        {
            var data = _aManager.LoadEquipment();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: TrainingInfo/LoadTraningOrg
        public JsonResult LoadTraningOrg()
        {
            var data = _aManager.LoadTraningOrg();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: TrainingInfo/LoadPno
        public JsonResult LoadPno()
        {
            var data = _aManager.LoadPNO();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

    }
}