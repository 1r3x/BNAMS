﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SmartRecordEntities : DbContext
    {
        public SmartRecordEntities()
            : base("name=SmartRecordEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<I_BinLocation> I_BinLocation { get; set; }
        public virtual DbSet<M_Agent> M_Agent { get; set; }
        public virtual DbSet<M_AgentEnlistment> M_AgentEnlistment { get; set; }
        public virtual DbSet<M_AgentType> M_AgentType { get; set; }
        public virtual DbSet<M_Area> M_Area { get; set; }
        public virtual DbSet<M_Authorirty> M_Authorirty { get; set; }
        public virtual DbSet<M_CapabilityOfWeapons> M_CapabilityOfWeapons { get; set; }
        public virtual DbSet<M_Country> M_Country { get; set; }
        public virtual DbSet<M_DepotShipCategory> M_DepotShipCategory { get; set; }
        public virtual DbSet<M_FiscalYear> M_FiscalYear { get; set; }
        public virtual DbSet<M_Menu> M_Menu { get; set; }
        public virtual DbSet<M_NameOfWeapon> M_NameOfWeapon { get; set; }
        public virtual DbSet<M_ProcurementCategory> M_ProcurementCategory { get; set; }
        public virtual DbSet<M_ProductCategory> M_ProductCategory { get; set; }
        public virtual DbSet<M_QuantityCategory> M_QuantityCategory { get; set; }
        public virtual DbSet<M_StatusInformation> M_StatusInformation { get; set; }
        public virtual DbSet<M_TypeOfShip> M_TypeOfShip { get; set; }
        public virtual DbSet<M_WareHouseType> M_WareHouseType { get; set; }
        public virtual DbSet<M_WeaponsModelType> M_WeaponsModelType { get; set; }
        public virtual DbSet<M_WeaponsType> M_WeaponsType { get; set; }
        public virtual DbSet<O_DirectorateInfo> O_DirectorateInfo { get; set; }
        public virtual DbSet<O_ShipOrDepotInfo> O_ShipOrDepotInfo { get; set; }
        public virtual DbSet<O_WareHouse> O_WareHouse { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<M_PriceType> M_PriceType { get; set; }
        public virtual DbSet<I_WeaponsInfo> I_WeaponsInfo { get; set; }
    
        public virtual ObjectResult<SessionHelper_Result> SessionHelper(Nullable<int> empId)
        {
            var empIdParameter = empId.HasValue ?
                new ObjectParameter("empId", empId) :
                new ObjectParameter("empId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SessionHelper_Result>("SessionHelper", empIdParameter);
        }
    
        public virtual ObjectResult<spGetAllSelectedMenuAndSubMenu_Result> spGetAllSelectedMenuAndSubMenu(Nullable<int> roleId)
        {
            var roleIdParameter = roleId.HasValue ?
                new ObjectParameter("roleId", roleId) :
                new ObjectParameter("roleId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetAllSelectedMenuAndSubMenu_Result>("spGetAllSelectedMenuAndSubMenu", roleIdParameter);
        }
    
        public virtual ObjectResult<Validate_User_Result> Validate_User(string username, string password)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Validate_User_Result>("Validate_User", usernameParameter, passwordParameter);
        }
    
        public virtual ObjectResult<spRoleWiseMenu_Result> spRoleWiseMenu(Nullable<int> roleId)
        {
            var roleIdParameter = roleId.HasValue ?
                new ObjectParameter("roleId", roleId) :
                new ObjectParameter("roleId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spRoleWiseMenu_Result>("spRoleWiseMenu", roleIdParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<spNotVerifiedAddress_Result> spNotVerifiedAddress()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spNotVerifiedAddress_Result>("spNotVerifiedAddress");
        }
    
        public virtual ObjectResult<spVerifiedAddress_Result> spVerifiedAddress()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spVerifiedAddress_Result>("spVerifiedAddress");
        }
    }
}
