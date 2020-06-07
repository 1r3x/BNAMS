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
    public class ProductCategoryController : Controller
    {
        private IProductCaegoryMaster _aManager;
        private readonly SmartRecordEntities _db;

        public ProductCategoryController()
        {
            _aManager = new ProductCategoryMasterManger();
            _db = new SmartRecordEntities();
        }

        // GET: ProductCategory
        public ActionResult Index()
        {
            const string menuName = "ProductCategory";
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


        // GET: ProductCategory/CreateProductCaegoryMasterSetup
        public JsonResult CreateProductCaegoryMasterSetup(M_ProductCategory aObj)
        {
            var data = _aManager.CreateProductCaegoryMasterSetup(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // SET: ProductCategory/IsDuplicate
        public JsonResult IsDuplicate(M_ProductCategory aObj)
        {
            var data = _aManager.CheckDuplicate(aObj);
            return Json(new { success = data.Status, data }, JsonRequestBehavior.AllowGet);
        }

        // GET: ProductCategory/GetAllProductCaegoryMasterSetup
        public JsonResult GetAllProductCaegoryMasterSetup()
        {
            var data = _aManager.GetAllProductCaegoryMasterSetup();
            return Json(new { data = data.Data }, JsonRequestBehavior.AllowGet);
        }


    }
}