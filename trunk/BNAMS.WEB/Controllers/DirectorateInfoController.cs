using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BNAMS.Entities;
using BNAMS.Manager.Interface;
using BNAMS.Manager.Manager;

namespace BNAMS.Controllers
{
    public class DirectorateInfoController : Controller
    {

        private IDirectorateInfo _aManager;
        private readonly SmartRecordEntities _db;

        public DirectorateInfoController()
        {
            _aManager = new DirectorateInfoManager();
            _db=new SmartRecordEntities();
        }

        // GET: DirectorateInfo
        public ActionResult Index()
        {
            const string menuName = "DirectorateInfo";
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

        // SET: DirectorateInfo/CreateDirectorateInfo
        public JsonResult CreateDirectorateInfo(O_DirectorateInfo aObj)
        {
            Session["DirectorateName"] = aObj.DirectorateName;

            var data = _aManager.CreateDirectorateInfo(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }


        // SET: DirectorateInfo/UploadFiles
        [HttpPost]
        public ActionResult UploadFiles()
        {
            if (Request.Files.Count > 0)
            {
                var fileName = (string)System.Web.HttpContext.Current.Session["DirectorateName"];
                if (fileName == null) return Json("Oops Something Went Wrong!");
                var modifiedFile = fileName.Replace(@"/", "");
                var path = Server.MapPath("~/Uploads/");
                var files = Request.Files;
                for (var i = 0; i < files.Count; i++)
                {
                    var file = files[i];

                    file?.SaveAs(path + file.FileName.Replace(file.FileName, modifiedFile + file.ContentType).Replace(@"/", "."));
                }
                return Json(files.Count + " Files Uploaded!");
            }
            else
            {
                return Json("No files selected.");
            }
        }




        // GET: DirectorateInfo/IsDuplicate
        public JsonResult IsDuplicate(O_DirectorateInfo aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: DirectorateInfo/GetAllDirectorateInfo
        public JsonResult GetAllDirectorateInfo()
        {
            var data = _aManager.GetAllDirectorateInfo();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
        // GET: DirectorateInfo/LoadAllArea
        public JsonResult LoadAllArea()
        {
            var data = _aManager.LoadArea();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: DirectorateInfo/LoadAdmin
        public JsonResult LoadAdmin()
        {
            var data = _aManager.LoadAdmin();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

    }
}