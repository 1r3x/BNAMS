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
    public class CapabilityOfWaeponsSetupManager:ICapabilityOfWaeponsSetup
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<M_CapabilityOfWeapons> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public CapabilityOfWaeponsSetupManager()
        {
            _aRepository = new GenericRepository<M_CapabilityOfWeapons>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }



        public ResponseModel CreateCapabilityOfWaeponsSetup(M_CapabilityOfWeapons aObj)
        {
            if (aObj.CapabilityOfWeaponsID == "0")
            {
                aObj.CapabilityOfWeaponsID = (string)HttpContext.Current.Session["directorateId"] + "-CAP-" + (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                aObj.CapabilityCode = "CAP-" + DateTime.UtcNow.Second + _commonCode.RandomString(3, false);
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                aObj.IsBackup = false;
                aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];
                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Capability Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;
            aObj.IsBackup = false;
            aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];

            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Capability Updated Successfully");
        }

        public ResponseModel GetAllCapabilityOfWaeponsSetup()
        {
            var data = from a in _db.M_CapabilityOfWeapons
                select new
                {
                    a.CapabilityCode,
                    a.CapabilityOfWeaponsID,
                    a.CapabilityName,
                    a.Email,
                    a.Telephone,
                    a.IsActive,
                    a.SetUpBy,
                    a.SetUpDateTime
                };
            return _aModel.Respons(data);
        }

        public ResponseModel CheckDuplicate(M_CapabilityOfWeapons aObj)
        {
            var data = (from e in _db.M_CapabilityOfWeapons
                where e.CapabilityOfWeaponsID != aObj.CapabilityOfWeaponsID && e.CapabilityName == aObj.CapabilityName
                select e.CapabilityOfWeaponsID).Any();
            return data == true ? _aModel.Respons(true, "This Capability already Exist") : _aModel.Respons(false, "");
        }
    }
}
