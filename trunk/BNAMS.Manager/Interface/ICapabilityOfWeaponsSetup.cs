using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface ICapabilityOfWaeponsSetup
    {
        ResponseModel CreateCapabilityOfWaeponsSetup(M_CapabilityOfWeapons aObj);
        ResponseModel GetAllCapabilityOfWaeponsSetup();
        ResponseModel CheckDuplicate(M_CapabilityOfWeapons aObj);
    }
}
