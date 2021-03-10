using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNAMS.Manager.Interface
{
    public interface IIndentHistory
    {
        ResponseModel GetAllIndent(string weaponType, string weaponName, string weaponModel);
    }
}
