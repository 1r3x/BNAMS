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
    public class BinLocationManager : IBinLocation
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<I_BinLocation> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public BinLocationManager()
        {
            _aRepository = new GenericRepository<I_BinLocation>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }

        public ResponseModel CreateBinLocation(I_BinLocation aObj)
        {
            if (aObj.BinLocationId == "0")
            {
                aObj.BinLocationId = (string)HttpContext.Current.Session["directorateId"] + "-BIN-" + (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                aObj.IsBackup = false;
                aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];


                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Bin Location Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;
            aObj.IsBackup = false;
            aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];

            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Bin Location Updated Successfully");
        }

        public ResponseModel GetAllBinLocation()
        {
            var data = from a in _db.I_BinLocation
                       join wareHouse in _db.O_WareHouse on a.WareHouseId equals wareHouse.WareHouseId
                       join productCat in _db.M_ProductCategory on a.ProductCategoryId equals productCat.ProductCategoryId
                       select new
                       {
                           a.WareHouseId,
                           a.BinLocationId,
                           a.ProductCategoryId,
                           a.RowIdNo,
                           a.SelfIdNo,
                           a.IsActive,
                           a.ProcessDate,
                           a.SetUpBy,
                           a.SetUpDateTime,
                           a.ProgramName,
                           wareHouse.WareHouseName,
                           wareHouse.WareHouseCode,
                           productCat.ProductCtegoryName
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel CheckDuplicate(I_BinLocation aObj)
        {
            throw new NotImplementedException();
        }

        public ResponseModel LoadProductCategory()
        {
            var data = from parentMenu in _db.M_ProductCategory
                where parentMenu.IsActive == true
                select new
                {
                    id = parentMenu.ProductCategoryId,
                    text = parentMenu.ProductCtegoryName
                };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadWareHouseByCode(string wareHouseCode)
        {
            var data = from parentMenu in _db.O_WareHouse
                where parentMenu.IsActive == true && parentMenu.WareHouseCode==wareHouseCode
                select new
                {
                    parentMenu.WareHouseId,
                    parentMenu.WareHouseName,
                };
            return _aModel.Respons(data);
        }
    }
}
