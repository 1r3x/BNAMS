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
    public class WareHouseManager:IWareHouseInfo
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<O_WareHouse> _aRepository;
        private readonly SmartRecordEntities _db;
        private readonly CommonManager _commonCode;

        public WareHouseManager()
        {
            _aRepository = new GenericRepository<O_WareHouse>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
            _commonCode = new CommonManager();
        }



        public ResponseModel CreateWareHouse(O_WareHouse aObj)
        {
            if (aObj.WareHouseId == "0")
            {
                var row = from a in _db.O_WareHouse

                    select a;
                var count = row.Count();
                aObj.WareHouseId = (string)HttpContext.Current.Session["directorateId"] + "-WAR-" + (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                aObj.WareHouseCode = Convert.ToString(count+1);
                aObj.SetUpBy = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                aObj.IsBackup = false;
                aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];
                _aRepository.Insert(aObj);
                _aRepository.Save();


                return _aModel.Respons(true, "New Warehouse Saved Successfully.");
            }
            aObj.UpdatedBy = (int?)HttpContext.Current.Session["userid"];
            aObj.UpdatedDateTime = DateTime.Now;
            aObj.IsBackup = false;
            aObj.DerectorateId = (string)HttpContext.Current.Session["directorateId"];

            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Warehouse Updated Successfully");
        }

        public ResponseModel GetAllWareHouse()
        {
            var data = from a in _db.O_WareHouse
                join typ in _db.M_WareHouseType on a.WareHouseTypeId equals typ.WareHouseTypeId
                join unit in _db.O_ShipOrDepotInfo on a.UnitShipId equals unit.ShipOrDepotId
                select new
                {
                    a.WareHouseCode,
                    a.WareHouseName,
                    a.IsActive,
                    a.WareHouseId,
                    a.UnitShipId,
                    a.Address1,
                    a.Address2,
                    a.ProcessDate,
                    a.SetUpBy,
                    a.SetUpDateTime,
                    a.WareHouseTypeId,
                    a.ProgramName,
                    typ.WarHouseType,
                    unit.ShipDepotName
                };
            return _aModel.Respons(data);
        }

        public ResponseModel CheckDuplicate(O_WareHouse aObj)
        {
            var data = (from e in _db.O_WareHouse
                where e.WareHouseId != aObj.WareHouseId && e.WareHouseName == aObj.WareHouseName
                select e.WareHouseId).Any();
            return data == true ? _aModel.Respons(true, "This Warhouse already Exist") : _aModel.Respons(false, "");
        }

        public ResponseModel LoadWareHouseType()
        {
            var data = from parentMenu in _db.M_WareHouseType
                where parentMenu.IsActive == true
                select new
                {
                    id = parentMenu.WareHouseTypeId,
                    text = parentMenu.WarHouseType
                };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadUnitDepotShip()
        {
            var data = from parentMenu in _db.O_ShipOrDepotInfo
                join directorate in _db.O_DirectorateInfo on parentMenu.DirectorateId equals directorate.DirectorateID
                where parentMenu.IsActive == true
                select new
                {
                    id = parentMenu.ShipOrDepotId,
                    text = parentMenu.ShipDepotName+" ("+directorate.DirectorateName+")"
                };
            return _aModel.Respons(data);
        }
    }
}
