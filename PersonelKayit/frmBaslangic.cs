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
    public partial class frmBaslangic : Form
    {
        public frmBaslangic()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-GBKS0E6;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
         void temizle()
        {
            txtAd.Text = " ";
            txtSoyad.Text = " ";
            txtSehir.Text = " ";
            txtMaas.Text = " ";
            txtMeslek.Text = " ";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtAd.Focus();// imleci buradan başlatacak.


        }

    

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelVeriTabaniDataSet.tbl_Personel' table. You can move, or remove it, as needed.
              this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.tbl_Personel);

            baglanti.Open();
            SqlCommand sorgu = new SqlCommand("select  * from iller ", baglanti);
            SqlDataReader dr = sorgu.ExecuteReader();
            while (dr.Read())
            {
                txtSehir.Items.Add(dr["sehir"]);
            }
            baglanti.Close();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
          this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.tbl_Personel);

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            // parametre 1 ve 2 den gelen degerleri perAd ve perSoyad kısmına ekleyecek.
            SqlCommand komut = new SqlCommand("insert into tbl_Personel (perAd,perSoyad,perSehir,perMaas,perMeslek,perDurum) values(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", txtSehir.Text);
            komut.Parameters.AddWithValue("@p4", txtMaas.Text);
            komut.Parameters.AddWithValue("@p5", txtMeslek.Text);
            komut.Parameters.AddWithValue("@p6", lblRadioButton.Text);
            komut.ExecuteNonQuery();//sorguyu calistirir. yazilmazsa sorgu islemleriyapilmaz. insert,update ve delete islemlerinde kullanilir.(tablo sonucunda etkilenme oldugunda)
            baglanti.Close();
            MessageBox.Show("personel eklendi");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                lblRadioButton.Text = "True";

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                lblRadioButton.Text = "False";

            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex; // herhangi bir hücreye tıklandığında bunu seçilen değişkenine atar.
            txtPersonelID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            lblRadioButton.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

       private void lblRadioButton_TextChanged(object sender, EventArgs e)
        {
            if (lblRadioButton.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if(lblRadioButton.Text=="False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutSil = new SqlCommand("delete from tbl_Personel where perID=@k1",baglanti);
            komutSil.Parameters.AddWithValue("@k1", txtPersonelID.Text);
            komutSil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("kaydı sildiniz.");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutGuncelle = new SqlCommand("update tbl_Personel set perAd=@a1,perSoyad=@a2,perSehir=@a3,perMaas=@a4,perDurum=@a5,perMeslek=@a6 where perID=@a7",baglanti);
            komutGuncelle.Parameters.AddWithValue("@a1", txtAd.Text);
            komutGuncelle.Parameters.AddWithValue("@a2", txtSoyad.Text);
            komutGuncelle.Parameters.AddWithValue("@a3", txtSehir.Text);
            komutGuncelle.Parameters.AddWithValue("@a4", txtMaas.Text);
            komutGuncelle.Parameters.AddWithValue("@a5", lblRadioButton.Text);
            komutGuncelle.Parameters.AddWithValue("@a6", txtMeslek.Text);
            komutGuncelle.Parameters.AddWithValue("@a7", txtPersonelID.Text);
            komutGuncelle.ExecuteNonQuery();
            MessageBox.Show("veriniz güncellendi.");
            baglanti.Close();

        }

        private void btnIstatistik_Click(object sender, EventArgs e)
        {
            frmIstatistik form = new frmIstatistik();
            form.Show();
        }

        private void btnGrafikler_Click(object sender, EventArgs e)
        {
            frmGrafikler grafik = new frmGrafikler();
            grafik.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        
        
    }
}
