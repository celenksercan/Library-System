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
    public partial class kitap_guncelle : Form
    {
        public kitap_guncelle()
        {
            InitializeComponent();
        }
       

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

      

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void sp_kitap_guncelle_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;  //form boyutunu sabitleme
            label7.Text = "Güncellenek kitabın" + Environment.NewLine + "id numarasını giriniz.";
            label2.Text = "Sıra" + Environment.NewLine + "Numarası";
            button3.Text = "Kitap Listesinde" + Environment.NewLine + "Arama Yapmak İçin" + Environment.NewLine + "Tıklayınız.";
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (barkod.Text == "")      //gelen text'i sorgulama
            {

                MessageBox.Show("Barkod boş geçilemez");

                return;

            }
            else
            {
                OleDbConnection con;
                //MsAccess bağlantısı
                con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");
                //query sorgusu
                OleDbCommand komut = new OleDbCommand("UPDATE kitap SET barkod = '" + barkod.Text + "', kitap_sayisi = '" + kitap_sayisi.Text + "', kitap_ismi = '" + kitap_ismi.Text + "', yazar_ismi = '" + yazar_ismi.Text + "', kategori = '" + kategori.Text + "'  WHERE id = " + id.Text);
                komut.Connection = con; //commandin bağlantıya bağlanması
                con.Open();

                int sayi = komut.ExecuteNonQuery(); //derleme sonucunu değişkene atama
                if (sayi == 1)
                {
                    MessageBox.Show("Güncelleme başarılı!");
                }
                else
                {
                    MessageBox.Show("Güncelleme Başarısız!\nId bulunamadı.");
                }
                con.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kitap_arama xy = new kitap_arama(); //xy adinda kitap_arama formu türet.
            xy.ShowDialog();
        }

        private void kitap_sayisi_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls) // formdaki tüm textbox textlerini temizle

            {

                if (item is TextBox)

                {

                    TextBox tbox = (TextBox)item;

                    tbox.Clear();

                }

            }
        }

        // TEXTBOXLARA GİRİLECEK DEĞERLERİN İNT Mİ YOKSA STRİNG Mİ OLACAĞINA KARAR VERME BLOĞU

        private void id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

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
    }
    }
    

    
