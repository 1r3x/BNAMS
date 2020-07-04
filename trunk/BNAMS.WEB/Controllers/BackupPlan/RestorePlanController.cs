using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BNAMS.Entities;
using BNAMS.Manager.Interface;
using BNAMS.Manager.Manager;

namespace BNAMS.Controllers.BackupPlan
{
    public class RestorePlanController : Controller
    {
        private readonly SmartRecordEntities _db;


        public RestorePlanController()
        {
            _db = new SmartRecordEntities();
        }

        // GET: RestorePlan
        public ActionResult Index()
        {
            const string menuName = "RestorePlan";
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

        // GET: RestorePlan/Restore
        public async Task<ActionResult> Restore()
        {
            try
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files;
                    var files = file[0];
                    try
                    {
                        if (files != null)
                            using (var sr = new StreamReader(files.InputStream))
                            {
                                var line = await sr.ReadToEndAsync();
                                var cleaned = line.Replace("\n", "");
                                await _db.Database.ExecuteSqlCommandAsync(cleaned);
                            }

                    }
                    catch (FileNotFoundException ex)
                    {
                        return Json(ex.Message); 
                    }
                    return Json("Restored Successfully");
                }
                else
                {
                    return Json("Oops.. Something went wrong");
                }
            }
            catch
            {
                return Json("Oops.. Something went wrong");
            }
        }



    }
}