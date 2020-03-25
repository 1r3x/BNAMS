using BNAMS.Entities;
using SR.Manager.Interface;

namespace BNAMS.Manager.Manager
{
    public class HomeManager : IHome
    {
        private readonly ResponseModel _aModel;
        private readonly SmartRecordEntities _db;

        public HomeManager()
        {
            _db = new SmartRecordEntities();
            _aModel = new ResponseModel();
        }

        
    }
}
