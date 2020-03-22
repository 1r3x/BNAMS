using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR.Entities;
using SR.Manager.Interface;
using SR.Repositories;

namespace SR.Manager.Manager
{

    public class RoleWiseMenuManger: IRoleWiseMenu
    {
        private readonly ResponseModel _aModel;
        private readonly SmartRecordEntities _db;

        public RoleWiseMenuManger()
        {
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
        }

        public ResponseModel GetAllMenuByRoleId(int roleId)
        {
            var data = _db.spRoleWiseMenu(roleId);
            return _aModel.Respons(data);
        }
    }
}
