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
    public partial class Frm_YeniKategori : Form
    {
        public Frm_YeniKategori()
        {
            InitializeComponent();
        }
        DB_TeknikServisEntities db = new DB_TeknikServisEntities();
        private void Frm_YeniKategori_Load(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            Tbl_Kategori ktgr = new Tbl_Kategori();
            ktgr.AD = TxtKategoriAd.Text;
            db.Tbl_Kategori.Add(ktgr);
            db.SaveChanges();
            MessageBox.Show("Kategori Başarılı Bir Şekilde Kaydedildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCik_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
