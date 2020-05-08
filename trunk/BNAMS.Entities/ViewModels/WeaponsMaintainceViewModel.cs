﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNAMS.Entities.ViewModels
{
    public class WeaponsMaintainceViewModel
    {
        //from weaponsInfoTable
        public string MaintainceId { get; set; }
        public string MaintainceCode { get; set; }
        public string ItemId { get; set; }
        public Nullable<System.DateTime> LastMaintainceDate { get; set; }
        public string MaintainceYear { get; set; }
        public string MaintainceDetails { get; set; }
        public string MaintainceLocation { get; set; }
        public string DefectInfo { get; set; }
        public string MaintainceTypeId { get; set; }
        public Nullable<System.DateTime> NextMaintainceSchadule { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> SetUpBy { get; set; }
        public Nullable<System.DateTime> SetUpDateTime { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDateTime { get; set; }
        public Nullable<bool> IsBackup { get; set; }
        public string DerectorateId { get; set; }
        //
        public string DepotId { get; set; }
        public string WareHouseId { get; set; }
        public string BinLOcationId { get; set; }

    }
}
