
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;
using BNAMS.Entities.ViewModels;

namespace BNAMS.Manager.Interface
{
    public interface IStatusAfterMaintaince
    {
        ResponseModel CreateStatusAfterMaintaince(I_StatusAfterMaintaince aObj);
        ResponseModel GetAllStatusAfterMaintaince();
        ResponseModel LoadRegistrationNo();
        ResponseModel LoadMaintainceDetailsByRegistrationNo(string weaponsInfoId);
        ResponseModel LoadStatus();
    }
}
