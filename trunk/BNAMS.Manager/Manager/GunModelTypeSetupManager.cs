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
        private readonly IGenericRepository<M_WeaponsModelType> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public GunModelTypeSetupManager()
        {
            _aRepository = new GenericRepository<M_WeaponsModelType>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }


        public ResponseModel CreateGunModelTypeSetup(M_WeaponsModelType aObj)
        {
            if (aObj.GunModelId == "0")
            {
                aObj.GunModelId = (string)HttpContext.Current.Session["directorateId"] + "-MOD-" + (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                aObj.GunModelCode = "MOD-" + DateTime.UtcNow.Second + _commonCode.RandomString(3, false);
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                aObj.IsBackup = false;
                aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];


                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Gun Model Type Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;
            aObj.IsBackup = false;
            aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];

            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Gun Model Updated Successfully");
        }

        public ResponseModel GetAllGunModelTypeSetup()
        {
            var data = from a in _db.M_WeaponsModelType
                join b in _db.M_WeaponsType on a.WeaponsTypeId equals b.WeaponsTypeId
                       select new
                {
                    a.GunModelCode,
                    a.GunModelId,
                    a.GunModelName,
                    a.ShortName,
                    a.CreateDate,
                    a.IsActive,
                    a.SetUpBy,
                    a.SetUpDateTime,
                    b.WeaponsTypeId,
                    b.WeaponsType
                };
            return _aModel.Respons(data);
        }

        public ResponseModel CheckDuplicate(M_WeaponsModelType aObj)
        {
            var data = (from e in _db.M_WeaponsModelType
                        where e.GunModelId != aObj.GunModelId && e.GunModelName == aObj.GunModelName
                select e.GunModelId).Any();
            return data == true ? _aModel.Respons(true, "This Gun Model Type already Exist") : _aModel.Respons(false, "");
        }

        public ResponseModel LoadWeaponsType()
        {
            var data = from parentMenu in _db.M_WeaponsType
                where parentMenu.IsActive == true
                select new
                {
                    id = parentMenu.WeaponsTypeId,
                    text = parentMenu.WeaponsType
                };
            return _aModel.Respons(data);
        }
    }
}
