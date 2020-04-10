using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface IWareHouseInfo
    {
        ResponseModel CreateWareHouse(O_WareHouse aObj);
        ResponseModel GetAllWareHouse();
        ResponseModel CheckDuplicate(O_WareHouse aObj);
        ResponseModel LoadWareHouseType();
        ResponseModel LoadUnitDepotShip();
    }
}
