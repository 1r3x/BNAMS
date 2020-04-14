using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface IWeaponsEntry
    {
        ResponseModel CreateWeaponsItem(I_WeaponsInfo aObj);
        ResponseModel GetWeaponsByWeaponType(string weaponId);
        ResponseModel LoadWeaponsType();
        ResponseModel LoadWeaponsByType(string weaponsTypeId);
        ResponseModel LoadWeaponModelByWeaponId(string weaponsTypeId);
        //from 
        ResponseModel LoadFiscalYear();
        ResponseModel LoadCountry();
        ResponseModel LoadPriceType();
        ResponseModel LoadLocalAgent();
        ResponseModel LoadPrincipalAgent();
        ResponseModel LoadManuAgent();
        ResponseModel LoadQuantityCategory();
        ResponseModel LoadDepot();
        ResponseModel LoadProcurementCategory();
        ResponseModel LoadWareHouse();
        ResponseModel LoadShelfNameByWraehouseId(string warehouseId);
        ResponseModel LoadRowNameByWraehouseId(string binLocationId);
        ResponseModel LoadStatus();
        
    }
}
