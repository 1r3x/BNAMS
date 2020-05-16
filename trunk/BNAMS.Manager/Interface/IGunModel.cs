﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNAMS.Entities;

namespace BNAMS.Manager.Interface
{
    public interface IGunModel
    {
        ResponseModel CreateGunModelTypeSetup(M_WeaponsModelType aObj);
        ResponseModel GetAllGunModelTypeSetup();
        ResponseModel CheckDuplicate(M_WeaponsModelType aObj);
        ResponseModel LoadWeaponsType();
    }
}