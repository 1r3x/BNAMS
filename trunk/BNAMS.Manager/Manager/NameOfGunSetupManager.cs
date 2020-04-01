using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
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
    public class NameOfGunSetupManager:INameOfGunSetup
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<M_NameOfGun> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public NameOfGunSetupManager()
        {
            _aRepository = new GenericRepository<M_NameOfGun>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }


        public ResponseModel CreateNameOfGunSetup(M_NameOfGun aObj)
        {
            if (aObj.NameOfGunId == 0)
            {
                aObj.NameOfGunCode = "GN-" + DateTime.UtcNow.Second + _commonCode.RandomString(3, false);
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Gun Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;

            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "New Gun Updated Successfully");
        }

        public ResponseModel GetAllNameOfGunSetup()
        {
            var data = from a in _db.M_NameOfGun
                select new
                {
                    a.NameOfGunCode,
                    a.NameOfGunId,
                    a.NameOfGun,
                    a.ShortName,
                    a.CreateDate,
                    a.IsActive,
                    a.SetUpBy,
                    a.SetUpDateTime
                };
            return _aModel.Respons(data);
        }

        public ResponseModel CheckDuplicate(M_NameOfGun aObj)
        {
            var data = (from e in _db.M_NameOfGun
                where e.NameOfGunId != aObj.NameOfGunId && e.NameOfGun == aObj.NameOfGun
                select e.NameOfGunId).FirstOrDefault();
            return data != 0 ? _aModel.Respons(true, "This Gun Name already Exist") : _aModel.Respons(false, "");
        }
    }
}
