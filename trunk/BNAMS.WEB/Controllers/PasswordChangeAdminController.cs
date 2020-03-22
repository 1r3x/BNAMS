using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SR.Helpers;
using SR.Manager.Interface;
using SR.Manager.Manager;
using SR.Entities;

namespace SR.Controllers
{
    public class PasswordChangeAdminController : Controller
    {
        private readonly IPasswordChangeAdmin _aManager;
        private readonly LoginHelper _helper = new LoginHelper();

        public PasswordChangeAdminController()
        {
            _aManager = new PasswordChangeAdminManage();
        }

        // GET: PasswordChangeAdmin
        public ActionResult Index()
        {
            return View();
        }

        // GET: PasswordChangeAdmin/ChangePassword
        public JsonResult ChangePassword(UserLogin aObj)
        {
            var usersEntities = new SmartRecordEntities();
            var keyNew = (from s in usersEntities.UserLogins where (s.EmpId == aObj.EmpId) select s).FirstOrDefault();
            if (keyNew != null) aObj.Password = _helper.EncodePassword(aObj.Password, keyNew.SessionKey);
            ;
            var data = _aManager.ChangePassword(aObj);
            return Json(new { data = data.Message }, JsonRequestBehavior.AllowGet);
        }


        // GET: PasswordChangeAdmin/GetUserNameAndId
        public JsonResult GetUserNameAndId(string empIdNumber)
        {
            var data = _aManager.LoadEmpByUserId(empIdNumber);
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

    }
}