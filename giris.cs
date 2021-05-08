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
using System.Data.OleDb;

namespace kutuphane
{
    public partial class giris : Form
    {
        //string dizin = Application.StartupPath + @"\kutuphane.accdb";
        public giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //MsAccess bağlantısı
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");
                con.Open();
                OleDbCommand kmt = new OleDbCommand();
                kmt.Connection = con; //command connectiona bağlanıyor
               
                //query kodu
                kmt.CommandText = "SELECT *FROM kullanicilar where kullanici_adi='" + kullanici_adi.Text + "' AND kullanici_sifresi='" + kullanici_sifresi.Text + "'";
                OleDbDataReader oku = kmt.ExecuteReader();
                
                if (oku.Read())  //okuma gerçekleşiyorsa
                {
                this.Hide();  //mevcut formu gizle
                    anamenu k = new anamenu(); // k adında yeni bir anamenu formu türet
                    k.ShowDialog(); // yeni formu aç

                }
                else
                {
                    MessageBox.Show("Kullanıcı adı ya da şifre yanlış");
                }
                

            }

        private void giris_Load(object sender, EventArgs e)
        {
            label4.Text = "Admin Account" + Environment.NewLine + "Kullanici Adi=123" + Environment.NewLine + "Şifre=321";

            this.FormBorderStyle = FormBorderStyle.FixedSingle;  //form boyutunu sabitleme
            label1.Text = "     Yetkili" + Environment.NewLine + "Kullanici Adi";

            timer1.Start(); 
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            anamenu_user kt = new anamenu_user();  // kt adında yeni bir anamenu_user formu türet
            kt.ShowDialog();  // yeni formu aç
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();     //random sayı sınıfından rand adında bir sınıf türet
            int one = rand.Next(0, 255);
            int two = rand.Next(0, 255);
            int three = rand.Next(0, 255);
            int four = rand.Next(0, 255);
            label3.ForeColor = Color.FromArgb(one, two, three, four); // üretilen rastgele sayılara göre renkler türet
            button1.BackColor = Color.FromArgb(one, two, three, four);
        }
    }

       
    
}
