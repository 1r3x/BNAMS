using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface IRoleSetup
    {
        ResponseModel CreateRole(UserRole aObj);
        ResponseModel GetAllRole();
        ResponseModel CheckDuplicate(UserRole aObj);
    }
}
