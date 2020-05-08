using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface ITrainingInfo
    {
        ResponseModel CreateTrainingInfo(HR_TraningInformation aObj);
        ResponseModel GetAllTrainingInfo();
        ResponseModel LoadEquipment();
        ResponseModel LoadPNO();
        ResponseModel LoadCounry();
        ResponseModel LoadTraningOrg();
    }
}
