using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace AdamAsmaca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string  dgr;
        Form3 form3 = new Form3();
        List<string> kelimeler = new List<string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            dgr = puan.Text;
            // Kelime Listesi
            kelimeler.Add("KÜÇÜK"); kelimeler.Add("ALGORİTMA");
            kelimeler.Add("BİLGİSAYAR");
            kelimeler.Add("CUMHURİYET");
            kelimeler.Add("DUMAN");
            kelimeler.Add("EDEBİYAT");
            kelimeler.Add("DOSYA");
            kelimeler.Add("MESAJ");
            kelimeler.Add("KALABALIK");
            kelimeler.Add("NEGATİF");
            kelimeler.Add("AYDINLIK");
            kelimeler.Add("ANORMAL");
            kelimeler.Add("ÖZELLİK");
            kelimeler.Add("PRİMAT");
            kelimeler.Add("ÇEVİRİ");
            kelimeler.Add("REKLAM");
            kelimeler.Add("MAKALE");
            kelimeler.Add("ANAHTAR");
            kelimeler.Add("DÖKÜMAN");
            kelimeler.Add("SPAGETTİ");
            kelimeler.Add("ULU");
            kelimeler.Add("CANAVAR");
            kelimeler.Add("PROMOSYON");
            kelimeler.Add("TERİM");
            kelimeler.Add("EVRENSEL");                 
        }

        Random rand = new Random(); // Randomumuz
        string selkelime; // Rastgele Seçilen kelime Bu Değişkene Aktarılıyor
       
        int res = 1;
        bool var = true;


        private void butontik(object sender, EventArgs e)
        {
            char[] tempkel = kelime.Text.ToCharArray();


            // Basılan harf rastgele seçilen kelime içerisinde aratılıp varsa yerine yazılıyor.
            for (int i = 0; i < selkelime.Length; i++)
            {
                if (selkelime[i] == Convert.ToChar(((Button)sender).Text))
                {
                    tempkel[i] = selkelime[i];
                }

                if (!selkelime.Contains(Convert.ToChar(((Button)sender).Text)))
                {
                    var = false;
                }
            }
            kelime.Text = "";
            for (int i = 0; i < tempkel.Length; i++)
            {
                kelime.Text = kelime.Text + tempkel[i];
            }

            if (var == false)
            {
                dgr = (Convert.ToInt32(dgr) - 1000).ToString();
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "/hangimg/" + res + ".png");
                var = true;
                res++;
            }



            // Kelime GroupBox içerisinde ortalanıyor.
            kelime.Location = new Point((groupBox4.Width / 2) - (kelime.Width / 2), kelime.Location.Y);


            // Basılan tuşun kullanılabiliriği false yapılıyor.
            ((Button)sender).Enabled = false;


            // Bütün harfler bilindiğinde Kazandınız Mesajı
            if (!kelime.Text.Contains('-'))
            {
                foreach (Control item in groupBox1.Controls)
                {
                    if (item is Button)

                        ((Button)item).Enabled = false;
                }
                MessageBox.Show("TEBRİKLER KAZANDINIZ");
                Form3 Form3 = new Form3();
                Form3.Show();

            }



            // Puan 0'a ulaştığında oyun bitiriliyor.
            if (dgr == "0")
            {

                foreach (Control item in groupBox1.Controls)
                {
                    if (item is Button)

                        ((Button)item).Enabled = false;
                }

                MessageBox.Show("Bilemediniz !\nKelime : " + selkelime, "Oyun Bitti");

            }

        }

        private void button28_Click(object sender, EventArgs e)
        {
            MessageBox.Show("'Yeni Oyun' Tıklayın ve Programın Rastgele Seçtiği Kelimeyi Bilmeye Çalışın.\nEn Fazla 10 Defa Yanlış Yapma Hakkınız Var.\nDaha Az Yanlış ve Daha Yüksek Puanla Oyunu Bitirmeye Çalışın.\nİYİ OYUNLAR..", "Nasıl Oynanır ?");

        }
        private void yeniOyunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is Button)

                    ((Button)item).Enabled = true;
            }
            kelime.Text = "";
            dgr = "10000";
            res = 1;
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "/hangimg/0.png");
            selkelime = kelimeler[rand.Next(0, 25)];

            label2.Text = selkelime.Length + " Harfli Bir Kelime";
            for (int i = 0; i < selkelime.Length; i++)
            {
                kelime.Text = kelime.Text + '-';
            }

            kelime.Location = new Point((groupBox4.Width / 2) - (kelime.Width / 2), kelime.Location.Y);
 
        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2();
            Form2.Show();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void top5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 Form4 = new Form4();
            Form4.Show();
     

        }
        }


    }

