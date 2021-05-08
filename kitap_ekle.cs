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
    public partial class kitap_ekle : Form
    {
        public kitap_ekle()
        {
            InitializeComponent();
            
        }
       
        private void button1_Click(object sender, EventArgs e)
        {

            if (barkod.Text == "")  //GELEN TEXTİN BOŞ MU OLUP OLMADIGINI SORGULAMA
            {

                MessageBox.Show("Barkod boş geçilemez");

                return;

            }
            else
            {   // MSACCESS BAĞLANTISI
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");
                // QUERY SORGUSU
                OleDbCommand kmt = new OleDbCommand("INSERT INTO kitap (barkod, sira_no, kitap_sayisi, kitap_ismi, yazar_ismi, kategori) VALUES (@barkod,@sira_no,@kitap_sayisi,@kitap_ismi,@yazar_ismi,@kategori)");
                kmt.Connection = con;
                con.Open();
                // GELEN DEĞERLERİ PARAMETRELERE ATAMA
                kmt.Parameters.AddWithValue("@barkod", barkod.Text.Trim());
                kmt.Parameters.AddWithValue("@sira_no", sira_no.Text.Trim());
                kmt.Parameters.AddWithValue("@kitap_sayisi", kitap_sayisi.Text.Trim());
                kmt.Parameters.AddWithValue("@kitap_ismi", kitap_ismi.Text.Trim());
                kmt.Parameters.AddWithValue("@yazar_ismi", yazar_ismi.Text.Trim());
                kmt.Parameters.AddWithValue("@kategori", kategori.Text.Trim());
                kmt.ExecuteNonQuery(); // COMMANDİ DERLEME
                con.Close();
                MessageBox.Show("Kitap başarıyla eklendi.");

              
                    foreach (Control item in this.Controls) // FORMDAKİ TÜM TEXTBOX TEXTLERİNİ TEMİZLEME

                    {

                        if (item is TextBox)

                        {

                            TextBox tbox = (TextBox)item;

                            tbox.Clear();

                        }

                    }

                




            }
        }

       

        private void kitap_sayisi_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sp_kitap_ekle_Load(object sender, EventArgs e)
        {

            this.FormBorderStyle = FormBorderStyle.FixedSingle;     // FORM BOYUTUNU SABİTLEME
        }

        // TEXTBOXLARA GİRİLECEK DEĞERLERİN İNT Mİ YOKSA STRİNG Mİ OLACAĞINA KARAR VERME BLOĞU
        private void barkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void sira_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void kitap_sayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void yazar_ismi_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void kategori_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }
    }
}
