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
    public class TraineePersonBioSetupManager:ITraineePersonBioSetup
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<HR_TraineePersonBio> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public TraineePersonBioSetupManager()
        {
            _aRepository = new GenericRepository<HR_TraineePersonBio>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }

        public ResponseModel CreateTraineeBio(HR_TraineePersonBio aObj)
        {
            if (aObj.TraningPersonId == "0")
            {
                aObj.TraningPersonId = (string)HttpContext.Current.Session["directorateId"] + "-TRAIN-" + (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                aObj.BioDataCode = "TRAIN-" + DateTime.UtcNow.Second + _commonCode.RandomString(3, false);
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                aObj.IsBackup = false;
                aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];
                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Trainee Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;
            aObj.IsBackup = false;
            aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];
            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Trainee Updated Successfully");
        }

        public ResponseModel GetAllTraineeBio()
        {
            var data = from a in _db.HR_TraineePersonBio
                join b in _db.M_RankSetup on a.RankId equals b.RankSetupId
                select new
                {
                    b.RankName,
                    a.BioDataCode,
                    a.RankId,
                    a.TraningPersonId,
                    a.DerectorateId,
                    a.Pno,
                    a.Name,
                    a.SetUpBy,
                    a.SetUpDateTime,
                    a.IsActive
                };
            return _aModel.Respons(data);
        }

        public ResponseModel CheckDuplicate(HR_TraineePersonBio aObj)
        {
            var data = (from e in _db.HR_TraineePersonBio
                where e.TraningPersonId != aObj.TraningPersonId && e.Pno == aObj.Pno
                select e.TraningPersonId).Any();
            return data == true ? _aModel.Respons(true, "This P.NO//O.NO  Already Exist") : _aModel.Respons(false, "");
        }

        public ResponseModel LoadRank()
        {
            var data = from parentMenu in _db.M_RankSetup
                where parentMenu.IsActive == true
                select new
                {
                    id = parentMenu.RankSetupId,
                    text = parentMenu.RankName
                };
            return _aModel.Respons(data);
        }
    }
}
