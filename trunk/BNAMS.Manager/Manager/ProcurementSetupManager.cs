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
    public class ProcurementSetupManager:IProcurementSetup
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<M_ProcurementCategory> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public ProcurementSetupManager()
        {
            _aRepository = new GenericRepository<M_ProcurementCategory>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }

        public ResponseModel CreateProcurementSetup(M_ProcurementCategory aObj)
        {
            if (aObj.ProcurementId == 0)
            {
                aObj.ProcurementCode = "MOD-" + DateTime.UtcNow.Second + _commonCode.RandomString(3, false);
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Procurement Catagory Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;

            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Procurement Catagory Updated Successfully");
        }
        
        public ResponseModel GetAllProcurementSetup()
        {
            var data = from a in _db.M_ProcurementCategory
                select new
                {
                    a.ProcurementCode,
                    a.ProcurementId,
                    a.ProcurementName,
                    a.CreateDate,
                    a.IsActive,
                    a.SetUpBy,
                    a.SetUpDateTime
                };
            return _aModel.Respons(data);
        }

        public ResponseModel CheckDuplicate(M_ProcurementCategory aObj)
        {
            var data = (from e in _db.M_ProcurementCategory
                where e.ProcurementId != aObj.ProcurementId && e.ProcurementName == aObj.ProcurementName
                select e.ProcurementId).FirstOrDefault();
            return data != 0 ? _aModel.Respons(true, "This Procurement Category already Exist") : _aModel.Respons(false, "");
        }
    }
}
