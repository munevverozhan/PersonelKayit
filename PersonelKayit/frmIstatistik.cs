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
    public partial class frmIstatistik : Form
    {
        public frmIstatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-GBKS0E6;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void frmIstatistik_Load(object sender, EventArgs e)
        {
            //toplam personel sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select count(*) from tbl_Personel",baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader(); // select için sorguyu  çalıştıran komut
            while (dr1.Read()) // okuma işlemi yapıldıgı surece
            {
                topPerSayisi.Text = dr1[0].ToString(); // dr1[0] : sorgu sonucunda donen ilk sutun
            }

            baglanti.Close();

            // evli personel sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select count(*) from tbl_Personel where perDurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                evliPerSayisi.Text = dr2[0].ToString();
            }
            baglanti.Close();

            //bekar personel sayısı
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select count(*) from tbl_Personel where perDurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                bekarPerSayisi.Text = dr3[0].ToString();
            }
            baglanti.Close();

            //farklı sehir sayisi
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select count(distinct(perSehir)) from tbl_Personel ",baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                sehirSayisi.Text = dr4[0].ToString();
            }
            baglanti.Close();

            //toplam maas
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select sum(perMaas) from tbl_Personel",baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                toplamMaas.Text = dr5[0].ToString();
            }
            baglanti.Close();

            //ortalama maas
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select avg(perMaas) from tbl_Personel",baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                ortMaas.Text = dr6[0].ToString();
            }
            baglanti.Close();

        }
    }
}
