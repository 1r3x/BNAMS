﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNAMS.Manager.Interface
{
    public interface IBackupPlan
    {
        string GetFullBackupScript();
        string UpdateAllIsBackupStatus();
    }
}