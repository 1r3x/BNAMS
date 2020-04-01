using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface IStatusInformationSetup
    {
        ResponseModel CreateStatusInformationSetup(M_StatusInformation aObj);
        ResponseModel GetAllStatusInformationSetup();
        ResponseModel CheckDuplicate(M_StatusInformation aObj);
    }
}
