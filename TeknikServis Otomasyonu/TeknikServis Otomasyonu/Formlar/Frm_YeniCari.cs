using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TeknikServis_Otomasyonu.Formlar
{
    public partial class Frm_YeniCari : Form
    {
        public Frm_YeniCari()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-IG58E1Q;Initial Catalog=DB_TeknikServis;User ID=prog;Password=1123581321");
        DB_TeknikServisEntities db = new DB_TeknikServisEntities();
        private void Frm_YeniCari_Load(object sender, EventArgs e)
        {
            var dgril = from u in db.TBL_IL
                        select new
                        {
                            u.id,
                            u.sehir
                        };
            lookUpEditIL.Properties.DataSource = dgril.ToList();
        }

        private void pictureEdit13_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void lookUpEditIL_EditValueChanged(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand kmt = new SqlCommand("select * from TBL_ILCE where sehir like '" + lookUpEditIL.EditValue + "'", bgl);
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            DataSet ds = new DataSet();
            da.Fill(ds);
            lookUpEditILCE.Properties.DataSource = ds.Tables[0];
            bgl.Close();
        }

        private void BtnCik_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            Tbl_Cari ekle = new Tbl_Cari();
            ekle.Ad = TxtAd.Text;
            ekle.Soyad = TxtSoyad.Text;
            ekle.Telefon = TxtTelefon.Text;
            ekle.Mail = TxtMail.Text;
            ekle.IL = int.Parse(lookUpEditIL.EditValue.ToString());
            ekle.ILCE = int.Parse(lookUpEditILCE.EditValue.ToString());
            ekle.Banka = TxtBanka.Text;
            ekle.VergiDairesi = TxtVergiDaire.Text;
            ekle.VergiNo = TxtVergiNo.Text;
            ekle.Statu = TxtSatu.Text;
            ekle.Adres = TxtAdres.Text;
            db.Tbl_Cari.Add(ekle);
            db.SaveChanges();
            MessageBox.Show("Cari Başarılı Bir Şekilde Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
