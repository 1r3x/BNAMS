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
    public class TrainingInfoManager:ITrainingInfo
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<HR_TraningInformation> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public TrainingInfoManager()
        {
            _aRepository = new GenericRepository<HR_TraningInformation>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }

        public ResponseModel CreateTrainingInfo(HR_TraningInformation aObj)
        {
            if (aObj.TrainingId == "0")
            {
                aObj.TrainingId = (string)HttpContext.Current.Session["directorateId"] + "-TRA-" + (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                aObj.TraningCode = "TRA-" + DateTime.UtcNow.Second + _commonCode.RandomString(3, false);
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                aObj.IsBackup = false;
                aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];
                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Training Info Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;
            aObj.IsBackup = false;
            aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];
            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Training Info Updated Successfully");
        }

        public ResponseModel GetAllTrainingInfo()
        {
            var data = from a in _db.HR_TraningInformation
                join b in _db.M_WeaponsType on a.WeaponTypeId equals b.WeaponsTypeId
                join c in _db.HR_TraineePersonBio on a.TraningPersonBioId equals c.TraningPersonId

                select new
                {
                    b.WeaponsType,
                    c.Pno,
                    a.RefNo,
                    a.TrainingId,
                    a.TraningCode,
                    a.TraningPersonBioId,
                    a.CounryId,
                    a.DerectorateId,
                    a.EndDate,
                    a.StartDate,
                    a.CourseName,
                    a.WeaponTypeId,
                    a.OrganizationId,
                    a.LocalAbroadStatus,
                    a.SetUpBy,
                    a.SetUpDateTime,
                    a.IsActive
                };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadEquipment()
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

        public ResponseModel LoadPNO()
        {
            var data = from parentMenu in _db.HR_TraineePersonBio
                where parentMenu.IsActive == true
                select new
                {
                    id = parentMenu.TraningPersonId,
                    text = parentMenu.Pno
                };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadCounry()
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

        public ResponseModel LoadTraningOrg()
        {
            var data = from parentMenu in _db.M_TraningOrg
                where parentMenu.IsActive == true
                select new
                {
                    id = parentMenu.TraningOrgId,
                    text = parentMenu.OrgName
                };
            return _aModel.Respons(data);
        }
    }
}
