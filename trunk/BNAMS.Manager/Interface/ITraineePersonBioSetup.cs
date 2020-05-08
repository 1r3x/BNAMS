using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface ITraineePersonBioSetup
    {
        ResponseModel CreateTraineeBio(HR_TraineePersonBio aObj);
        ResponseModel GetAllTraineeBio();
        ResponseModel CheckDuplicate(HR_TraineePersonBio aObj);
        ResponseModel LoadRank();
    }
}
