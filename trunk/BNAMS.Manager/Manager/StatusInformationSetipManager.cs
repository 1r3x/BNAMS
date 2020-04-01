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
    public class StatusInformationSetipManager:IStatusInformationSetup
    {

        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<M_StatusInformation> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public StatusInformationSetipManager()
        {
            _aRepository = new GenericRepository<M_StatusInformation>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }
        public ResponseModel CreateStatusInformationSetup(M_StatusInformation aObj)
        {
            if (aObj.StatusId == 0)
            {
                aObj.StatusCode = "ST-" + DateTime.UtcNow.Second + _commonCode.RandomString(3, false);
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Status Information Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;

            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Status Information Updated Successfully");
        }

        public ResponseModel GetAllStatusInformationSetup()
        {
            var data = from a in _db.M_StatusInformation
                select new
                {
                    a.StatusCode,
                    a.StatusId,
                    a.StatusName,
                    a.ShortName,
                    a.CreateDate,
                    a.IsActive,
                    a.SetUpBy,
                    a.SetUpDateTime
                };
            return _aModel.Respons(data);
        }

        public ResponseModel CheckDuplicate(M_StatusInformation aObj)
        {
            var data = (from e in _db.M_StatusInformation
                where e.StatusId != aObj.StatusId && e.StatusName == aObj.StatusName
                select e.StatusId).FirstOrDefault();
            return data != 0 ? _aModel.Respons(true, "This status Information already Exist") : _aModel.Respons(false, "");
        }
    }
}
