﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tvt_project2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TVTEntities : DbContext
    {
        public TVTEntities()
            : base("name=TVTEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CT_HOA_DON> CT_HOA_DON { get; set; }
        public virtual DbSet<HOA_DON> HOA_DON { get; set; }
        public virtual DbSet<KHACH_HANG> KHACH_HANG { get; set; }
        public virtual DbSet<LOAI_SAN_PHAM> LOAI_SAN_PHAM { get; set; }
        public virtual DbSet<QUAN_TRI> QUAN_TRI { get; set; }
        public virtual DbSet<SAN_PHAM> SAN_PHAM { get; set; }

        public System.Data.Entity.DbSet<tvt_project2.Models.TVTitem> TVTitems { get; set; }
    }
}
