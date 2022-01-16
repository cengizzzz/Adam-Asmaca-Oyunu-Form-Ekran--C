using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace AdamAsmaca
{
    public partial class Form4 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=(local);Initial Catalog=adamasmacaa;Integrated Security=True");
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            string sql = "select top 5 uye_adi,puan from Üyeler  ORDER BY Cast(puan AS int)  DESC ";
                SqlCommand cmd = new SqlCommand(sql, baglanti);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();

        }
    }
}
