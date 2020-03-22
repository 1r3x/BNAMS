using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Manager.Interface
{
    public interface IRoleWiseMenu
    {
        ResponseModel GetAllMenuByRoleId(int menuId);
    }
}
