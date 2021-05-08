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
    public partial class odunc_ekle : Form
    {
        public odunc_ekle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ms Access bağlantısı
            OleDbConnection yy = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");
            //query sorgusu
            OleDbCommand y = new OleDbCommand("SELECT *FROM odunc_kitap where okur_tc_no=" + Convert.ToInt32(okur_tc_no.Text), yy);
            yy.Open();
            OleDbDataReader oku = y.ExecuteReader();  //derleyiciyi datareadere bağlama

            if (oku.Read()) //datareaderin okunması
            {

                MessageBox.Show("Kullanici 1 kitaptan fazlasini ödünç alamaz!");
                yy.Close();
            }
            else
            {
                yy.Close();


                //ms access bağlantısı
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");
                //query sorgusu
                OleDbCommand kmt = new OleDbCommand("INSERT INTO odunc_kitap (barkod, kitap_ismi, yazar_ismi, kategori, okur_tc_no, okur_ismi, okur_soyismi, okur_gsm) VALUES (@barkod, @kitap_ismi, @yazar_ismi, @kategori, @okur_tc_no, @okur_ismi, @okur_soyismi, @okur_gsm )");
                kmt.Connection = con; //commandin bağlantıya bağlanması
                con.Open(); //bağlantı açılıyor

                //gelen değerlerin parametrelere atanması
                kmt.Parameters.AddWithValue("@barkod", barkod.Text.Trim());
                kmt.Parameters.AddWithValue("@kitap_ismi", kitap_ismi.Text.Trim());
                kmt.Parameters.AddWithValue("@yazar_ismi", yazar_ismi.Text.Trim());
                kmt.Parameters.AddWithValue("@kategori", textBox1.Text.Trim());
                kmt.Parameters.AddWithValue("@kokur_tc_no", okur_tc_no.Text.Trim());
                kmt.Parameters.AddWithValue("@okur_ismi", okur_ismi.Text.Trim());
                kmt.Parameters.AddWithValue("@okur_soysmi", okur_soyismi.Text.Trim());
                kmt.Parameters.AddWithValue("@okur_gsm", okur_gsm.Text.Trim());
                kmt.ExecuteNonQuery();  //commandin derlenmesi

                con.Close(); //bağlantı kapatılıyor
                //ms access bağlantısı
                OleDbConnection yo = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");
                //query sorgusu
                OleDbCommand x = new OleDbCommand("SELECT bugun_tarih_saat,teslim FROM  odunc_kitap where okur_tc_no=" + Convert.ToInt32(okur_tc_no.Text), yo);
                yo.Open();  //bağlantı açılıyor
                OleDbDataReader rdr = x.ExecuteReader();  //derleyiciyi datareadere bağlama
                rdr.Read(); //datareaderin okunması
                {
                    DateTime buguntarih = Convert.ToDateTime(rdr["bugun_tarih_saat"]);  //db'deki bugun tarih saat tablosunu değişkene atama
                    DateTime teslim = Convert.ToDateTime(rdr["teslim"]);            // db'deki teslim tablosunu değişkene atama
                    TimeSpan sonuc = teslim - buguntarih;           // mevcut tarihleri birbirinden çıkarma
                    double c = Convert.ToDouble(sonuc.TotalDays.ToString());        //çıkan sonucu gün bazında değişkene atama
                    int a = (int)c;
                    int z = 0;

                    z = (a);
                    yo.Close();     //bağlantı kapatılıyor

                    //ms access bağlantısı
                    OleDbConnection qwe = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");
                    //query sorgusu
                    OleDbCommand asdz = new OleDbCommand("UPDATE odunc_kitap set teslime_kalan_gun=@z where okur_tc_no=" + Convert.ToInt32(okur_tc_no.Text), qwe);
                    //query sorgusu
                    OleDbCommand lgl = new OleDbCommand("UPDATE kitap set durumu=@j where barkod=" + Convert.ToInt32(barkod.Text), qwe);

                    qwe.Open();     //bağlantı açılıyor
                    string bir = "1"; //odunc kitapların durumu 1'e eşitleneceği için string bir değer aldık.
                    
                    // gelen değerlerin parametrelere atanması
                    asdz.Parameters.AddWithValue("@z", z);
                    lgl.Parameters.AddWithValue("@j", bir);

                    lgl.ExecuteNonQuery();  //commandlerin derlenmesi
                    asdz.ExecuteNonQuery();
                    qwe.Close();
                    MessageBox.Show("Kayıt Başarılı!");
                    //textbox textlerinin temizlenmesi
                    barkod.Text = "";
                    textBox1.Text = "";
                    kitap_ismi.Text = "";
                    yazar_ismi.Text = "";
                    okur_gsm.Text="";
                    okur_ismi.Text = "";
                    okur_soyismi.Text = "";
                    okur_tc_no.Text = "";





                }

            }
        }

            private void sp_odunc_ekle_Load(object sender, EventArgs e)
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;     //form boyutunu sabitleme
            int u = 9;
            //textbox text uzunluklarının sınırlandırılması
            okur_tc_no.MaxLength = u;
            okur_gsm.MaxLength = u;
        }

        // textboxlara girilecek değerlerin int mi yoksa string mi olacağının değerlendirildiği blok.
        private void okur_tc_no_KeyPress(object sender, KeyPressEventArgs e)
        {
           
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

                   }

        private void okur_ismi_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void okur_soyismi_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void kitap_ismi_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void yazar_ismi_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void barkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void okur_gsm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            okur_sil kt = new okur_sil();  // kt adında yeni bir sp_okur_sil bloğu türet.
            kt.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kitaplistesi kt = new kitaplistesi();
            kt.ShowDialog();
        }
    }
    }
