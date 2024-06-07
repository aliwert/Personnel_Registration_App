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

namespace Personel_Kayit1_App
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LRMEISB\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand k = new SqlCommand("Select * From Tbl_Yonetici where KullaniciAd=@p1 and Sifre=@p2", baglanti);
            k.Parameters.AddWithValue("@p1", TxtKullaniciAd.Text);
            k.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = k.ExecuteReader();
            if (dr.Read())
            {
                FrmMainForm frm = new FrmMainForm();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
            baglanti.Close();
        }
    }
}
