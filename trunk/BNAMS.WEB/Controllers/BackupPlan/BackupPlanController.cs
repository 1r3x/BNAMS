using System;
using BNAMS.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BNAMS.Manager.Interface;
using BNAMS.Manager.Manager;

namespace BNAMS.Controllers.BackupPlan
{
    public class BackupPlanController : Controller
    {

        private readonly SmartRecordEntities _db;

        private IBackupPlan _aManager;

        public BackupPlanController()
        {
            _aManager = new BackupPlanManager();

            _db = new SmartRecordEntities();
        }

        // GET: BackupPlan
        public ActionResult Index()
        {
            const string menuName = "BackupPlan";
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

        // GET: BackupPlan/SaveDataAsync
        public async Task<FileStreamResult> SaveDataAsync()
        {
            var tast = new Task<string>(_aManager.GetFullBackupScript);
            tast.Start();

            //System.Threading.Thread.Sleep(10000);
            var result = await tast;


            //Build your stream
            var byteArray = Encoding.ASCII.GetBytes(result);
            var stream = new MemoryStream(byteArray);
            //Returns a file that will match your value passed in (ie TestID2.txt)
            return File(stream, "text/plain", $"{System.DateTime.Now + "BNAMS_Backup"}.sql");
        }
        // GET: BackupPlan/UpdateAllIsBackupStatus
        public async Task<string> UpdateAllIsBackupStatus()
        {
            var tast = new Task<string>(_aManager.UpdateAllIsBackupStatus);
            tast.Start();
            //System.Threading.Thread.Sleep(10000);
            var result = await tast;
            return result;
        }



    }
}