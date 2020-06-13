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
    public class FiscalYearSetupManager:IFiscalYearSetup
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<M_FiscalYear> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public FiscalYearSetupManager()
        {
            _aRepository = new GenericRepository<M_FiscalYear>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }


        public ResponseModel CreateFiscalYear(M_FiscalYear aObj)
        {
            if (aObj.FiscalYearId =="0")
            {
                aObj.FiscalYearId = (string)HttpContext.Current.Session["directorateId"] +"-FIS-"+ (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                aObj.FiscalYearCode ="FIS-"+DateTime.UtcNow.Second+ _commonCode.RandomString(3, false);
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                aObj.IsBackup = false;
                aObj.DerectorateId = (string) HttpContext.Current.Session["directorateId"];
                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Fiscal Year Saved Successfully.");
            }

            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;
            aObj.IsBackup = false;
            aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];
            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Fiscal Year Updated Successfully");
        }

        public ResponseModel GetAllFiscalYear()
        {
            var data = from a in _db.M_FiscalYear
                select new
                {
                    a.FiscalYearId,
                    a.FiscalYearCode,
                    a.Name,
                    a.StartDate,
                    a.EndDate,
                    a.ShortName,
                    a.IsActive,
                    a.SetUpBy,
                    a.SetUpDateTime
                };
            return _aModel.Respons(data);
        }

        public ResponseModel CheckDuplicate(M_FiscalYear aObj)
        {
            var data = (from e in _db.M_FiscalYear
                where e.FiscalYearId != aObj.FiscalYearId && e.ShortName == aObj.ShortName && e.Name == aObj.Name
                select e.FiscalYearId).Any();
            return data == true ? _aModel.Respons(true, "This Fiscal Year already Exist") : _aModel.Respons(false, "");
        }
    }
}
