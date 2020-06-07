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
    public class CompositeCodeManager:ICompositeCodeMaster
    {

        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<M_Composite> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public CompositeCodeManager()
        {
            _aRepository = new GenericRepository<M_Composite>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }


        public ResponseModel CreateCompositeCodeMasterSetup(M_Composite aObj)
        {
            if (aObj.CompositeId == "0")
            {
                aObj.CompositeId = "COMP-" + (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                aObj.IsBackup = false;
                aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];
                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Composite Code Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;
            aObj.IsBackup = false;
            aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];

            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Composite Code Updated Successfully");
        }

        public ResponseModel GetAllCompositeCodeMasterSetup()
        {
            var data = from a in _db.M_Composite
                select new
                {
                    a.CompositeId,
                    a.DerectorateId,
                    a.CompositeCode,
                    a.CompositeName,
                    a.IsActive,
                    a.SetUpBy,
                    a.SetUpDateTime
                };
            return _aModel.Respons(data);
        }

        public ResponseModel CheckDuplicate(M_Composite aObj)
        {
            var data = (from e in _db.M_Composite
                where e.CompositeId != aObj.CompositeId && e.CompositeCode == aObj.CompositeCode
                select e.CompositeId).Any();
            return data == true ? _aModel.Respons(true, "This Composite Code already Exist") : _aModel.Respons(false, "");
        }
    }
}
