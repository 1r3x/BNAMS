//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BNAMS.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class I_StatusAfterMaintaince
    {
        public string AfterMaintainceStatusId { get; set; }
        public string AfterMaintainceStatusCode { get; set; }
        public string WeaponsInfoId { get; set; }
        public string MaintainceStatusId { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> SetUpBy { get; set; }
        public Nullable<System.DateTime> SetUpDateTime { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDateTime { get; set; }
        public Nullable<bool> IsBackup { get; set; }
        public string DerectorateId { get; set; }
        public Nullable<System.DateTime> LastBackupDate { get; set; }
    }
}
