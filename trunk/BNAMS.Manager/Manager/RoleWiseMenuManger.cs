using BNAMS.Entities;
using BNAMS.Manager.Interface;

namespace BNAMS.Manager.Manager
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
