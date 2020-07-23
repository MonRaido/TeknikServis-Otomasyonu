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
    public partial class Frm_YeniUrun : Form
    {
        public Frm_YeniUrun()
        {
            InitializeComponent();
        }
        DB_TeknikServisEntities db = new DB_TeknikServisEntities();
        private void FrmYeniUrun_Load(object sender, EventArgs e)
        {
            var dbkategori = from u in db.Tbl_Kategori
                           select new
                           {
                               u.Kategori_id,
                               u.AD
                           };
            lookUpEdit1.Properties.DataSource = dbkategori.ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (lookUpEdit1.EditValue != null)
            {
                Tbl_Urun urun = new Tbl_Urun();
                urun.Ad = TxtAd.Text;
                urun.Marka = TxtMarka.Text;
                urun.Kategori = short.Parse(lookUpEdit1.EditValue.ToString());
                urun.Alısfiyat = decimal.Parse(TxtAlis.Text);
                urun.Satisfiyat = decimal.Parse(TxtSatis.Text);
                urun.Stok = short.Parse(TxtStok.Text);
                db.Tbl_Urun.Add(urun);
                db.SaveChanges();
                MessageBox.Show("Ürünler Başarılı Bir Şekilde Kaydedildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen Bir Kategori Seçiniz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnCik_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
