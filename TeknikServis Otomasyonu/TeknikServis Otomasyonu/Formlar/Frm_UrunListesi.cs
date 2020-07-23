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
    public partial class Frm_UrunListesi : Form
    {
        public Frm_UrunListesi()
        {
            InitializeComponent();
        }
        DB_TeknikServisEntities db = new DB_TeknikServisEntities();
       
        void listele()
        {
            //listeleme
            //var deger = db.Tbl_Urun.ToList();
            var degerler = from u in db.Tbl_Urun
                           select new
                           {
                               u.Urun_id,
                               u.Ad,
                               u.Marka,
                               Kategori=u.Tbl_Kategori.AD,
                               u.Alısfiyat,
                               u.Satisfiyat,
                               u.Stok
                               

                           };
            
            gridControl1.DataSource = degerler.ToList();
        }

        private void Frm_UrunListesi_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = db.Tbl_Kategori.ToList();
            listele();
        }
        
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            Tbl_Urun kayit = new Tbl_Urun();
            kayit.Ad = TxtUrunad.Text;
            kayit.Alısfiyat = decimal.Parse(TxtAlis.Text);
            kayit.Satisfiyat = decimal.Parse(TxtSatis.Text);
            kayit.Marka = TxtMarka.Text;
            kayit.Stok = short.Parse(TxtStok.Text);
            kayit.Kategori = short.Parse(lookUpEdit1.EditValue.ToString());
            kayit.Durum = false;
            db.Tbl_Urun.Add(kayit);
            db.SaveChanges();
            MessageBox.Show("Ürün Başarılı Bir Şekilde Kaydedildi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Txtid.Text = gridView1.GetFocusedRowCellValue("Urun_id").ToString();
            TxtUrunad.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            TxtMarka.Text = gridView1.GetFocusedRowCellValue("Marka").ToString();
            TxtAlis.Text = gridView1.GetFocusedRowCellValue("Alısfiyat").ToString();
            TxtSatis.Text = gridView1.GetFocusedRowCellValue("Satisfiyat").ToString();
            TxtStok.Text = gridView1.GetFocusedRowCellValue("Stok").ToString();
            int id = int.Parse(Txtid.Text);
            var deger = db.Tbl_Urun.Find(id);
            lookUpEdit1.EditValue = deger.Kategori;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Ürünü Silmek istediğinize emin misiniz ?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (secenek == DialogResult.Yes)
            {
                int id = int.Parse(Txtid.Text);
                var deger = db.Tbl_Urun.Find(id);
                db.Tbl_Urun.Remove(deger);
                db.SaveChanges();
                MessageBox.Show("Ürün Başarılı Bir Şekilde Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listele();
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Ürünü Güncellemek istediğinize emin misiniz ?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (secenek == DialogResult.Yes)
            {
                int id = int.Parse(Txtid.Text);
                var deger = db.Tbl_Urun.Find(id);
                deger.Ad = TxtUrunad.Text;
                deger.Marka = TxtMarka.Text;
                deger.Alısfiyat = decimal.Parse(TxtAlis.Text);
                deger.Satisfiyat = decimal.Parse(TxtSatis.Text);
                deger.Stok = short.Parse(TxtStok.Text);
                deger.Kategori = short.Parse(lookUpEdit1.EditValue.ToString());
                db.SaveChanges();
                MessageBox.Show("Ürün Başarılı Bir Şekilde Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listele();
            }
        }
    }
}
