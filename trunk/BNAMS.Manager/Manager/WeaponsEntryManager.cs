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
    public class WeaponsEntryManager : IWeaponsEntry
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<I_WeaponsInfo> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public WeaponsEntryManager()
        {
            _aRepository = new GenericRepository<I_WeaponsInfo>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }

        public ResponseModel CreateWeaponsItem(I_WeaponsInfo aObj)
        {
            var quantity = from a in _db.I_WeaponsInfo
                           where a.IsActive == true && a.WeaponsTypeId == aObj.WeaponsTypeId
                                                    && a.NameOfWeaponsId == aObj.NameOfWeaponsId
                           select new
                           {
                               a.WeaponsInfoId
                           };

            var trackingNo = 0;
            if (quantity.Any())
            {
                trackingNo = Convert.ToInt32(quantity.Count());
            }

            if (aObj.Image != null)
            {
                aObj.Image = "uploads/" + (string)HttpContext.Current.Session["directorateId"] + aObj.WeaponsTypeId + aObj.NameOfWeaponsId + aObj.Image.Replace(@"/", ".");

            }
            var maxQuantity = trackingNo + 1;
            var actualEntry = Convert.ToInt32(aObj.Quantity);
            for (var i = 0; i < actualEntry; i++)
            {
                //for image
                
                aObj.WeaponsInfoId = (string)HttpContext.Current.Session["directorateId"] + "-W-" + (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds + "-W-" + maxQuantity + i;
                aObj.TrackingNo = Convert.ToString(maxQuantity + i);
                aObj.SetUpDateTime = DateTime.Now;
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.IsActive = true;
                aObj.IsBackup = false;
                aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];

                _aRepository.Insert(aObj);
                _aRepository.Save();
            }
            return _aModel.Respons(true, "New Stock Entry Successfully.");
        }

        public ResponseModel GetWeaponsByWeaponType(string weaponId)
        {
            var data = from a in _db.I_WeaponsInfo
                join b in _db.M_WeaponsType on a.WeaponsTypeId equals b.WeaponsTypeId
                join c in _db.M_NameOfWeapon on a.NameOfWeaponsId equals c.NameOfGunId
                       where a.WeaponsTypeId==weaponId
                       select new
                       {
                           b.WeaponsType,
                           c.NameOfGun,
                           a.IsActive,
                           a.TrackingNo

                       };
            return _aModel.Respons(data);
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

        public ResponseModel LoadWeaponsByType(string weaponsTypeId)
        {
            var data = from parentMenu in _db.M_NameOfWeapon
                       where parentMenu.IsActive == true && parentMenu.WeaponsTypeId == weaponsTypeId
                       select new
                       {
                           id = parentMenu.NameOfGunId,
                           text = parentMenu.NameOfGun
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadWeaponModelByWeaponId(string weaponsTypeId)
        {
            var data = from parentMenu in _db.M_WeaponsModelType
                       where parentMenu.IsActive == true && parentMenu.WeaponsTypeId == weaponsTypeId
                       select new
                       {
                           id = parentMenu.GunModelId,
                           text = parentMenu.GunModelName
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadFiscalYear()
        {
            var data = from parentMenu in _db.M_FiscalYear
                       where parentMenu.IsActive == true
                       select new
                       {
                           id = parentMenu.FiscalYearId,
                           text = parentMenu.FiscalYearCode
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadCountry()
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

        public ResponseModel LoadPriceType()
        {
            var data = from parentMenu in _db.M_PriceType
                       where parentMenu.IsActive == true
                       select new
                       {
                           id = parentMenu.PriceTypeId,
                           text = parentMenu.PriceType
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadLocalAgent()
        {
            //local agent code is 0942020944Ag
            var data = from parentMenu in _db.M_Agent
                       where parentMenu.IsActive == true && parentMenu.AgentTypeId == "0942020944Ag"
                       select new
                       {
                           id = parentMenu.LocalAgentId,
                           text = parentMenu.SupplierName
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadPrincipalAgent()
        {
            //local agent code is 0942020945Ag
            var data = from parentMenu in _db.M_Agent
                       where parentMenu.IsActive == true && parentMenu.AgentTypeId == "0942020945Ag"
                       select new
                       {
                           id = parentMenu.LocalAgentId,
                           text = parentMenu.SupplierName
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadManuAgent()
        {
            //local agent code is 0942020946Ag
            var data = from parentMenu in _db.M_Agent
                       where parentMenu.IsActive == true && parentMenu.AgentTypeId == "0942020946Ag"
                       select new
                       {
                           id = parentMenu.LocalAgentId,
                           text = parentMenu.SupplierName
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadQuantityCategory()
        {
            var data = from parentMenu in _db.M_QuantityCategory
                       where parentMenu.IsActive == true
                       select new
                       {
                           id = parentMenu.QuantityId,
                           text = parentMenu.QuantityName
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadDepot()
        {
            var data = from parentMenu in _db.O_ShipOrDepotInfo
                       where parentMenu.IsActive == true
                       select new
                       {
                           id = parentMenu.ShipOrDepotId,
                           text = parentMenu.ShipDepotName
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadProcurementCategory()
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

        public ResponseModel LoadWareHouse()
        {
            var data = from parentMenu in _db.O_WareHouse
                       where parentMenu.IsActive == true
                       select new
                       {
                           id = parentMenu.WareHouseId,
                           text = parentMenu.WareHouseName
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadShelfNameByWraehouseId(string warehouseId)
        {
            var data = from parentMenu in _db.I_BinLocation
                       where parentMenu.IsActive == true && parentMenu.WareHouseId == warehouseId
                       select new
                       {
                           id = parentMenu.BinLocationId,
                           text = parentMenu.SelfIdNo
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadRowNameByWraehouseId(string warehouseId)
        {
            var data = from parentMenu in _db.I_BinLocation
                       where parentMenu.IsActive == true && parentMenu.WareHouseId == warehouseId
                       select new
                       {
                           id = parentMenu.BinLocationId,
                           text = parentMenu.RowIdNo
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadStatus()
        {
            var data = from parentMenu in _db.M_StatusInformation
                       where parentMenu.IsActive == true
                       select new
                       {
                           id = parentMenu.StatusId,
                           text = parentMenu.StatusName
                       };
            return _aModel.Respons(data);
        }
    }
}
