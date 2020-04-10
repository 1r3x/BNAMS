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
    public class CountrySetupManager:ICountrySetup
    {

        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<M_Country> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public CountrySetupManager()
        {
            _aRepository = new GenericRepository<M_Country>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }
        public ResponseModel CreateCountrySetup(M_Country aObj)
        {
            if (aObj.CountryNameId == "0")
            {
                aObj.CountryNameId = (string)HttpContext.Current.Session["directorateId"] + "-CON-" + (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                aObj.CountryCode = "CON-" + DateTime.UtcNow.Second + _commonCode.RandomString(3, false);
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                aObj.IsBackup = false;
                aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];


                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Country Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;
            aObj.IsBackup = false;
            aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];


            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Country Updated Successfully");
        }

        public ResponseModel GetAllCountrySetup()
        {
            var data = from a in _db.M_Country
                select new
                {
                    a.CountryCode,
                    a.CountryName,
                    a.ShortName,
                    a.CountryNameId,
                    a.DollerType,
                    a.CreateDate,
                    a.IsActive,
                    a.SetUpBy,
                    a.SetUpDateTime
                };
            return _aModel.Respons(data);
        }

        public ResponseModel CheckDuplicate(M_Country aObj)
        {
            var data = (from e in _db.M_Country
                where e.CountryNameId != aObj.CountryNameId && e.CountryName == aObj.CountryName
                select e.CountryNameId).Any();
            return data == true ? _aModel.Respons(true, "This Country already Exist") : _aModel.Respons(false, "");
        }
    }
}
