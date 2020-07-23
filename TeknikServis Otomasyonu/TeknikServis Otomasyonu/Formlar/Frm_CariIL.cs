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
    public partial class Frm_CariIL : Form
    {
        public Frm_CariIL()
        {
            InitializeComponent();
        }
        DB_TeknikServisEntities db = new DB_TeknikServisEntities();
        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-IG58E1Q;Initial Catalog=DB_TeknikServis;User ID=prog;Password=1123581321");
        private void Frm_CariIL_Load(object sender, EventArgs e)
        {

            /*chartControl1.Series["Series 1"].Points.AddPoint("Ankara",22);
            chartControl1.Series["Series 1"].Points.AddPoint("İstanubl",12);
            chartControl1.Series["Series 1"].Points.AddPoint("İzmir",8);
            chartControl1.Series["Series 1"].Points.AddPoint("Bursa",14);*/

            gridControl1.DataSource = db.Tbl_Cari.OrderBy(x => x.IL).GroupBy(y => y.IL).Select(z => new { İL = z.Key, Toplam_Müşteri = z.Count() }).ToList();

            bgl.Open();
            SqlCommand kmt = new SqlCommand("select IL,COUNT(*) from Tbl_Cari group by IL",bgl);
            SqlDataReader dr = kmt.ExecuteReader();
            while(dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            bgl.Close();
        }
    }
}
