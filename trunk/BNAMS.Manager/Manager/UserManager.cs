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
        private readonly IGenericRepository<Emp_BasicInfo> _aRepository;
        private readonly IGenericRepository<UserLogin> _anotherRepository;
        private readonly SmartRecordEntities _db;

        public UserManager()
        {
            _aRepository = new GenericRepository<Emp_BasicInfo>();
            _anotherRepository = new GenericRepository<UserLogin>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
        }

        public ResponseModel CreateEmployee(Emp_BasicInfo aObj)
        {
            if (aObj.EmpId == 0)
            {
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;

                var login = new UserLogin()
                {
                    EmpId = aObj.EmpId,
                    Email = aObj.EmpEmail,
                    Password = "EA-03-29-73-61-E3-03-05-1B-FB-06-1C-49-0A-C7-2A",
                    UserName = aObj.EmpUserName,
                    UserRole = aObj.RoleId,
                    IsActive = true,
                    SessionKey= "PBqXTQjO6x"

                };
                _anotherRepository.Insert(login);
                _anotherRepository.Save();

                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Employee Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;
            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Employee Updated Successfully");
        }

        public ResponseModel DuplicateCheck(Emp_BasicInfo aObj)
        {
            var data = (from e in _db.Emp_BasicInfo
                        where e.EmpId != aObj.EmpId && e.EmpUserName == aObj.EmpUserName
                select e.EmpId).FirstOrDefault();
            return data != 0 ? _aModel.Respons(true, "This User Name already Exist") : _aModel.Respons(false, "");
        }

        public ResponseModel GetAllUser()
        {
            var data = from a in _db.Emp_BasicInfo
                select new
                {
                    a.EmpId,
                    EmployeeFullName=a.EmpFName +""+ a.EmpLastName,
                    a.EmpEmail,
                    a.EmpFName,
                    a.EmpLastName,
                    a.EmpUserName,
                    a.EmpIdNumber,
                    a.IsActive,
                    a.EmpCell,
                    a.RoleId
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

    }
}
