using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kutuphane
{
    public partial class anamenu : Form
    {
        public anamenu()
        {
            InitializeComponent();
        }

        private void kitapKartEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kitap_ekle kt = new kitap_ekle();  //kt adında yeni bir sp_kitap_ekle formu türet
            kt.ShowDialog();
        }

        private void kitapGuncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kitap_guncelle kt = new kitap_guncelle(); //kt adında yeni bir sp_kitap_guncelle formu türet
            kt.ShowDialog();
        }

        private void kitapKartSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kitap_sil kt = new kitap_sil();  //kt adında yeni bir sp_kitap_sil formu türet
            kt.ShowDialog();
        }

        private void okurKayıtEkleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            okur_ekle kt = new okur_ekle();  //kt adında yeni bir sp_okur_ekle formu türet
            kt.ShowDialog();
        }

        private void okurKayıtSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            okur_sil kt = new okur_sil();  //kt adında yeni bir sp_okur_sil formu türet
            kt.ShowDialog();
        }

        private void kitapAramaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            kitap_arama kt = new kitap_arama();  //kt adında yeni bir kitap_arama formu türet
            kt.ShowDialog();
        }

        private void oduncKitapEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            odunc_ekle kt = new odunc_ekle();  //kt adında yeni bir sp_odunc_ekle formu türet
            kt.ShowDialog();
        }

        private void oduncKitapGuncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            odunc_kitap_takip kt = new odunc_kitap_takip();  //kt adında yeni bir oduc_kitap_takip formu türet
            kt.ShowDialog();
        }

        private void oduncKitapEkleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            odunc_sil kt = new odunc_sil();  //kt adında yeni bir sp_odunc_sil formu türet
            kt.ShowDialog();
        }

       

      

        

        private void formToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            borc_takip kt = new borc_takip();  //kt adında yeni bir borc_takip formu türet
            kt.ShowDialog();
        }

        private void kitapAramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kitap_arama kt = new kitap_arama();  //kt adında yeni bir kitap_arama formu türet
            kt.ShowDialog();
        }

        private void anamenu_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;  //form boyutunu sabitle
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString(); // tarih saat işlemleri
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            zedgraph kt = new zedgraph();  //kt adında yeni bir test formu türet
            kt.ShowDialog();
        }
    }
}
