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
        private readonly IGenericRepository<M_NameOfWeapon> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public NameOfGunSetupManager()
        {
            _aRepository = new GenericRepository<M_NameOfWeapon>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }


        public ResponseModel CreateNameOfGunSetup(M_NameOfWeapon aObj)
        {
            if (aObj.NameOfGunId == "0")
            {
                aObj.NameOfGunId = (string)HttpContext.Current.Session["directorateId"] + "-GN-" + (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                aObj.NameOfGunCode = "GN-" + DateTime.UtcNow.Second + _commonCode.RandomString(3, false);
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                aObj.IsBackup = false;
                aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];
                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Weapon Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;
            aObj.IsBackup = false;
            aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];

            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Weapon Updated Successfully");
        }

        public ResponseModel GetAllNameOfGunSetup()
        {
            var data = from a in _db.M_NameOfWeapon
                join b in _db.M_WeaponsType on a.WeaponsTypeId equals b.WeaponsTypeId
                       select new
                {
                    a.NameOfGunCode,
                    a.NameOfGunId,
                    a.NameOfGun,
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

        public ResponseModel CheckDuplicate(M_NameOfWeapon aObj)
        {
            var data = (from e in _db.M_NameOfWeapon
                        where e.NameOfGunId != aObj.NameOfGunId && e.NameOfGun == aObj.NameOfGun
                select e.NameOfGunId).Any();
            return data == true ? _aModel.Respons(true, "This Weapon Name already Exist") : _aModel.Respons(false, "");
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
