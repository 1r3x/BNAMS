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
    public class DirectorateInfoManager : IDirectorateInfo
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
            if (aObj.DirectorateID == "0")
            {
                //for image
                if (aObj.Logo != null)
                {
                    aObj.Logo = "uploads/" + aObj.DirectorateName + aObj.Logo.Replace(@"/", ".");

                }
                aObj.DirectorateID = "DIR-" + (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                aObj.DirectorateCode = "DIR-" + DateTime.UtcNow.Second + _commonCode.RandomString(3, false);
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                aObj.IsBackup = false;
                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Directorate Saved Successfully.");
            }
            if (aObj.Logo != null)
            {
                var filterImage = aObj.Logo.Replace(@"uploads/", "");
                var filterImage1 = filterImage.Replace(aObj.DirectorateName, "");
                var filterImage2 = filterImage1.Replace(@".", "/");

                aObj.Logo = "uploads/" + aObj.DirectorateName + filterImage2.Replace(@"/", ".");

            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;
            aObj.IsBackup = false;
            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Directorate Updated Successfully");
        }

        public ResponseModel GetAllDirectorateInfo()
        {
            var data = from a in _db.O_DirectorateInfo
                       join b in _db.M_Area on a.AreaId equals b.AreaId
                       join c in _db.M_Authorirty on a.AdminAuthorityId equals c.AuthorityId
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
                           a.IsActive,

                           c.AuthorityId,
                           c.AuthorityName
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel CheckDuplicate(O_DirectorateInfo aObj)
        {
            var data = (from e in _db.O_DirectorateInfo
                        where e.DirectorateID != aObj.DirectorateID && e.DirectorateName == aObj.DirectorateName
                        select e.DirectorateID).Any();
            return data == true ? _aModel.Respons(true, "This Directorate already Exist") : _aModel.Respons(false, "");
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

        public ResponseModel LoadAdmin()
        {
            var data = from parentMenu in _db.M_Authorirty
                where parentMenu.IsActive == true
                select new
                {
                    id = parentMenu.AuthorityId,
                    text = parentMenu.AuthorityName
                };
            return _aModel.Respons(data);
        }
    }
}
