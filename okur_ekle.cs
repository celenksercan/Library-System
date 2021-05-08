using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace kutuphane
{
    public partial class okur_ekle : Form
    {
        public okur_ekle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MS ACCESS BAĞLANTISI
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");
            // QUERY SORGUSU          
                OleDbCommand y = new OleDbCommand("SELECT *FROM okur where okur_tc_no=" + okur_tc_no.Text);
                y.Connection = con; // commandin bağlantıya eşitlenmesi
                con.Open();     //bağlantı açılıyor



                OleDbDataReader asd;

                asd = y.ExecuteReader();  //derleyicinin datareadere eşitlenmesi
                if (asd.Read())
                {
                    MessageBox.Show("okur zaten kayıtlı.!");
                }
                else
                {
                //query sorgusu
                OleDbCommand kmt = new OleDbCommand("INSERT INTO okur (okur_tc_no, okur_ismi, okur_soyismi, okur_gsm) VALUES (@okur_tc_no, @okur_ismi, @okur_soyismi, @okur_gsm)");

                kmt.Connection = con; //commandin bağlantıya eşitlenmesi
                //gelen değerlerin parametrelere atanması
                kmt.Parameters.AddWithValue("@okur_tc_no", okur_tc_no.Text.Trim());
                    kmt.Parameters.AddWithValue("@okur_ismi", okur_ismi.Text.Trim());
                    kmt.Parameters.AddWithValue("@okur_soyismi", okur_soyismi.Text.Trim());
                    kmt.Parameters.AddWithValue("@okur_gsm", okur_gsm.Text.Trim());
                    kmt.ExecuteNonQuery();  // commmandin derlenmesi
                    MessageBox.Show("kayit basarili.!");
                }

               
                
                
              
                con.Close();
                con.Close();
            //textbox textlerinin temizlenmesi
            okur_tc_no.Text = "";
            okur_ismi.Text = "";
            okur_soyismi.Text = "";
            okur_gsm.Text = "";
            

        }

        private void sp_okur_ekle_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;         //form boyutunu sabitleme
            okur_tc_no.MaxLength = 9;   //textlere girilecek maksimumu değer uzunluğunu belirleme
            okur_gsm.MaxLength = 9;
        }

        // textboxlara girilecek değerlerin int mi yoksa string mi olacağını belirleme
        private void okur_tc_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void okur_gsm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
