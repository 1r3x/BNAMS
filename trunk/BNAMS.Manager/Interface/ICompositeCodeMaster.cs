using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface ICompositeCodeMaster
    {
        ResponseModel CreateCompositeCodeMasterSetup(M_Composite aObj);

        ResponseModel GetAllCompositeCodeMasterSetup();

        ResponseModel CheckDuplicate(M_Composite aObj);
    }
}
