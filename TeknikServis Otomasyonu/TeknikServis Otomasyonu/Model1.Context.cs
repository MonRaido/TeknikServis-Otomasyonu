﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeknikServis_Otomasyonu
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_TeknikServisEntities : DbContext
    {
        public DB_TeknikServisEntities()
            : base("name=DB_TeknikServisEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tbl_ArizaDetay> Tbl_ArizaDetay { get; set; }
        public virtual DbSet<Tbl_Cari> Tbl_Cari { get; set; }
        public virtual DbSet<Tbl_Departman> Tbl_Departman { get; set; }
        public virtual DbSet<Tbl_FaturaBilgi> Tbl_FaturaBilgi { get; set; }
        public virtual DbSet<Tbl_FaturaDetay> Tbl_FaturaDetay { get; set; }
        public virtual DbSet<TBL_IL> TBL_IL { get; set; }
        public virtual DbSet<TBL_ILCE> TBL_ILCE { get; set; }
        public virtual DbSet<Tbl_Kategori> Tbl_Kategori { get; set; }
        public virtual DbSet<Tbl_Personel> Tbl_Personel { get; set; }
        public virtual DbSet<Tbl_Urun> Tbl_Urun { get; set; }
        public virtual DbSet<Tbl_UrunHareket> Tbl_UrunHareket { get; set; }
        public virtual DbSet<Tbl_UrunKabul> Tbl_UrunKabul { get; set; }
        public virtual DbSet<Tbl_UrunTakip> Tbl_UrunTakip { get; set; }
    }
}
