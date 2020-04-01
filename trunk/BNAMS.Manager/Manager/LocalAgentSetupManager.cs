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
    public class LocalAgentSetupManager:ILocalAgent
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<M_LocalAgent> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public LocalAgentSetupManager()
        {
            _aRepository = new GenericRepository<M_LocalAgent>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }

        public ResponseModel CreateLocalAgentSetup(M_LocalAgent aObj)
        {
            if (aObj.LocalAgentId == 0)
            {
                aObj.Code = "LA-" + DateTime.UtcNow.Second + _commonCode.RandomString(3, false);
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Local Agent Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;

            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Local Agent Updated Successfully");
        }

        public ResponseModel GetAllLocalAgentSetup()
        {
            var data = from a in _db.M_LocalAgent
                join b in _db.M_Country on a.Country equals b.CountryNameId
                select new
                {
                    a.Code,
                    a.LocalAgentId,
                    a.SupplierName,
                    a.Address,
                    a.ContractNumber,
                    a.Country,
                    a.Email,
                    a.EnlistmintType,
                    b.CountryName,
                    a.IsActive,
                    a.SetUpBy,
                    a.SetUpDateTime
                };
            return _aModel.Respons(data);
        }

        public ResponseModel CheckDuplicate(M_LocalAgent aObj)
        {
            var data = (from e in _db.M_LocalAgent
                where e.LocalAgentId != aObj.LocalAgentId && e.SupplierName == aObj.SupplierName
                select e.LocalAgentId).FirstOrDefault();
            return data != 0 ? _aModel.Respons(true, "This Agent already Exist") : _aModel.Respons(false, "");
        }

        public ResponseModel LoadCountry()
        {
            var data = from parentMenu in _db.M_Country
                where parentMenu.IsActive == true
                select new
                {
                    id = parentMenu.CountryNameId,
                    text = parentMenu.CountryName
                };
            return _aModel.Respons(data);
        }
    }
}
