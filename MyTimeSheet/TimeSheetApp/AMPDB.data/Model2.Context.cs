﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMPDB.data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class APMDBEntities : DbContext
    {
        public APMDBEntities()
            : base("name=APMDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CleanFilesDetail> CleanFilesDetail { get; set; }
        public virtual DbSet<ECCategory> ECCategory { get; set; }
        public virtual DbSet<ECWriters> ECWriters { get; set; }
        public virtual DbSet<EPWriters> EPWriters { get; set; }
        public virtual DbSet<InternationalDir> InternationalDir { get; set; }
        public virtual DbSet<LockFiles> LockFiles { get; set; }
        public virtual DbSet<MapCountry> MapCountry { get; set; }
        public virtual DbSet<MapLanguage> MapLanguage { get; set; }
        public virtual DbSet<MapModule> MapModule { get; set; }
        public virtual DbSet<MapSector> MapSector { get; set; }
        public virtual DbSet<MapStatus> MapStatus { get; set; }
        public virtual DbSet<MapWS> MapWS { get; set; }
        public virtual DbSet<Mediargus> Mediargus { get; set; }
        public virtual DbSet<MediargusFTPExclude> MediargusFTPExclude { get; set; }
        public virtual DbSet<MediargusFTPStatus> MediargusFTPStatus { get; set; }
        public virtual DbSet<MoveFilesDetail> MoveFilesDetail { get; set; }
        public virtual DbSet<NewbaseServers> NewbaseServers { get; set; }
        public virtual DbSet<NewbaseServices> NewbaseServices { get; set; }
        public virtual DbSet<Parameters> Parameters { get; set; }
        public virtual DbSet<ProcessState> ProcessState { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<UICustomerMail> UICustomerMail { get; set; }
        public virtual DbSet<WSAccess> WSAccess { get; set; }
        public virtual DbSet<VCleanFiles> VCleanFiles { get; set; }
        public virtual DbSet<VECWriters> VECWriters { get; set; }
        public virtual DbSet<VEPWriters> VEPWriters { get; set; }
        public virtual DbSet<VMediargus> VMediargus { get; set; }
    }
}
