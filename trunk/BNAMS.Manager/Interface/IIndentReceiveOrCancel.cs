using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface IIndentReceiveOrCancel
    {
        ResponseModel CreateIndentReceive(I_Indent aObj);
        ResponseModel CreateIndentCancel(I_Indent aObj);
        ResponseModel GetAllIndent();
    }
}
