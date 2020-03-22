using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SR.Entities;
using SR.Manager.Interface;
using SR.Repositories;

namespace SR.Manager.Manager
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
