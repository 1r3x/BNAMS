using System.Web.Mvc;
using BNAMS.Controllers.login;
using BNAMS.Entities;
using BNAMS.Manager.Interface;
using BNAMS.Manager.Manager;
using System.Linq;

namespace BNAMS.Controllers
{
    [Authorization]
    public class UserController : Controller
    {
        private IUser _aManager;
        private readonly SmartRecordEntities _db;

        public UserController()
        {
            _aManager = new UserManager();
            _db = new SmartRecordEntities();
        }
        

        // GET: User
        public ActionResult Index()
        {
            const string menuName = "User";
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
            //return (ActionResult)View();
        }

        // SET: User/CreateUser
        public JsonResult CreateUser(UserLogin aObj)
        {
            Session["employeeIdNumber"] = aObj.EmpIdNumber;
            var data = _aManager.CreateEmployee(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }


        // SET: User/UploadFiles
        [HttpPost]
        public ActionResult UploadFiles()
        {
            if (Request.Files.Count > 0)
            {
                var fileName = (string)System.Web.HttpContext.Current.Session["employeeIdNumber"];
                if (fileName == null) return Json("Oops Something Went Wrong!");
                var modifiedFile = fileName.Replace(@"/", "");
                var path = Server.MapPath("~/uploads/emloyeeimg/");
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

        // SET: User/CheckDuplicate
        public JsonResult CheckDuplicate(UserLogin aObj)
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

        // GET: User/LoadDirectorateInfo
        public JsonResult LoadDirectorateInfo()
        {
            var data = _aManager.LoadDirectorateInfo();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
    }
}