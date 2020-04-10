using System.Data.Entity;
using System.Linq;
using BNAMS.Entities;
using BNAMS.Manager.Interface;
using BNAMS.Repositories;
using SR.Repositories;

namespace BNAMS.Manager.Manager
{
    public class PasswordChangeAdminManage:IPasswordChangeAdmin
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<UserLogin> _aRepository;
        private readonly SmartRecordEntities _db;

        public PasswordChangeAdminManage()
        {
            _aRepository = new GenericRepository<UserLogin>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
        }
        public ResponseModel LoadEmpByUserId(string userName)
        {
            var empData = (from a in _db.UserLogins
                where a.UserName == userName
                select new
                {
                    a.Id,
                    a.FirstName,
                    a.LastName
                }).ToList();
            return _aModel.Respons(empData);

        }

        public ResponseModel ChangePassword(UserLogin aObj)
        {
            if (_db.UserLogins.Any(m => m.Id == aObj.Id))
            {
                var extreading = _db.UserLogins.FirstOrDefault(m => m.Id == aObj.Id);

                if (extreading != null) extreading.Password = aObj.Password;
                if (extreading != null) _db.UserLogins.Attach(extreading);
                _db.Entry(extreading).State = EntityState.Modified;

            }
            _db.SaveChanges();
            return _aModel.Respons(true, "Password Changed Successfully.");
        }
    }
}
