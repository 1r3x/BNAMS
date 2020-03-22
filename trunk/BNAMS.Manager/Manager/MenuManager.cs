using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SR.Entities;
using SR.Manager.Interface;
using SR.Repositories;

namespace SR.Manager.Manager
{
    public class MenuManager:IMenu
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
                if (aObj.ParentId==null)
                {
                    aObj.ParentId = 0;
                }
                aObj.SetUpUserId = (int?)HttpContext.Current.Session["userid"];
                aObj.SetUpDateTime=DateTime.Now;
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


                return _aModel.Respons(true, "New Policy Saved Successfully.");
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
            return _aModel.Respons(true, "Policy Updated Successfully");
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
                       where parentMenu.ParentId == 0 && parentMenu.IsActive==true
                       select new
                       {
                           id = parentMenu.Id,
                           text = parentMenu.MenuName
                       };
            return _aModel.Respons(data);
        }

    }
}
