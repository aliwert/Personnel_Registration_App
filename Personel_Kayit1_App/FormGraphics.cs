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
    public partial class FormGraphics : Form
    {
        public FormGraphics()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LRMEISB\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void FormGraphics_Load(object sender, EventArgs e)
        {
            //graphic1
            baglanti.Open();
            SqlCommand g1 = new SqlCommand("Select PerSehir, Count(*) From Tbl_Personel Group by Persehir", baglanti);
            SqlDataReader dr1 = g1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Cities"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();

            //graphic2
            baglanti.Open();
            SqlCommand g2 = new SqlCommand("Select PerMeslek, Avg(PerMaas) From Tbl_Personel group by PerMeslek", baglanti);
            SqlDataReader dr2 = g2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Job-Salary"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();
        }
    }
}
