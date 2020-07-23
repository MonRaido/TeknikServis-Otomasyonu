using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void BarBtnUrunListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Frm_UrunListesi fr1 = new Formlar.Frm_UrunListesi();
            fr1.MdiParent = this;
            fr1.Show();

        }

        private void BtnYeniUrun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Frm_YeniUrun fr2 = new Formlar.Frm_YeniUrun();
            fr2.Show();
        }

        private void BtnKategoriListe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Frm_Katagori fr3 = new Formlar.Frm_Katagori();
            fr3.MdiParent = this;
            fr3.Show();

        }

        private void BtnYeniKategori_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Frm_YeniKategori fr4 = new Formlar.Frm_YeniKategori();
            fr4.Show();
        }

        private void BtnIslatislik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Frm_Islasistik fr5 = new Formlar.Frm_Islasistik();
            fr5.MdiParent = this;
            fr5.Show();
        }

        private void BtnMarkaİslatislik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Frm_Markaİslatislik fr6 = new Formlar.Frm_Markaİslatislik();
            fr6.MdiParent = this;
            fr6.Show();
        }

        private void BtnCariListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Frm_CariListesi fr7 = new Formlar.Frm_CariListesi();
            fr7.MdiParent = this;
            fr7.Show();
        }

        private void BtnCariIslatislik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Frm_CariIL fr8 = new Formlar.Frm_CariIL();
            fr8.MdiParent = this;
            fr8.Show();
        }

        private void BtnYeniCari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Frm_YeniCari fr9 = new Formlar.Frm_YeniCari();
            fr9.Show();
        }
    }
}
