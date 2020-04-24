using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BNAMS.Entities;
using BNAMS.Manager.Common;
using BNAMS.Manager.Interface;
using BNAMS.Repositories;
using SR.Repositories;

namespace BNAMS.Manager.Manager
{
    public class GunAmmoMaintainceManager : IGunAmmoMaintaince
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<I_MaintenanceInfo> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public GunAmmoMaintainceManager()
        {
            _aRepository = new GenericRepository<I_MaintenanceInfo>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }

        public ResponseModel CreateGunAmmoMaintaince(I_MaintenanceInfo aObj)
        {
            if (aObj.MaintainceId == "0")
            {
                aObj.MaintainceId = (string)HttpContext.Current.Session["directorateId"] + "-BIN-" + (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                aObj.IsBackup = false;
                aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];


                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Maintaince Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;
            aObj.IsBackup = false;
            aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];

            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Maintaince Updated Successfully");
        }

        public ResponseModel GetAllGunAmmoMaintaince()
        {
            var data = from a in _db.I_MaintenanceInfo
                       join weapons in _db.I_WeaponsInfo on a.ItemId equals weapons.NameOfWeaponsId
                       select new
                       {
                           a.MaintainceId,
                           a.IsActive,
                           a.SetUpBy,
                           a.SetUpDateTime
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadRegistrationNo(string weaponType)
        {
            var data = from parentMenu in _db.I_WeaponsInfo
                       where parentMenu.IsActive == true && parentMenu.WeaponsTypeId == weaponType
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
