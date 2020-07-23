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
    public partial class Frm_Markaİslatislik : Form
    {
        public Frm_Markaİslatislik()
        {
            InitializeComponent();
        }
        DB_TeknikServisEntities db = new DB_TeknikServisEntities();
        private void Frm_Markaİslatislik_Load(object sender, EventArgs e)
        {
            var deger = db.Tbl_Urun.OrderBy(x => x.Marka).GroupBy(y => y.Marka).Select(z => new
            {
                Marka = z.Key,
                Toplam = z.Count()
            });
            gridControl1.DataSource = deger.ToList();
            LblUrunSayisi.Text = db.Tbl_Urun.Count().ToString();
            LblToplamMarka.Text = (from x in db.Tbl_Urun
                                   select x.Marka).Distinct().Count().ToString();
            LblEnYuksekFiyatMarka.Text = (from x in db.Tbl_Urun
                                          orderby x.Satisfiyat descending
                                          select x.Ad).FirstOrDefault();
            chartControl1.Series["Series 1"].Points.AddPoint("SIEMENS", 4);
            chartControl1.Series["Series 1"].Points.AddPoint("ARÇELİK", 6);
            chartControl1.Series["Series 1"].Points.AddPoint("BEKO", 2);
            chartControl1.Series["Series 1"].Points.AddPoint("Lenovo", 10);

            chartControl2.Series["Kategoriler"].Points.AddPoint("Beyaz Eşya", 4);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Bilgisyar", 3);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Küçük Ev Aletleri", 6);
            chartControl2.Series["Kategoriler"].Points.AddPoint("TV", 3);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Telefon", 6);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Diğer", 2);


        }
    }
}
