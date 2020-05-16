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
    public class InspactionManager : IInspection
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<W_Inspection> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public InspactionManager()
        {
            _aRepository = new GenericRepository<W_Inspection>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }
        public ResponseModel CreateInspection(W_Inspection aObj)
        {
            if (aObj.InspectionId == "0")
            {
                var previousInspection = (from a in _db.W_Inspection
                                          where a.ItemId == aObj.ItemId && a.IsActive == true
                                          select a).SingleOrDefault();

                if (previousInspection != null)
                {
                    previousInspection.IsActive = false;
                }
                _db.SaveChanges();

                aObj.InspectionId = (string)HttpContext.Current.Session["directorateId"] + "-INS-" + (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                aObj.ProgramId = "INS-" + DateTime.UtcNow.Second + _commonCode.RandomString(3, false);
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                aObj.IsBackup = false;
                aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];
                _aRepository.Insert(aObj);
                _aRepository.Save();

                return _aModel.Respons(true, "New Inspaction Maintaince Status Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;
            aObj.IsBackup = false;
            aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];

            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "After Inspaction Status Updated Successfully");
        }

        public ResponseModel GetInspectionAll()
        {
            var data = from a in _db.W_Inspection
                       join b in _db.O_ShipOrDepotInfo on a.DepotId equals b.ShipOrDepotId
                       join c in _db.M_WeaponsType on a.ItemCategoryId equals c.WeaponsTypeId
                       join d in _db.I_WeaponsInfo on a.ItemId equals d.WeaponsInfoId
                       join e in _db.M_NameOfWeapon on d.NameOfWeaponsId equals e.NameOfGunId
                       where a.IsActive == true
                       select new
                       {
                           b.ShipDepotName,
                           c.WeaponsType,
                           e.NameOfGun,
                           a.INstallDate,
                           a.NextInspectionDate,
                           a.InspectionBy,
                           a.InspectionDate,
                           a.Commence,
                           a.IsActive,
                           a.ItemId,
                           a.InspectionId,
                           a.ProgramId,
                           a.DepotId,
                           a.DerectorateId,
                           a.InspectionMethod,
                           a.InstallAt,
                           a.ItemCategoryId,
                           a.InstallBy,
                           a.SetUpBy,
                           a.SetUpDateTime
                       };
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

        public ResponseModel LoadItemType()
        {
            var data = from parentMenu in _db.M_WeaponsType
                       where parentMenu.IsActive == true
                       select new
                       {
                           id = parentMenu.WeaponsTypeId,
                           text = parentMenu.WeaponsType
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadRegistrationNo(string itemTypeId, string depotId)
        {
            var data = from parentMenu in _db.I_WeaponsInfo
                       where parentMenu.IsActive == true && parentMenu.WeaponsTypeId == itemTypeId && parentMenu.DepotId == depotId
                       select new
                       {
                           id = parentMenu.WeaponsInfoId,
                           text = parentMenu.RegistrationNo
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadWeaponDetails(string itemId)
        {
            var data = from parentMenu in _db.I_WeaponsInfo
                       join a in _db.M_Agent on parentMenu.LocalAgentId equals a.LocalAgentId
                       join b in _db.M_NameOfWeapon on parentMenu.NameOfWeaponsId equals b.NameOfGunId
                       where parentMenu.IsActive == true && parentMenu.WeaponsInfoId == itemId

                       select new
                       {
                           parentMenu.WarrantyPeriod,
                           a.SupplierName,
                           b.NameOfGun
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadLastMaintainceDate(string itemId)
        {
            var data = from parentMenu in _db.I_MaintenanceInfo
                       where parentMenu.IsActive == true && parentMenu.ItemId == itemId
                       select new
                       {
                           parentMenu.LastMaintainceDate
                       };
            return _aModel.Respons(data);
        }
    }
}
