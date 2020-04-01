using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface ICountrySetup
    {
        ResponseModel CreateCountrySetup(M_Country aObj);
        ResponseModel GetAllCountrySetup();
        ResponseModel CheckDuplicate(M_Country aObj);
    }
}
