using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface IBinLocation
    {
        ResponseModel CreateBinLocation(I_BinLocation aObj);
        ResponseModel GetAllBinLocation();
        ResponseModel CheckDuplicate(I_BinLocation aObj);
        ResponseModel LoadProductCategory();
        ResponseModel LoadWareHouseByCode(string wareHouseCode);
    }
}
