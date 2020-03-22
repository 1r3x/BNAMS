using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SR.Entities;
using SR.Manager.Interface;
using SR.Repositories;

namespace SR.Manager.Manager
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
                aObj.CreatedBy = (int?)HttpContext.Current.Session["userid"];
                aObj.CreateDate = DateTime.Now;
                _aRepository.Insert(aObj);
                _aRepository.Save();

                //for sorting order generation 
                //if (aObj.ParentId == 0)
                //{
                //    var sortingOrder = aObj.Id;
                //    aObj.SortingOrderHelper = sortingOrder;
                //    _aRepository.Update(aObj);
                //    _aRepository.Save();

                //}
                //else
                //{
                //    var sortingOrder = aObj.ParentId;
                //    aObj.SortingOrderHelper = sortingOrder;
                //    _aRepository.Update(aObj);
                //    _aRepository.Save();
                //}
                //end


                return _aModel.Respons(true, "New User Saved Successfully.");
            }
            //if (aObj.ParentId == null)
            //{
            //    aObj.ParentId = 0;
            //    aObj.SortingOrderHelper = aObj.Id;
            //}
            //else
            //{
            //    aObj.SortingOrderHelper = aObj.ParentId;
            //}
            aObj.CreatedBy = 1;
            aObj.CreateDate = DateTime.Now;
            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "User Updated Successfully");
        }

        public ResponseModel GetAllUser()
        {
            var data = from a in _db.UserLogins
                select new
                {
                    a.Id,
                    a.Email,
                    a.EmailIsConfirmed,
                    a.Password,
                    a.PhoneNo,
                    a.UserRole,
                    a.IsActive,
                    a.UserName,
                    a.CreateDate,
                    a.CreatedBy,
                    a.UserFullName,
                    a.UserPhoto

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
