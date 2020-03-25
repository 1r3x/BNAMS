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

        // SET: Manu/CreateUser
        public JsonResult CreateUser(UserLogin aObj)
        {
            var data = _aManager.CreateUser(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Manu/GetAllUser
        public JsonResult GetAllUser()
        {
            var data = _aManager.GetAllUser();
            var dataView = data.Data.ToString();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Manu/LoadAllUser
        public JsonResult LoadAllRole()
        {
            var data = _aManager.LoadUserRole();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
    }
}