using System.Web.Mvc;
using BNAMS.Entities;
using BNAMS.Manager.Interface;
using BNAMS.Manager.Manager;
using SR.Controllers.login;

namespace BNAMS.Controllers
{
    [Authorization]
    public class MenuController : Controller
    {
        private IMenu _aManager;

        public MenuController()
        {
            _aManager = new MenuManager();
        }
        

        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        // SET: Menu/CreateMenu
        public JsonResult CreateMenu(M_Menu aObj)
        {
            var data = _aManager.CreateMenu(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // SET: Menu/IsDuplicate
        public JsonResult IsDuplicate(M_Menu aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Menu/GetAllMenu
        public JsonResult GetAllMenu()
        {
            var data = _aManager.GetAllMenu();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Menu/LoadAllMenu
        public JsonResult LoadAllMenu()
        {
            var data = _aManager.LoadParentMenu();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }
    }
}