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
    public class GunModelTypeSetupManager:IGunModel
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<M_GunModelType> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public GunModelTypeSetupManager()
        {
            _aRepository = new GenericRepository<M_GunModelType>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }


        public ResponseModel CreateGunModelTypeSetup(M_GunModelType aObj)
        {
            if (aObj.GunModelId == 0)
            {
                aObj.GunModelCode = "MOD-" + DateTime.UtcNow.Second + _commonCode.RandomString(3, false);
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Gun Model Type Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;

            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Gun Model Updated Successfully");
        }

        public ResponseModel GetAllGunModelTypeSetup()
        {
            var data = from a in _db.M_GunModelType
                select new
                {
                    a.GunModelCode,
                    a.GunModelId,
                    a.GunModelName,
                    a.ShortName,
                    a.CreateDate,
                    a.IsActive,
                    a.SetUpBy,
                    a.SetUpDateTime
                };
            return _aModel.Respons(data);
        }

        public ResponseModel CheckDuplicate(M_GunModelType aObj)
        {
            var data = (from e in _db.M_GunModelType
                where e.GunModelId != aObj.GunModelId && e.GunModelName == aObj.GunModelName
                select e.GunModelId).FirstOrDefault();
            return data != 0 ? _aModel.Respons(true, "This Gun Model Type already Exist") : _aModel.Respons(false, "");
        }
    }
}
