using System;
using System.Linq;
using System.Web;
using BNAMS.Entities;
using BNAMS.Manager.Interface;
using BNAMS.Repositories;
using SR.Repositories;

namespace BNAMS.Manager.Manager
{
    public class UserManager : IUser
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<UserLogin> _aRepository;
        private readonly SmartRecordEntities _db;

        public UserManager()
        {
            _aRepository = new GenericRepository<UserLogin>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
        }

        public ResponseModel CreateEmployee(UserLogin aObj)
        {
            if (aObj.Id == 0)
            {
                //for image
                if (aObj.EmpImage != null)
                {
                    aObj.EmpImage = "uploads/emloyeeimg/" + aObj.EmpIdNumber + aObj.EmpImage.Replace(@"/", ".");

                }
                aObj.Id=(int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                aObj.Password = "E1-2A-D2-67-AA-6D-09-43-55-00-FA-FA-9B-4E-2C-50";//b@ng1ad3shn@vy
                aObj.SessionKey = "PBqXTQjO6x";
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                _aRepository.Insert(aObj);
                _aRepository.Save();

                return _aModel.Respons(true, "New Employee Saved Successfully.");
            }

            //for image
            if (aObj.EmpImage != null)
            {
                var filterImage = aObj.EmpImage.Replace(@"uploads/emloyeeimg/", "");
                var filterImage1= filterImage.Replace(aObj.EmpIdNumber, "");
                var filterImage2 = filterImage1.Replace(@".","/");

                aObj.EmpImage = "uploads/emloyeeimg/" + aObj.EmpIdNumber + filterImage2.Replace(@"/", ".");

            }
            aObj.SessionKey = "PBqXTQjO6x";
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;
            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Employee Updated Successfully");
        }

        public ResponseModel DuplicateCheck(UserLogin aObj)
        {
            var data = (from e in _db.UserLogins
                        where e.EmpIdNumber != aObj.EmpIdNumber && e.UserName == aObj.UserName
                select e.Id).FirstOrDefault();
            return data != 0 ? _aModel.Respons(true, "This User Name already Exist") : _aModel.Respons(false, "");
        }

        public ResponseModel GetAllUser()
        {
            var data = from a in _db.UserLogins
                join rolll in _db.UserRoles  on a.UserRole equals rolll.RoleId
                join dir in _db.O_DirectorateInfo on a.DirectorateId equals dir.DirectorateID
                select new
                {
                    a.Id,
                    a.UserRole,
                    a.EmpIdNumber,
                    a.DirectorateId,
                    a.UserName,
                    a.FirstName,
                    a.LastName,
                    a.PhoneNo,
                    a.Email,
                    a.LastLoginDate,
                    a.EmpImage,
                    a.Password,
                    a.IsActive,
                    a.SetUpBy,
                    a.SetUpDateTime,
                    a.UpdatedDateTime,
                    a.UpdatedBy,
                    rolll.UserRoleName,
                    dir.DirectorateName,
                    EmployeeFullName=a.FirstName+" "+a.LastName
                };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadUserRole()
        {
            var data = from role in _db.UserRoles
                       select new
                       {
                           id = role.RoleId,
                           text = role.UserRoleName
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadDirectorateInfo()
        {
            var data = from role in _db.O_DirectorateInfo
                select new
                {
                    id = role.DirectorateID,
                    text = role.DirectorateName
                };
            return _aModel.Respons(data);
        }

    }
}
