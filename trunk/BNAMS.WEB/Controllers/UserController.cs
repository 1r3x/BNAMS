using System.Web.Mvc;
using BNAMS.Entities;
using BNAMS.Manager.Interface;
using BNAMS.Manager.Manager;
using SR.Controllers.login;

namespace BNAMS.Controllers
{
    [Authorization]
    public class UserController : Controller
    {
        private IUser _aManager;

        public UserController()
        {
            _aManager = new UserManager();
        }
        

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // SET: User/CreateUser
        public JsonResult CreateUser(Emp_BasicInfo aObj)
        {
            var data = _aManager.CreateEmployee(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // SET: User/CheckDuplicate
        public JsonResult CheckDuplicate(Emp_BasicInfo aObj)
        {
            var data = _aManager.DuplicateCheck(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }



        // GET: User/GetAllUser
        public JsonResult GetAllUser()
        {
            var data = _aManager.GetAllUser();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: User/LoadAllUser
        public JsonResult LoadAllRole()
        {
            var data = _aManager.LoadUserRole();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
    }
}