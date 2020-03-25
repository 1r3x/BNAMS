using System;
using System.Linq;
using System.Web;
using BNAMS.Entities;
using BNAMS.Manager.Interface;
using BNAMS.Repositories;
using SR.Repositories;

namespace BNAMS.Manager.Manager
{
    public class MenuManager : IMenu
    {
        private readonly ResponseModel _aModel;
        private readonly IGenericRepository<M_Menu> _aRepository;
        private readonly SmartRecordEntities _db;

        public MenuManager()
        {
            _aRepository = new GenericRepository<M_Menu>();
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
        }


        public ResponseModel CreateMenu(M_Menu aObj)
        {
            if (aObj.Id == 0)
            {
                if (aObj.ParentId == null)
                {
                    aObj.ParentId = 0;
                }
                aObj.SetUpUserId = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime = DateTime.Now;
                aObj.IsActive = true;
                _aRepository.Insert(aObj);
                _aRepository.Save();

                //for sorting order generation 
                if (aObj.ParentId == 0)
                {
                    var sortingOrder = aObj.Id;
                    aObj.SortingOrderHelper = sortingOrder;
                    _aRepository.Update(aObj);
                    _aRepository.Save();

                }
                else
                {
                    var sortingOrder = aObj.ParentId;
                    aObj.SortingOrderHelper = sortingOrder;
                    _aRepository.Update(aObj);
                    _aRepository.Save();
                }
                //end


                return _aModel.Respons(true, "New Menu Saved Successfully.");
            }
            if (aObj.ParentId == null)
            {
                aObj.ParentId = 0;
                aObj.SortingOrderHelper = aObj.Id;
            }
            else
            {
                aObj.SortingOrderHelper = aObj.ParentId;
            }
            aObj.UpdateUserId = 1;
            aObj.UpdateDateTime = DateTime.Now;
            _aRepository.Update(aObj);
            _aRepository.Save();
            return _aModel.Respons(true, "Menu Updated Successfully");
        }

        public ResponseModel GetAllMenu()
        {
            var data = from a in _db.M_Menu
                       select new
                       {
                           a.Id,
                           a.ParentId,
                           a.MenuName,
                           a.MenuId,
                           a.MenuClass,
                           a.MenuUrl,
                           a.IsActive
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel LoadParentMenu()
        {
            var data = from parentMenu in _db.M_Menu
                       where parentMenu.ParentId == 0 && parentMenu.IsActive == true
                       select new
                       {
                           id = parentMenu.Id,
                           text = parentMenu.MenuName
                       };
            return _aModel.Respons(data);
        }

        public ResponseModel CheckDuplicate(M_Menu aObj)
        {
            var data=(from e in _db.M_Menu
                             where e.Id != aObj.Id && e.MenuName == aObj.MenuName
                             select e.Id).FirstOrDefault();
            return data!=0 ? _aModel.Respons(true, "This Menu On this Parent Exist") : _aModel.Respons(false, "");
        }
    }
}
