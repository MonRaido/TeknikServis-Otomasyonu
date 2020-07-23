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
    public partial class Frm_Katagori : Form
    {
        public Frm_Katagori()
        {
            InitializeComponent();
        }
        DB_TeknikServisEntities db = new DB_TeknikServisEntities();
        void listele()
        {
            var deger = from k in db.Tbl_Kategori
                        select new
                        {
                            ID=k.Kategori_id,
                            Kategori_Adı=k.AD
                        };
            gridControl1.DataSource = deger.ToList();

        }
        private void Frm_Katagori_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            Tbl_Kategori ekle = new Tbl_Kategori();
            ekle.AD = TxtKategoriAD.Text;
            db.Tbl_Kategori.Add(ekle);
            db.SaveChanges();
            MessageBox.Show("Kategori Başarılı Bir Şekilde Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Txtid.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtKategoriAD.Text = gridView1.GetFocusedRowCellValue("Kategori_Adı").ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Kategoriyi Silmek istediğinize emin misiniz ?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (secenek == DialogResult.Yes)
            {
                int id = int.Parse(Txtid.Text);
                var deger = db.Tbl_Kategori.Find(id);
                db.Tbl_Kategori.Remove(deger);
                db.SaveChanges();
                MessageBox.Show("Kategori Başarılı Bir Şekilde Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listele();
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Kategoriyi Güncellemek istediğinize emin misiniz ?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (secenek == DialogResult.Yes)
            {
                int id = int.Parse(Txtid.Text);
                var deger = db.Tbl_Kategori.Find(id);
                deger.AD = TxtKategoriAD.Text;
                db.SaveChanges();
                MessageBox.Show("Kategori Başarılı Bir Şekilde Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listele();
            }
        }
    }
}
