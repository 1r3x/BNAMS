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
    public class AuthoritySetupManager : IAuthoritySetup
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<M_Authorirty> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public AuthoritySetupManager()
        {
            _aRepository = new GenericRepository<M_Authorirty>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }


        public ResponseModel CreateAuthority(M_Authorirty aObj)
        {
            if (aObj.AuthorityId == 0)
            {
                aObj.AuthorityCode = "AUTH-" + DateTime.UtcNow.Second + _commonCode.RandomString(3, false);
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Authority Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;

            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Authority Updated Successfully");
        }

        public ResponseModel GetAllAuthority()
        {
            var data = from a in _db.M_Authorirty
                       join b in _db.M_Area on a.AreaId equals b.AreaId
                       select new
                       {
                           a.AuthorityId,
                           a.AuthorityCode,
                           a.AuthorityName,
                           a.AreaId,
                           b.AreaName,
                           a.Contract,
                           a.Email,
                           a.IsActive
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel CheckDuplicate(M_Authorirty aObj)
        {
            var data = (from e in _db.M_Authorirty
                        where e.AuthorityId != aObj.AuthorityId && e.AuthorityName == aObj.AuthorityName
                        select e.AuthorityId).FirstOrDefault();
            return data != 0 ? _aModel.Respons(true, "This Authority already Exist") : _aModel.Respons(false, "");
        }

        public ResponseModel LoadArea()
        {
            var data = from parentMenu in _db.M_Area
                       where  parentMenu.IsActive == true
                       select new
                       {
                           id = parentMenu.AreaId,
                           text = parentMenu.AreaName
                       };
            return _aModel.Respons(data);

        }
    }
}
