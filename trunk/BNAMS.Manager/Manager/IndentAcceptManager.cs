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
    public class IndentAcceptManager:IIndentAccept
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<I_Indent> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public IndentAcceptManager()
        {
            _aRepository = new GenericRepository<I_Indent>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }



        public ResponseModel CreateIndentReceive(I_Indent aObj)
        {
            var inWeaponsINfoTable = (from a in _db.I_WeaponsInfo
                                      where a.WeaponsInfoId == aObj.ItemId
                                      select a).SingleOrDefault();

            if (inWeaponsINfoTable != null)
            {
                //inWeaponsINfoTable.Quantity -= aObj.IndentQuantity;
                //inWeaponsINfoTable.IsUse = false;
                inWeaponsINfoTable.IsBackup = false;
            }
            _db.SaveChanges();


            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;
            aObj.IsBackup = false;
            aObj.IsActive = false;
            aObj.IsStatus = 3;// 3 for received
            aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];

            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Indent Received Successfully");
        }

        public ResponseModel CreateIndentCancel(I_Indent aObj)
        {
            var inWeaponsINfoTable = (from a in _db.I_WeaponsInfo
                where a.WeaponsInfoId == aObj.ItemId
                select a).SingleOrDefault();

            if (inWeaponsINfoTable != null)
            {
                inWeaponsINfoTable.Quantity += aObj.IndentQuantity;
                inWeaponsINfoTable.IsBackup = false;
            }

            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;
            aObj.IsStatus = 4;//4 for received cancell
            aObj.IsBackup = false;
            aObj.IsActive = false;
            aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];

            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Indent Cancelled Successfully");
        }

        public ResponseModel GetAllIndent()
        {

            var dirId = (string) HttpContext.Current.Session["directorateId"];

            var data = from a in _db.I_Indent
                join b in _db.O_ShipOrDepotInfo on a.IndentFrom equals b.ShipOrDepotId
                join c in _db.O_ShipOrDepotInfo on a.IssueTo equals c.ShipOrDepotId
                join d in _db.I_WeaponsInfo on a.ItemId equals d.WeaponsInfoId
                join e in _db.M_NameOfWeapon on d.NameOfWeaponsId equals e.NameOfGunId
                join f in _db.M_Composite on a.CompositeId equals f.CompositeId

                where a.IsActive == true && a.DerectorateId== dirId && a.IsStatus==1
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
                    a.IsStatus,
                    a.IssueTo,
                    a.ItemId,
                    a.OtherOptions

                };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadAllItem()
        {
            var data = from parentMenu in _db.I_WeaponsInfo
                where parentMenu.IsActive == true
                select new
                {
                    id = parentMenu.WeaponsInfoId,
                    text = parentMenu.RegistrationNo
                };
            return _aModel.Respons(data);
        }
    }
}
