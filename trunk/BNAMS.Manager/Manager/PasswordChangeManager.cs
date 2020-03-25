using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BNAMS.Entities;
using BNAMS.Manager.Interface;
using BNAMS.Repositories;
using SR.Repositories;

namespace BNAMS.Manager.Manager
{
    public class PasswordChangeManager: IPasswordChange
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<UserLogin> _aRepository;
        private readonly SmartRecordEntities _db;

        public PasswordChangeManager()
        {
            _aRepository = new GenericRepository<UserLogin>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
        }
        public ResponseModel ChangePassword(UserLogin aObj)
        {
            if (_db.UserLogins.Any(m => m.EmpId == aObj.EmpId))
            {
                var extreading = _db.UserLogins.FirstOrDefault(m => m.EmpId == aObj.EmpId);
                
               //HttpContext.Current.Session["usedId"].ToString();
                if (extreading != null) extreading.Password = aObj.Password;
                if (extreading != null) _db.UserLogins.Attach(extreading);
                _db.Entry(extreading).State = EntityState.Modified;

            }
            _db.SaveChanges();
            return _aModel.Respons(true, "Password Changed Successfully.");
        }

        public ResponseModel GetCurrentPassword()
        {
            var empId = Convert.ToInt32(HttpContext.Current.Session["empId"].ToString());

            var data = from a in _db.UserLogins
                where a.IsActive == true && a.EmpId==empId
                select new
                {
                    a.Password,
                    a.UserName,
                    a.EmpId
                };
            return _aModel.Respons(data);
        }
    }
}
