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
    
    public partial class I_Indent
    {
        public string IndentId { get; set; }
        public string IndentType { get; set; }
        public string ProgramId { get; set; }
        public string IndentNo { get; set; }
        public string IndentFrom { get; set; }
        public string IssueTo { get; set; }
        public string ItemId { get; set; }
        public Nullable<int> IndentQuantity { get; set; }
        public Nullable<System.DateTime> IndentValidity { get; set; }
        public string OtherOptions { get; set; }
        public string Remarks { get; set; }
        public string IndentStatusId { get; set; }
        public Nullable<System.DateTime> IndentStatusDate { get; set; }
        public string CompositeId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> IsStatus { get; set; }
        public Nullable<int> SetUpBy { get; set; }
        public Nullable<System.DateTime> SetUpDateTime { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDateTime { get; set; }
        public Nullable<bool> IsBackup { get; set; }
        public string DerectorateId { get; set; }
        public Nullable<System.DateTime> LastBackupDate { get; set; }
    }
}
