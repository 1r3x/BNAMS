using System.Collections.Generic;
using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface IUserPrivileges
    {
        ResponseModel CreateUserPrivileges(List<UserPermission> aObj);
        ResponseModel GetAllRoleType();
        ResponseModel GetAllMenuAndSubmenu();
        ResponseModel GetAllSelectedMenuAndSubmenu(int roleId);
    }
}
