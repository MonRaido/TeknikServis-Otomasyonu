//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Tbl_UrunKabul
    {
        public int Islam_id { get; set; }
        public Nullable<int> Urun { get; set; }
        public Nullable<int> Cari { get; set; }
        public Nullable<short> Personel { get; set; }
        public Nullable<System.DateTime> GelisTarihi { get; set; }
        public Nullable<System.DateTime> CıkısTarihi { get; set; }
    
        public virtual Tbl_Cari Tbl_Cari { get; set; }
        public virtual Tbl_Personel Tbl_Personel { get; set; }
        public virtual Tbl_Urun Tbl_Urun { get; set; }
    }
}