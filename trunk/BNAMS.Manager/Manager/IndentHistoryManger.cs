using BNAMS.Entities;
using BNAMS.Manager.Common;
using BNAMS.Manager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNAMS.Manager.Manager
{
    public class IndentHistoryManger : IIndentHistory
    {

        private readonly ResponseModel _aModel;
        private readonly SmartRecordEntities _db;

        public IndentHistoryManger()
        {
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
        }
        public ResponseModel GetAllIndent(string weaponType, string weaponName, string weaponModel)
        {
            if (weaponType=="" || weaponName=="" || weaponModel=="")
            {
                var data = from a in _db.I_Indent
                           join b in _db.O_ShipOrDepotInfo on a.IndentFrom equals b.ShipOrDepotId
                           join c in _db.O_ShipOrDepotInfo on a.IssueTo equals c.ShipOrDepotId
                           join d in _db.I_WeaponsInfo on a.ItemId equals d.WeaponsInfoId
                           join e in _db.M_NameOfWeapon on d.NameOfWeaponsId equals e.NameOfGunId
                           join f in _db.M_Composite on a.CompositeId equals f.CompositeId
                           //
                           join h in _db.M_WeaponsModelType on d.WeaponsModel equals h.GunModelId
                           join g in _db.O_WareHouse on d.WareHouseId equals g.WareHouseId

                           select new
                           {
                               a.IndentQuantity,
                               a.ProgramId,
                               a.IndentNo,
                               a.CompositeId,
                               a.DerectorateId,
                               a.IndentFrom,
                               a.IndentId,
                               a.IndentStatusDate,
                               a.IndentStatusId,
                               a.IndentType,
                               a.IndentValidity,
                               a.IsActive,
                               a.IssueTo,
                               a.ItemId,
                               a.OtherOptions,
                               //
                               indentFrom = b.ShipDepotName,
                               b.ShipDepotName,
                               //
                               issueTo = c.ShipDepotName,
                               //
                               d.RegistrationNo,
                               d.WeaponsInfoId,
                               d.OperatingTemp,
                               d.UnitPrice,
                               //
                               e.NameOfGun,
                               //
                               f.CompositeName,
                               //
                               g.WareHouseName,
                               //
                               h.GunModelName,
                               //

                           };
                return _aModel.Respons(data);
            }
            else
            {
                var data = from a in _db.I_Indent
                           join b in _db.O_ShipOrDepotInfo on a.IndentFrom equals b.ShipOrDepotId
                           join c in _db.O_ShipOrDepotInfo on a.IssueTo equals c.ShipOrDepotId
                           join d in _db.I_WeaponsInfo on a.ItemId equals d.WeaponsInfoId
                           join e in _db.M_NameOfWeapon on d.NameOfWeaponsId equals e.NameOfGunId
                           join f in _db.M_Composite on a.CompositeId equals f.CompositeId
                           //
                           join h in _db.M_WeaponsModelType on d.WeaponsModel equals h.GunModelId
                           join g in _db.O_WareHouse on d.WareHouseId equals g.WareHouseId

                           where d.WeaponsTypeId == weaponType && e.NameOfGunId == weaponName && h.GunModelId == weaponModel
                           select new
                           {
                               a.IndentQuantity,
                               a.ProgramId,
                               a.IndentNo,
                               a.CompositeId,
                               a.DerectorateId,
                               a.IndentFrom,
                               a.IndentId,
                               a.IndentStatusDate,
                               a.IndentStatusId,
                               a.IndentType,
                               a.IndentValidity,
                               a.IsActive,
                               a.IssueTo,
                               a.ItemId,
                               a.OtherOptions,
                               //
                               indentFrom = b.ShipDepotName,
                               b.ShipDepotName,
                               //
                               issueTo = c.ShipDepotName,
                               //
                               d.RegistrationNo,
                               d.WeaponsInfoId,
                               d.OperatingTemp,
                               d.UnitPrice,
                               //
                               e.NameOfGun,
                               //
                               f.CompositeName,
                               //
                               g.WareHouseName,
                               //
                               h.GunModelName,
                               //

                           };
                return _aModel.Respons(data);
            }
           
            
        }

       
    }
}
