using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BNAMS.Entities;
using BNAMS.Manager.Interface;
using BNAMS.Repositories;
using SR.Repositories;

namespace BNAMS.Manager.Manager
{
    public class RoleSetupManager:IRoleSetup
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<UserRole> _aRepository;
        private readonly SmartRecordEntities _db;

        public RoleSetupManager()
        {
            _aRepository = new GenericRepository<UserRole>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
        }



        public ResponseModel CreateRole(UserRole aObj)
        {
            if (aObj.RoleId == 0)
            {
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Role Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;
            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Role Updated Successfully");
        }
       

        public ResponseModel GetAllRole()
        {
            var data = from a in _db.UserRoles
                select new
                {
                    a.RoleId,
                    a.UserRoleName,
                    a.IsActive
                };
            return _aModel.Respons(data);
        }

        public ResponseModel CheckDuplicate(UserRole aObj)
        {
            var data = (from e in _db.UserRoles
                where e.RoleId != aObj.RoleId && e.UserRoleName == aObj.UserRoleName
                select e.RoleId).FirstOrDefault();
            return data != 0 ? _aModel.Respons(true, "This Role already Exist") : _aModel.Respons(false, "");
        }
    }
}
