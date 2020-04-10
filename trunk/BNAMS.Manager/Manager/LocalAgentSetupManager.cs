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
    public class LocalAgentSetupManager : ILocalAgent
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<M_Agent> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public LocalAgentSetupManager()
        {
            _aRepository = new GenericRepository<M_Agent>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }

        public ResponseModel CreateLocalAgentSetup(M_Agent aObj)
        {
            if (aObj.LocalAgentId == "0")
            {
                aObj.LocalAgentId = (string)HttpContext.Current.Session["directorateId"] + "-LA-" + (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                aObj.Code = "LA-" + DateTime.UtcNow.Second + _commonCode.RandomString(3, false);
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                aObj.IsBackup = false;
                aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];
                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Local Agent Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;
            aObj.IsBackup = false;
            aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];

            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Local Agent Updated Successfully");
        }

        public ResponseModel GetAllLocalAgentSetup()
        {
            var data = from a in _db.M_Agent
                       join b in _db.M_Country on a.Country equals b.CountryNameId
                       join c in _db.M_AgentType on a.AgentTypeId equals c.AgentTypeId
                       join d in _db.M_AgentEnlistment on a.EnlistmintType equals d.EnlistmentTypeId

                       select new
                       {
                           a.Code,
                           a.LocalAgentId,
                           a.SupplierName,
                           a.Address,
                           a.ContractNumber,
                           a.Country,
                           a.Email,
                           b.CountryName,
                           a.IsActive,
                           a.SetUpBy,
                           a.SetUpDateTime,
                           c.AgentType,
                           c.AgentTypeId,
                           d.EnlistmentType,
                           d.EnlistmentTypeId
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel CheckDuplicate(M_Agent aObj)
        {
            var data = (from e in _db.M_Agent
                        where e.LocalAgentId != aObj.LocalAgentId && e.SupplierName == aObj.SupplierName
                        select e.LocalAgentId).Any();
            return data == true ? _aModel.Respons(true, "This Agent already Exist") : _aModel.Respons(false, "");
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

        public ResponseModel LoadAgentType()
        {
            var data = from parentMenu in _db.M_AgentType
                       where parentMenu.IsActive == true
                       select new
                       {
                           id = parentMenu.AgentTypeId,
                           text = parentMenu.AgentType
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadEstimationTypeType()
        {
            var data = from parentMenu in _db.M_AgentEnlistment
                       where parentMenu.IsActive == true
                       select new
                       {
                           id = parentMenu.EnlistmentTypeId,
                           text = parentMenu.EnlistmentType
                       };
            return _aModel.Respons(data);
        }
    }
}
