﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace k22cnt3_tavanthang_project2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class k22cnt3_tavanthang_project02Entities : DbContext
    {
        public k22cnt3_tavanthang_project02Entities()
            : base("name=k22cnt3_tavanthang_project02Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CHIEN_DICH> CHIEN_DICH { get; set; }
        public virtual DbSet<DAT_HANG> DAT_HANG { get; set; }
        public virtual DbSet<KHACH_HANG> KHACH_HANG { get; set; }
        public virtual DbSet<LOG_HOAT_DONG> LOG_HOAT_DONG { get; set; }
        public virtual DbSet<QUAN_TRI_VIEN> QUAN_TRI_VIEN { get; set; }
        public virtual DbSet<SAN_PHAM> SAN_PHAM { get; set; }
    }
}