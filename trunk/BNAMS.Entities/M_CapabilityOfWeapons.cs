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
    
    public partial class M_CapabilityOfWeapons
    {
        public string CapabilityOfWeaponsID { get; set; }
        public string CapabilityCode { get; set; }
        public string CapabilityName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> SetUpBy { get; set; }
        public Nullable<System.DateTime> SetUpDateTime { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDateTime { get; set; }
        public Nullable<bool> IsBackup { get; set; }
        public string DerectorateId { get; set; }
    }
}