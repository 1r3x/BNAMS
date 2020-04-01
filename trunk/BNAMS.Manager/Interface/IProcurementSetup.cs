using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface IProcurementSetup
    {
        ResponseModel CreateProcurementSetup(M_ProcurementCategory aObj);
        ResponseModel GetAllProcurementSetup();
        ResponseModel CheckDuplicate(M_ProcurementCategory aObj);
    }
}
