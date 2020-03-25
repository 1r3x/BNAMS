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


        public ResponseModel CreateUser(UserLogin aObj)
        {
            if (aObj.Id == 0)
            {
                if (aObj.UserRole == null)
                {
                    aObj.UserRole = 0;
                }
               
                _aRepository.Insert(aObj);
                _aRepository.Save();

                return _aModel.Respons(true, "New User Saved Successfully.");
            }

            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "User Updated Successfully");
        }

        public ResponseModel CreateEmployee(Emp_BasicInfo aObj)
        {
            throw new NotImplementedException();
        }

        public ResponseModel DuplicateCheck(int empId, string userName)
        {
            throw new NotImplementedException();
        }

        public ResponseModel GetAllUser()
        {
            var data = from a in _db.Emp_BasicInfo
                select new
                {
                    a.EmpId,
                    a.EmpFName,
                    a.EmpLastName,
                    a.EmpEmail,
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
