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
    
    public partial class HR_TraningInformation
    {
        public string TrainingId { get; set; }
        public string TraningCode { get; set; }
        public string WeaponTypeId { get; set; }
        public string CourseName { get; set; }
        public string RefNo { get; set; }
        public string TraningPersonBioId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string CounryId { get; set; }
        public string OrganizationId { get; set; }
        public string LocalAbroadStatus { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> SetUpBy { get; set; }
        public Nullable<System.DateTime> SetUpDateTime { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDateTime { get; set; }
        public Nullable<bool> IsBackup { get; set; }
        public string DerectorateId { get; set; }
    }
}