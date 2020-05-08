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
    public class StatusAfterMaintainceManager : IStatusAfterMaintaince
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<I_StatusAfterMaintaince> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public StatusAfterMaintainceManager()
        {
            _aRepository = new GenericRepository<I_StatusAfterMaintaince>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }


        public ResponseModel CreateStatusAfterMaintaince(I_StatusAfterMaintaince aObj)
        {
            if (aObj.AfterMaintainceStatusId == "0")
            {
                var previousStatusAfterMaintaince = (from a in _db.I_StatusAfterMaintaince
                    where a.WeaponsInfoId == aObj.WeaponsInfoId && a.IsActive == true
                    select a).SingleOrDefault();

                if (previousStatusAfterMaintaince != null)
                {

                    previousStatusAfterMaintaince.IsActive = false;
                }
                _db.SaveChanges();

                aObj.AfterMaintainceStatusId = (string)HttpContext.Current.Session["directorateId"] + "-MN-" + (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                aObj.AfterMaintainceStatusCode = "MN-" + DateTime.UtcNow.Second + _commonCode.RandomString(3, false);
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                aObj.IsBackup = false;
                aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];
                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New After Maintaince Status Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;
            aObj.IsBackup = false;
            aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];

            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "After Maintaince Status Updated Successfully");
        }

        public ResponseModel GetAllStatusAfterMaintaince()
        {
            var data = from a in _db.I_StatusAfterMaintaince
                       join weapons in _db.I_WeaponsInfo on a.WeaponsInfoId equals weapons.WeaponsInfoId
                       join nameOfgun in _db.M_NameOfWeapon on weapons.NameOfWeaponsId equals nameOfgun.NameOfGunId
                       join status in _db.M_MaintainceStatus_c_ on a.MaintainceStatusId equals status.MaintainceStatusId
                       where a.IsActive==true
                       select new
                       {
                           nameOfgun.NameOfGun,
                           a.AfterMaintainceStatusId,
                           a.AfterMaintainceStatusCode,
                           a.WeaponsInfoId,
                           a.Remarks,
                           a.MaintainceStatusId,
                           status.Status,
                           a.IsActive,
                           a.SetUpBy,
                           a.SetUpDateTime
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadRegistrationNo()
        {
            var data = from parentMenu in _db.I_WeaponsInfo
                       where parentMenu.IsActive == true && parentMenu.WeaponsTypeId== "1042020WEAP137"
                             //only gun id from constant table
                       select new
                       {
                           id = parentMenu.WeaponsInfoId,
                           text = parentMenu.RegistrationNo
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadMaintainceDetailsByRegistrationNo(string weaponsInfoId)
        {
            var data = from parentMenu in _db.I_MaintenanceInfo
                where parentMenu.IsActive == true && parentMenu.ItemId==weaponsInfoId
                select new
                {
                    parentMenu.MaintainceDetails,
                    parentMenu.DefectInfo
                };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadStatus()
        {
            var data = from parentMenu in _db.M_MaintainceStatus_c_
                       where parentMenu.IsActive == true
                       select new
                       {
                           id = parentMenu.MaintainceStatusId,
                           text = parentMenu.Status
                       };
            return _aModel.Respons(data);
        }
    }
}
