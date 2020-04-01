using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface INameOfGunSetup
    {
        ResponseModel CreateNameOfGunSetup(M_NameOfGun aObj);
        ResponseModel GetAllNameOfGunSetup();
        ResponseModel CheckDuplicate(M_NameOfGun aObj);
    }
}
