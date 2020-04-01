using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface IQuantitySetup
    {
        ResponseModel CreateQuantitySetup(M_QuantityCategory aObj);
        ResponseModel GetAllQuantitySetup();
        ResponseModel CheckDuplicate(M_QuantityCategory aObj);
    }
}
