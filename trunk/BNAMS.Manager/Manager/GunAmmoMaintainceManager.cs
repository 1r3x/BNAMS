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
    public class GunAmmoMaintainceManager : IGunAmmoMaintaince
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<I_StatusAfterMaintaince> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public GunAmmoMaintainceManager()
        {
            _aRepository = new GenericRepository<I_StatusAfterMaintaince>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }

        public ResponseModel CreateGunAmmoMaintaince(WeaponsMaintainceViewModel aObj)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                if (aObj.MaintainceId == "0")
                {

                    var inMaintainceTable = (from a in _db.I_MaintenanceInfo
                                             where a.ItemId == aObj.ItemId && a.IsActive==true
                                             select a).SingleOrDefault();

                    if (inMaintainceTable != null)
                    {

                        inMaintainceTable.IsActive = false;
                    }
                    _db.SaveChanges();

                    var maintaince = new I_MaintenanceInfo()
                    {

                        MaintainceId = (string)HttpContext.Current.Session["directorateId"] + "-BIN-" +
                                       (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds,
                        MaintainceCode = "MNT-" + DateTime.UtcNow.Second + _commonCode.RandomString(3, false),
                        ItemId = aObj.ItemId,
                        LastMaintainceDate =aObj.LastMaintainceDate,
                        MaintainceYear = aObj.MaintainceYear,
                        MaintainceDetails = aObj.MaintainceDetails,
                        MaintainceLocation = aObj.MaintainceLocation,
                        DefectInfo = aObj.DefectInfo,
                        NextMaintainceSchadule = aObj.NextMaintainceSchadule,
                        SetUpBy = (int?)HttpContext.Current.Session["userid"],
                        SetUpDateTime = DateTime.Now,
                        IsActive = true,
                        IsBackup = false,
                        DerectorateId = (string)HttpContext.Current.Session["directorateId"]

                    };
                    _db.I_MaintenanceInfo.Add(maintaince);

                    _db.SaveChanges();

                    //for wepons info changes

                    var inWeaponsINfoTable = (from a in _db.I_WeaponsInfo
                                              where a.WeaponsInfoId == aObj.ItemId
                                              select a).SingleOrDefault();

                    if (inWeaponsINfoTable != null)
                    {

                        inWeaponsINfoTable.DepotId = aObj.DepotId;
                        inWeaponsINfoTable.WareHouseId = aObj.WareHouseId;
                        inWeaponsINfoTable.BinLocationId = aObj.BinLOcationId;
                        inWeaponsINfoTable.IsBackup = false;
                        inWeaponsINfoTable.IsMaintaince = false;
                        inWeaponsINfoTable.IsUse = false;
                    }
                    _db.SaveChanges();

                    transaction.Commit();
                    return _aModel.Respons(true, "New Maintaince Saved Successfully.");

                }
                return _aModel.Respons(true, "Oops something went wrong.");
            }
        }
        public ResponseModel GetAllGunAmmoMaintaince()
        {
            var data = from a in _db.I_MaintenanceInfo
                       join weapons in _db.I_WeaponsInfo on a.ItemId equals weapons.WeaponsInfoId
                       join nameOfgun in _db.M_NameOfWeapon on weapons.NameOfWeaponsId equals nameOfgun.NameOfGunId
                       where a.IsActive==true
                       select new
                       {
                           a.MaintainceCode,
                           nameOfgun.NameOfGun,
                           a.LastMaintainceDate,
                           a.MaintainceYear,
                           a.NextMaintainceSchadule,
                           a.IsActive,
                           a.SetUpBy,
                           a.SetUpDateTime
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadRegistrationNo(string weaponType)
        {
            var data = from parentMenu in _db.I_WeaponsInfo
                       where parentMenu.IsActive == true && parentMenu.WeaponsTypeId == weaponType && parentMenu.IsMaintaince==true
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
