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
    public class QuantitySetupManager:IQuantitySetup
    {

        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<M_QuantityCategory> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public QuantitySetupManager()
        {
            _aRepository = new GenericRepository<M_QuantityCategory>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }


        public ResponseModel CreateQuantitySetup(M_QuantityCategory aObj)
        {
            if (aObj.QuantityId == "0")
            {
                aObj.QuantityId = (string)HttpContext.Current.Session["directorateId"] + "-QU-" + (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                aObj.QuantityCode = "QU-" + DateTime.UtcNow.Second + _commonCode.RandomString(3, false);
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                aObj.IsBackup = false;
                aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];
                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Quantity Catagory Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;
            aObj.IsBackup = false;
            aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];

            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Quantity Catagory Updated Successfully");
        }

        public ResponseModel GetAllQuantitySetup()
        {
            var data = from a in _db.M_QuantityCategory
                select new
                {
                    a.QuantityCode,
                    a.QuantityId,
                    a.QuantityName,
                    a.CreateDate,
                    a.IsActive,
                    a.SetUpBy,
                    a.SetUpDateTime
                };
            return _aModel.Respons(data);
        }

        public ResponseModel CheckDuplicate(M_QuantityCategory aObj)
        {
            var data = (from e in _db.M_QuantityCategory
                where e.QuantityId != aObj.QuantityId && e.QuantityName == aObj.QuantityName
                select e.QuantityId).Any();
            return data == true ? _aModel.Respons(true, "This Quantity Category already Exist") : _aModel.Respons(false, "");
        }
    }
}
