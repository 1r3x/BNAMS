using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface IProductCaegoryMaster
    {
        ResponseModel CreateProductCaegoryMasterSetup(M_ProductCategory aObj);

        ResponseModel GetAllProductCaegoryMasterSetup();

        ResponseModel CheckDuplicate(M_ProductCategory aObj);
    }
}
