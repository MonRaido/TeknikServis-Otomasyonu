using DevExpress.Data.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis_Otomasyonu.Formlar
{
    public partial class Frm_Islasistik : Form
    {
        public Frm_Islasistik()
        {
            InitializeComponent();
        }
        DB_TeknikServisEntities db = new DB_TeknikServisEntities();
        private void Frm_Islasistik_Load(object sender, EventArgs e)
        {//              descending z dan a ye sırala ------ ascending   a dan z ye sırala
            LblUrunSayisi.Text = db.Tbl_Urun.Count().ToString();
            LblToplamKategori.Text = db.Tbl_Kategori.Count().ToString();
            LblToplamStok.Text = db.Tbl_Urun.Sum(x => x.Stok).ToString();
            LblEnFazlaStokUrun.Text = (from x in db.Tbl_Urun
                                       orderby x.Stok descending
                                       select x.Ad).FirstOrDefault();
            LblEnAzStokUrun.Text = (from x in db.Tbl_Urun
                                       orderby x.Stok ascending
                                       select x.Ad).FirstOrDefault();
            LblKritik.Text="10";
            LblEnYuksekFiyat.Text = (from x in db.Tbl_Urun
                                       orderby x.Satisfiyat descending
                                       select x.Ad).FirstOrDefault();
            LblEnDusukFiyat.Text = (from x in db.Tbl_Urun
                                    orderby x.Satisfiyat ascending
                                    select x.Ad).FirstOrDefault();
            LblBeyazesyaStok.Text = db.Tbl_Urun.Count(x=>x.Kategori==4).ToString();
            LblBilgisayarStok.Text = db.Tbl_Urun.Count(x=>x.Kategori==1).ToString();
            LblEvAletiStok.Text = db.Tbl_Urun.Count(x=>x.Kategori==3).ToString();
            LblToplamMarka.Text = (from x in db.Tbl_Urun
                                   select x.Marka).Distinct().Count().ToString();

        }
    }
}
