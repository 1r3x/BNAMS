using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface IShipOrDepotSetup
    {
        ResponseModel CreateShipOrDepotSetup(O_ShipOrDepotInfo aObj);
        ResponseModel GetAllShipOrDepotSetup();
        ResponseModel CheckDuplicate(O_ShipOrDepotInfo aObj);
        ResponseModel LoadShipOrdepotCategory();
        ResponseModel LoadShipOrdepoType();
        ResponseModel LoadCapbilityOfWeapons();
    }
}
