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
    public class IndentManager : IIndent

    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<I_Indent> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public IndentManager()
        {
            _aRepository = new GenericRepository<I_Indent>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }
        public ResponseModel CreateIndent(I_Indent aObj)
        {
            if (aObj.IndentId == "0")
            {

                var inWeaponsINfoTable = (from a in _db.I_WeaponsInfo
                                          where a.WeaponsInfoId == aObj.ItemId
                                          select a).SingleOrDefault();

                if (inWeaponsINfoTable != null)
                {
                    //inWeaponsINfoTable.IsUse = true;
                    inWeaponsINfoTable.IsBackup = false;
                }
                _db.SaveChanges();



                var previousIndent = (from a in _db.I_Indent
                                      where a.ItemId == aObj.ItemId && a.IsActive == true
                                      select a).SingleOrDefault();

                //check if it is ammo
                var isAmmoData = from a in _db.I_WeaponsInfo
                    join weaponTable in _db.M_WeaponsType on a.WeaponsTypeId equals weaponTable.WeaponsTypeId
                    where weaponTable.WeaponsTypeId == "1042020WEAP139"
                    select a;
                var isAmmo = isAmmoData.Count();

                if (previousIndent != null)
                {
                    previousIndent.IsActive = false;
                }
                _db.SaveChanges();
                var row = from a in _db.I_Indent
                          where a.IsActive == true
                          select a;
                var count = row.Count();


                if (isAmmo==0)
                {
                    aObj.IndentQuantity = 1;
                }

                aObj.IndentId = (string)HttpContext.Current.Session["directorateId"] + "-INS-" + (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                aObj.IndentNo = Convert.ToString(count + 1);
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                aObj.IsBackup = false;
                aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];
                _aRepository.Insert(aObj);
                _aRepository.Save();

                return _aModel.Respons(true, "New Indent Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;
            aObj.IsBackup = false;
            aObj.IsActive = true;
            aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];

            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Indent Updated Successfully");
        }


        public ResponseModel GetAllIndent()
        {
            var data = from a in _db.I_Indent
                       join b in _db.O_ShipOrDepotInfo on a.IndentFrom equals b.ShipOrDepotId
                       join c in _db.O_ShipOrDepotInfo on a.IssueTo equals c.ShipOrDepotId
                       join d in _db.I_WeaponsInfo on a.ItemId equals d.WeaponsInfoId
                       join e in _db.M_NameOfWeapon on d.NameOfWeaponsId equals e.NameOfGunId
                       join f in _db.M_Composite on a.CompositeId equals f.CompositeId

                       where a.IsActive == true
                       select new
                       {
                           indentFrom = b.ShipDepotName,
                           issueTo = c.ShipDepotName,
                           e.NameOfGun,
                           f.CompositeName,
                           a.ProgramId,
                           a.IndentNo,
                           a.CompositeId,
                           a.DerectorateId,
                           a.IndentFrom,
                           a.IndentId,
                           a.IndentQuantity,
                           a.IndentStatusDate,
                           a.IndentStatusId,
                           a.IndentType,
                           a.IndentValidity,
                           a.IsActive,
                           a.IssueTo,
                           a.ItemId,
                           a.OtherOptions

                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadAllDepotAndShipForIndentFrom()
        {
            var data = from parentMenu in _db.O_ShipOrDepotInfo
                       join directorate in _db.O_DirectorateInfo on parentMenu.DerectorateId equals directorate.DirectorateID
                       where parentMenu.IsActive == true
                       select new
                       {
                           id = parentMenu.ShipOrDepotId,
                           text = parentMenu.ShipDepotName + " (" + directorate.DirectorateName + ")"
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadAllDepotAndShipForIssue()
        {
            var data = from parentMenu in _db.O_ShipOrDepotInfo
                       join directorate in _db.O_DirectorateInfo on parentMenu.DerectorateId equals directorate.DirectorateID
                       where parentMenu.IsActive == true
                       select new
                       {
                           id = parentMenu.ShipOrDepotId,
                           text = parentMenu.ShipDepotName + " (" + directorate.DirectorateName + ")"
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadItemCode(string depotShipId)
        {
            var data = from parentMenu in _db.I_WeaponsInfo
                       where parentMenu.IsActive == true && parentMenu.DepotId == depotShipId &&
                             parentMenu.IsUse == false
                       select new
                       {
                           id = parentMenu.WeaponsInfoId,
                           text = parentMenu.RegistrationNo
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadItemDetails(string itemId)
        {
            var data = from parentMenu in _db.I_WeaponsInfo
                       join gunNAme in _db.M_NameOfWeapon on parentMenu.NameOfWeaponsId equals gunNAme.NameOfGunId
                       join localAget in _db.M_Agent on parentMenu.LocalAgentId equals localAget.LocalAgentId
                       where parentMenu.IsActive == true && parentMenu.WeaponsInfoId == itemId
                       select new
                       {
                           gunNAme.NameOfGun,
                           localAget.SupplierName
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadCompositCode()
        {
            var data = from parentMenu in _db.M_Composite
                       where parentMenu.IsActive == true
                       select new
                       {
                           id = parentMenu.CompositeId,
                           text = parentMenu.CompositeCode
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadCompositNameByCompositId(string compositCodeId)
        {
            var data = from parentMenu in _db.M_Composite
                       where parentMenu.IsActive == true && parentMenu.CompositeId == compositCodeId
                       select new
                       {
                           parentMenu.CompositeName
                       };
            return _aModel.Respons(data);
        }



        public ResponseModel LoadIndentType()
        {
            var data = from parentMenu in _db.M_IndentType
                       where parentMenu.IsActive == true
                       select new
                       {
                           id = parentMenu.IndentTypeId,
                           text = parentMenu.IndentTypeName
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel CheckIsItAmmo(string itemId)
        {
            var isAmmoData = from a in _db.I_WeaponsInfo
                join weaponTable in _db.M_WeaponsType on a.WeaponsTypeId equals weaponTable.WeaponsTypeId
                where weaponTable.WeaponsTypeId == "1042020WEAP139"
                select a;
            var data = isAmmoData.Any();
            return _aModel.Respons(data);
        }
    }
}
