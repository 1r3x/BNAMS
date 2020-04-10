using System;
using System.Linq;
using System.Web;
using BNAMS.Entities;
using BNAMS.Manager.Common;
using BNAMS.Manager.Interface;
using BNAMS.Repositories;
using SR.Repositories;

namespace BNAMS.Manager.Manager
{
    public class ShipOrDepotManager:IShipOrDepotSetup
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<O_ShipOrDepotInfo> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public ShipOrDepotManager()
        {
            _aRepository = new GenericRepository<O_ShipOrDepotInfo>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }

        public ResponseModel CreateShipOrDepotSetup(O_ShipOrDepotInfo aObj)
        {
            if (aObj.ShipOrDepotId == "0")
            {
                aObj.ShipOrDepotId = (string)HttpContext.Current.Session["directorateId"] + "-SHIP-" + (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                aObj.ShipOrDepotCode = "SHIP-" + DateTime.UtcNow.Second + _commonCode.RandomString(3, false);
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                aObj.IsBackup = false;
                aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];

                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Ship/Depot Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;
            aObj.IsBackup = false;
            aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];


            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Ship/Depot Updated Successfully");
        }

        public ResponseModel GetAllShipOrDepotSetup()
        {
            var data = from a in _db.O_ShipOrDepotInfo
                join auth in _db.M_Authorirty on a.AuthorityId equals auth.AuthorityId
                join cap in _db.M_CapabilityOfWeapons on a.CapabilityOfWeaponsId equals cap.CapabilityOfWeaponsID
                join type in _db.M_TypeOfShip on a.TypeOfShip equals type.ShipTypeId
                join cat in _db.M_DepotShipCategory on a.ShipDepotCategory equals cat.CategoryId
                select new
                {
                    a.ShipOrDepotId,
                    a.ShipOrDepotCode,
                    a.AuthorityId,
                    a.CapabilityOfWeaponsId,
                    a.DateOfCommmisson,
                    a.FaxNo,
                    a.Email,
                    a.Telephone,
                    a.IsActive,
                    a.SetUpBy,
                    a.SetUpDateTime,
                    a.ShipDepotName,
                    a.ShipDepotCategory,
                    a.WTCallSign,
                    a.WebAddress,
                    a.TypeOfShip,
                    auth.AuthorityName,
                    cap.CapabilityName,
                    type.TypeName,
                    cat.CategoryName
                };
            return _aModel.Respons(data);
        }

        public ResponseModel CheckDuplicate(O_ShipOrDepotInfo aObj)
        {
            var data = (from e in _db.O_ShipOrDepotInfo
                where e.ShipOrDepotId != aObj.ShipOrDepotId && e.ShipDepotName == aObj.ShipDepotName
                select e.ShipOrDepotId).Any();
            return data == true ? _aModel.Respons(true, "This Ship Or Depot already Exist") : _aModel.Respons(false, "");
        }

        public ResponseModel LoadShipOrdepotCategory()
        {
            var data = from parentMenu in _db.M_DepotShipCategory
                where parentMenu.IsActive == true
                select new
                {
                    id = parentMenu.CategoryId,
                    text = parentMenu.CategoryName
                };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadShipOrdepoType()
        {
            var data = from parentMenu in _db.M_TypeOfShip
                where parentMenu.IsActive == true
                select new
                {
                    id = parentMenu.ShipTypeId,
                    text = parentMenu.TypeName
                };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadCapbilityOfWeapons()
        {
            var data = from parentMenu in _db.M_CapabilityOfWeapons
                where parentMenu.IsActive == true
                select new
                {
                    id = parentMenu.CapabilityOfWeaponsID,
                    text = parentMenu.CapabilityName
                };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadAdminAuth()
        {
            var data = from parentMenu in _db.M_Authorirty
                where parentMenu.IsActive == true
                select new
                {
                    id = parentMenu.AuthorityId,
                    text = parentMenu.AuthorityName
                };
            return _aModel.Respons(data);
        }
    }
}
