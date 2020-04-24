﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface IGunAmmoMaintaince
    {
        ResponseModel CreateGunAmmoMaintaince(I_MaintenanceInfo aObj);
        ResponseModel GetAllGunAmmoMaintaince();
        ResponseModel LoadRegistrationNo(string weaponTypeId);
        ResponseModel LoadDepot();
        ResponseModel LoadWareHouseUnderDepotId(string depotId);
        ResponseModel LoadShelfUnderWareHouseId(string warehouseId);
        ResponseModel LoadRowUnderWareHouseId(string warehouseId);
        ResponseModel LoadWeaponDetails(string weapond);
        ResponseModel LoadMaintainceType();

    }
}
