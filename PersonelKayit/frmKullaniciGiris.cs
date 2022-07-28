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
    public partial class frmKullaniciGiris : Form
    {
        public frmKullaniciGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-GBKS0E6;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
        
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_Yonetici where kullaniciAd=@p1 and sifre=@p2",baglanti);         
            komut.Parameters.AddWithValue("@p1", txtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr1 = komut.ExecuteReader();
            if (dr1.Read())
            {
                frmBaslangic baslangic = new frmBaslangic();
                baslangic.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("kullanıcı adınızı veya şifrenizi kontrol ediniz.");
            }
            baglanti.Close();
          
          
        }

    }
}
