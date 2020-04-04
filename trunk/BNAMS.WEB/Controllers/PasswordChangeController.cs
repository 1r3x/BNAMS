using System.Linq;
using System.Web.Mvc;
using BNAMS.Entities;
using BNAMS.Manager.Interface;
using BNAMS.Manager.Manager;
using SR.Controllers.login;
using SR.Helpers;

namespace BNAMS.Controllers
{
    [Authorization]
    public class PasswordChangeController : Controller
    {
        private IPasswordChange _aManager;
        private LoginHelper Helper = new LoginHelper();

        public PasswordChangeController()
        {
            _aManager = new PasswordChangeManager();
        }
        // GET: PasswordChange
        public ActionResult Index()
        {
            return View();
        }


        // GET: PasswordChange/GetAllCredential
        public JsonResult GetAllCredential()
        {
            var data = _aManager.GetCurrentPassword();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: PasswordChange/ChangePassword
        public JsonResult ChangePassword(UserLogin aObj)
        {
            var usersEntities = new SmartRecordEntities();
            var keyNew = (from s in usersEntities.UserLogins where (s.EmpId == aObj.EmpId) select s).FirstOrDefault();
            aObj.Password =  Helper.EncodePassword(aObj.Password, keyNew.SessionKey); ;
            var data = _aManager.ChangePassword(aObj);
            return Json(new { data = data.Message }, JsonRequestBehavior.AllowGet);
        }
    }
}