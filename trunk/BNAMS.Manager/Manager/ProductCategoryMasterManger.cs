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
    public class ProductCategoryMasterManger:IProductCaegoryMaster
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<M_ProductCategory> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public ProductCategoryMasterManger()
        {
            _aRepository = new GenericRepository<M_ProductCategory>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }


        public ResponseModel CreateProductCaegoryMasterSetup(M_ProductCategory aObj)
        {
            if (aObj.ProductCategoryId == "0")
            {
                aObj.ProductCategoryId = "PROD-" + (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                aObj.IsBackup = false;
                aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];
                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Product Category Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;
            aObj.IsBackup = false;
            aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];

            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Product Category Updated Successfully");
        }

        public ResponseModel GetAllProductCaegoryMasterSetup()
        {
            var data = from a in _db.M_ProductCategory
                select new
                {
                    a.ProductCategoryId,
                    a.DerectorateId,
                    a.ProductCtegoryName,
                    a.IsActive,
                    a.SetUpBy,
                    a.SetUpDateTime
                };
            return _aModel.Respons(data);
        }

        public ResponseModel CheckDuplicate(M_ProductCategory aObj)
        {
            var data = (from e in _db.M_ProductCategory
                where e.ProductCategoryId != aObj.ProductCategoryId && e.ProductCtegoryName == aObj.ProductCtegoryName
                select e.ProductCategoryId).Any();
            return data == true ? _aModel.Respons(true, "This Category already Exist") : _aModel.Respons(false, "");
        }
    }
}
