using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BNAMS.Entities;
using BNAMS.Entities.ViewModels;
using BNAMS.Manager.Common;
using BNAMS.Manager.Interface;
using BNAMS.Repositories;
using SR.Repositories;

namespace BNAMS.Manager.Manager
{
    public class SetGunAmmoMaintainceManager : ISetGunAmmoMaintaince
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<ISetGunAmmoMaintaince> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public SetGunAmmoMaintainceManager()
        {
            _aRepository = new GenericRepository<ISetGunAmmoMaintaince>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }

        public ResponseModel CreateSetGunAmmoMaintaince(SetForMaintainceViewModel aObj)
        {
          

                var inWeaponsINfoTable = (from a in _db.I_WeaponsInfo
                                          where a.WeaponsInfoId == aObj.WeaponInfoId
                                          select a).SingleOrDefault();

                if (inWeaponsINfoTable != null)
                {
                    inWeaponsINfoTable.IsUse = true;
                    inWeaponsINfoTable.IsMaintaince = true;
                    inWeaponsINfoTable.IsBackup = false;
                }
                _db.SaveChanges();
                

                return _aModel.Respons(true, "New Weapons Set for Maintaince Successfully.");
            
        }




        public ResponseModel GetAllSetGunAmmoMaintaince()
        {
            var data = from a in _db.I_WeaponsInfo
                      
                       where a.IsActive==true && a.IsMaintaince==true
                       select new
                       {
                           a.RegistrationNo,
                           a.IsActive,
                           a.SetUpBy,
                           a.SetUpDateTime
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadRegistrationNo(string weaponType)
        {
            var data = from parentMenu in _db.I_WeaponsInfo
                       where parentMenu.IsActive == true && parentMenu.WeaponsTypeId == weaponType && parentMenu.IsUse==false
                       select new
                       {
                           id = parentMenu.WeaponsInfoId,
                           text = parentMenu.RegistrationNo
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadWeaponDetails(string weaponsInfoId)
        {
            var data = _db.spLoadWeaponDetails(weaponsInfoId);
            return _aModel.Respons(data);
        }
        //no use for this page
        public ResponseModel LoadDepot()
        {
            var data = from parentMenu in _db.O_ShipOrDepotInfo
                       where parentMenu.IsActive == true
                       select new
                       {
                           id = parentMenu.ShipOrDepotId,
                           text = parentMenu.ShipDepotName
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadWareHouseUnderDepotId(string depotId)
        {
            var data = from parentMenu in _db.O_WareHouse
                       where parentMenu.IsActive == true && parentMenu.UnitShipId == depotId
                       select new
                       {
                           id = parentMenu.WareHouseId,
                           text = parentMenu.WareHouseName
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadShelfUnderWareHouseId(string warehouseId)
        {
            var data = from parentMenu in _db.I_BinLocation
                       where parentMenu.IsActive == true && parentMenu.WareHouseId == warehouseId
                       select new
                       {
                           id = parentMenu.WareHouseId,
                           text = parentMenu.SelfIdNo
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadRowUnderWareHouseId(string warehouseId)
        {

            var data = from parentMenu in _db.I_BinLocation
                       where parentMenu.IsActive == true && parentMenu.WareHouseId == warehouseId
                       select new
                       {
                           id = parentMenu.WareHouseId,
                           text = parentMenu.RowIdNo
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadMaintainceType()
        {

            var data = from parentMenu in _db.M_MaintainceType
                       where parentMenu.IsActive == true
                       select new
                       {
                           id = parentMenu.MaintainceId,
                           text = parentMenu.MaintainceType
                       };
            return _aModel.Respons(data);
        }
    }
}
