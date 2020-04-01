using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface IAuthoritySetup
    {
        ResponseModel CreateAuthority(M_Authorirty aObj);
        ResponseModel GetAllAuthority();
        ResponseModel CheckDuplicate(M_Authorirty aObj);
        ResponseModel LoadArea();
    }
}
