using BNAMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNAMS.Manager.Interface
{
    public interface IDirectorateInfo
    {
        ResponseModel CreateDirectorateInfo(O_DirectorateInfo aObj);
        ResponseModel GetAllDirectorateInfo();
        ResponseModel CheckDuplicate(O_DirectorateInfo aObj);
        ResponseModel LoadArea();
        ResponseModel LoadAdmin();
    }
}
