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
  
    public partial class Form3 : Form
    {    
        SqlConnection baglanti = new SqlConnection("Data Source=(local);Initial Catalog=adamasmacaa;Integrated Security=True");
        public Form3()
        {
            InitializeComponent();
            
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
         TextBox1.Text = Form1.dgr;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlParameter p1 = new SqlParameter("@puan", TextBox2.Text);
            SqlParameter p2 = new SqlParameter("@uye_adi", TextBox1.Text);
            string sql = "";
            sql = "insert into Üyeler (uye_adi,puan) values(@puan,@uye_adi);";
            SqlCommand cmd = new SqlCommand(sql, baglanti);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Eklendi");
            TextBox1.ResetText();
            TextBox2.ResetText();
            baglanti.Close();     
        }
    }
}
