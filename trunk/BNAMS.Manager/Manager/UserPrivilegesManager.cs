using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR.Entities;
using SR.Manager.Interface;
using SR.Repositories;

namespace SR.Manager.Manager
{
    public class UserPrivilegesManager:IUserPrivileges
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<UserPermission> _aRepository;
        private readonly SmartRecordEntities _db;

        public UserPrivilegesManager()
        {
            _aRepository = new GenericRepository<UserPermission>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
        }


        public ResponseModel CreateUserPrivileges(List<UserPermission> aObj)
        {

            if (aObj != null)
                foreach (var item in aObj)
                {
                    //var x = (from y in _db.UserPermissions
                    //    where y.RoleId ==item.RoleId
                    //    select y).FirstOrDefault();
                    //if (x != null) _db.UserPermissions.Remove(x);

                    var item1 = item;
                    var items = _db.UserPermissions.Where(f => f.RoleId == item1.RoleId);
                    foreach (var e in items)
                        _db.UserPermissions.Remove(e);
                    //_db.SaveChanges();

                    //if (_db.UserPermissions.Any(m => m.RoleId == item.RoleId && m.MenuId == item.MenuId))
                    //{
                    //        extreading = _db.UserPermissions.FirstOrDefault(m => m.MenuId == item.MenuId && m.RoleId==item.RoleId);
                    //        if (extreading == null) continue;
                    //        extreading.IsEdit = item.IsEdit;
                    //        extreading.IsDelete = item.IsDelete;
                    //        extreading.IsCreate = item.IsCreate;
                    //        _db.UserPermissions.Attach(extreading);
                    //        _db.Entry(extreading).State = EntityState.Modified;
                    //}
                    //else
                    //{
                    var extreading = new UserPermission()
                    {
                        RoleId = item.RoleId,
                        MenuId=item.MenuId,
                        IsEdit=item.IsEdit,
                        IsDelete=item.IsDelete,
                        IsCreate=item.IsCreate

                    };
                        _db.UserPermissions.Add(extreading);
                    //}
                }
            _db.SaveChanges();
            return _aModel.Respons(true, "UserPrivileges Assign Successfully Done.");
        }

        public ResponseModel GetAllRoleType()
        {
            var data = from userRole in _db.UserRoles
                select new
                {
                    id = userRole.RoleId,
                    text = userRole.UserRoleName
                };
            return _aModel.Respons(data);
        }

        public ResponseModel GetAllMenuAndSubmenu()
        {
            var data = from a in _db.M_Menu
                       where a.IsActive == true
                       orderby a.SortingOrderHelper,a.UpdateDateTime
                       select new
                {
                    a.Id,
                    a.ParentId,
                    a.MenuName
                };
            return _aModel.Respons(data);
        }
        //extra for automatically checked the checkbox 
        public ResponseModel GetAllSelectedMenuAndSubmenu(int roleId)
        {
            //var data = from a in _db.M_Menu
            //           join b in _db.UserPermissions on a.Id equals b.MenuId
            //    where a.IsActive == true && b.RoleId==roleId
            //    orderby a.SortingOrderHelper, a.UpdateDateTime
            //    select new
            //    {
            //        a.Id,
            //        a.ParentId,
            //        a.MenuName,
            //        selected=b.MenuId
            //    };

            var data = _db.spGetAllSelectedMenuAndSubMenu(roleId);


            return _aModel.Respons(data);
        }
    }
}
