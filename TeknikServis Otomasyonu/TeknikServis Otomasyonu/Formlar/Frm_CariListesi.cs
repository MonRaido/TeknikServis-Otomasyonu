using DevExpress.XtraPrinting;
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
    public partial class Frm_CariListesi : Form
    {
        public Frm_CariListesi()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-IG58E1Q;Initial Catalog=DB_TeknikServis;User ID=prog;Password=1123581321");
        DB_TeknikServisEntities db = new DB_TeknikServisEntities();
        void listele()
        {
            var dgr = from u in db.Tbl_Cari
                                      select new
                                      {
                                          u.Cari_id,
                                          u.Ad,
                                          u.Soyad,
                                          u.Telefon,
                                          u.Mail,
                                          IL=u.TBL_IL.sehir,
                                          ILCE = u.TBL_ILCE.ilce,
                                          u.Banka,
                                          u.VergiDairesi,
                                          u.VergiNo,
                                          u.Statu,
                                          u.Adres
                                      };
            gridControl1.DataSource = dgr.ToList();
        }
        private void Frm_CariListesi_Load(object sender, EventArgs e)
        {

            listele();
            var dgril = from u in db.TBL_IL
                        select new
                        {
                            u.id,
                            u.sehir
                        };
            lookUpEditIL.Properties.DataSource =dgril.ToList();
           /* var dgrilce = from j in db.TBL_ILCE
                        select new
                        {
                            j.id,
                            j.ilce,
                            il=j.TBL_IL.id
                        };
            lookUpEditILCE.Properties.DataSource = dgrilce.ToList();*/
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            /*string il = gridView1.GetFocusedRowCellValue("IL").ToString();
            string ilce = gridView1.GetFocusedRowCellValue("ILCE").ToString();*/
            int id = int.Parse(gridView1.GetFocusedRowCellValue("Cari_id").ToString());
            var dgril = db.Tbl_Cari.Find(id);
            lookUpEditIL.EditValue = dgril.IL;
            lookUpEditILCE.EditValue = dgril.ILCE;
            /*
            Txtid.Text = gridView1.GetFocusedRowCellValue("Cari_id").ToString();
            Txtad.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            TxtSoyad.Text = gridView1.GetFocusedRowCellValue("Soyad").ToString();
            TxtTelefon.Text = gridView1.GetFocusedRowCellValue("Telefon").ToString();
            TxtMail.Text = gridView1.GetFocusedRowCellValue("Mail").ToString();
            TxtBanka.Text = gridView1.GetFocusedRowCellValue("Banka").ToString();
            TxtVDaire.Text = gridView1.GetFocusedRowCellValue("VergiDairesi").ToString();
            TxtVergiNO.Text = gridView1.GetFocusedRowCellValue("VergiNo").ToString();
            TxtStatü.Text = gridView1.GetFocusedRowCellValue("Statu").ToString();
            TxtAdres.Text = gridView1.GetFocusedRowCellValue("Adres").ToString();
            */


        }

        private void lookUpEditIL_EditValueChanged(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand kmt = new SqlCommand("select * from TBL_ILCE where sehir like '" + lookUpEditIL.EditValue+"'", bgl);
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            DataSet ds = new DataSet();
            da.Fill(ds);
            lookUpEditILCE.Properties.DataSource = ds.Tables[0];
            bgl.Close();
        }
    }
}
