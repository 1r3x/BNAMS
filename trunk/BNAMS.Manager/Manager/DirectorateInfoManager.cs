using System;
using System.Linq;
using System.Web;
using BNAMS.Entities;
using BNAMS.Manager.Common;
using BNAMS.Manager.Interface;
using BNAMS.Repositories;
using SR.Repositories;

namespace BNAMS.Manager.Manager
{
    public class DirectorateInfoManager:IDirectorateInfo
    {

        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<O_DirectorateInfo> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public DirectorateInfoManager()
        {
            _aRepository = new GenericRepository<O_DirectorateInfo>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }
        public ResponseModel CreateDirectorateInfo(O_DirectorateInfo aObj)
        {
            if (aObj.DirectorateID == 0)
            {
                //for image
                if (aObj.Logo!=null)
                {
                    aObj.Logo = "uploads/" + aObj.DirectorateName + aObj.Logo.Replace(@"/", ".");

                }

                aObj.DirectorateCode = "DIR-" + DateTime.UtcNow.Second + _commonCode.RandomString(3, false);
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Directorate Saved Successfully.");
            }
            if (aObj.Logo != null)
            {
                aObj.Logo = "uploads/" + aObj.DirectorateName + aObj.Logo.Replace(@"/", ".");

            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;

            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Directorate Updated Successfully");
        }

        public ResponseModel GetAllDirectorateInfo()
        {
            var data = from a in _db.O_DirectorateInfo
                join b in _db.M_Area on a.AreaId equals b.AreaId
                select new
                {
                    a.DirectorateID,
                    a.DirectorateCode,
                    a.DirectorateName,
                    a.AreaId,
                    //this id for area
                    b.AreaName,
                    a.Address,
                    a.FaxNumber,
                    a.TelephoneNumber,
                    a.WebAddress,
                    a.Logo,
                    a.SetUpBy,
                    a.SetUpDateTime,
                    a.IsActive
                };
            return _aModel.Respons(data);
        }

        public ResponseModel CheckDuplicate(O_DirectorateInfo aObj)
        {
            var data = (from e in _db.O_DirectorateInfo
                where e.DirectorateID != aObj.DirectorateID && e.DirectorateName == aObj.DirectorateName
                select e.DirectorateID).FirstOrDefault();
            return data != 0 ? _aModel.Respons(true, "This Directorate already Exist") : _aModel.Respons(false, "");
        }

        public ResponseModel LoadArea()
        {
            var data = from parentMenu in _db.M_Area
                where parentMenu.IsActive == true
                select new
                {
                    id = parentMenu.AreaId,
                    text = parentMenu.AreaName
                };
            return _aModel.Respons(data);
        }
    }
}
