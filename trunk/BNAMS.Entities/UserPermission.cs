//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SR.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserPermission
    {
        public int PermId { get; set; }
        public int RoleId { get; set; }
        public int MenuId { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
        public bool IsCreate { get; set; }
    }
}
