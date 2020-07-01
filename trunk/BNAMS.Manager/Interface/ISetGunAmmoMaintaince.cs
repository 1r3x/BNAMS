﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;
using BNAMS.Entities.ViewModels;

namespace BNAMS.Manager.Interface
{
    public interface ISetGunAmmoMaintaince
    {
        ResponseModel CreateSetGunAmmoMaintaince(SetForMaintainceViewModel aObj);
        ResponseModel GetAllSetGunAmmoMaintaince();
        ResponseModel LoadRegistrationNo(string weaponTypeId);
        ResponseModel LoadDepot();
        ResponseModel LoadWareHouseUnderDepotId(string depotId);
        ResponseModel LoadShelfUnderWareHouseId(string warehouseId);
        ResponseModel LoadRowUnderWareHouseId(string warehouseId);
        ResponseModel LoadWeaponDetails(string weapond);
        ResponseModel LoadMaintainceType();

    }
}