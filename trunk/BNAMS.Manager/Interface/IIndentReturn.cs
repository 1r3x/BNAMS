using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface IIndentReturn
    {
        ResponseModel CreateIndentReturn(I_Indent aObj);
        ResponseModel GetAllIndent();
        ResponseModel LoadAllItem();
    }
}
