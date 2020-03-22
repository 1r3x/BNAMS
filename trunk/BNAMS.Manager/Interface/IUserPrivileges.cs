using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR.Entities;

namespace SR.Manager.Interface
{
    public interface IUserPrivileges
    {
        ResponseModel CreateUserPrivileges(List<UserPermission> aObj);
        ResponseModel GetAllRoleType();
        ResponseModel GetAllMenuAndSubmenu();
        ResponseModel GetAllSelectedMenuAndSubmenu(int roleId);
    }
}
