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

namespace PersonelKayit
{
    public partial class frmGrafikler : Form
    {
        public frmGrafikler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-GBKS0E6;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void frmGrafikler_Load(object sender, EventArgs e)
        {
            //grafik 1

            baglanti.Open();
            SqlCommand g1 = new SqlCommand("select perSehir,count(*) from tbl_Personel group by perSehir",baglanti);
            SqlDataReader dr1 = g1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();

            //grafik 2

            baglanti.Open();
            SqlCommand g2 = new SqlCommand("select perMeslek,avg(perMaas) from tbl_Personel group by perMeslek", baglanti);
            SqlDataReader dr2 = g2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();
        }

    
    }
}
