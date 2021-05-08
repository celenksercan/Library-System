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
    public partial class kitap_sil : Form
    {
        public kitap_sil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           //Ms Access bağlantısı
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");
            //Query sorgusu
                OleDbCommand kmt = new OleDbCommand("delete *from kitap  WHERE id = " +id.Text);
           
            
            kmt.Connection = con; //command bağlantıya baglanıyor


                con.Open(); //bağlantı açılıyor
           
            

            kmt.ExecuteNonQuery();  // commandi derleme
                con.Close();
            MessageBox.Show("Kitap başarı ile silindi.");
            }

        private void sp_kitap_sil_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //form boyutunu sabitleme
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  // tüm sütunları datagridview'e sığdırma
            //ms access bağlantısı
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");
            OleDbDataAdapter da;
            DataSet ds;
            //query sorgusu
            da = new OleDbDataAdapter("SELECT id,barkod, sira_no, kitap_sayisi, kitap_ismi, yazar_ismi, kategori FROM  kitap", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "kitap");
            con.Close();
            dataGridView1.DataSource = ds.Tables["kitap"];  //db'deki kitap tablosunu datagridview'e çekme
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.White;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Selected = false;     //datagridview'deki tüm selected ifadeleri false çevirme işlemi
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Ms Access
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");
            OleDbDataAdapter da;
            DataSet ds;
            //query sorgusu
            da = new OleDbDataAdapter("SELECT id,barkod, sira_no, kitap_sayisi, kitap_ismi, yazar_ismi, kategori FROM  kitap", con);
            con.Open();
            ds = new DataSet();
            da.Fill(ds, "kitap");
            dataGridView1.DataSource = ds.Tables["kitap"];  //db'deki kitap tablosunu datagridview'e çekme
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.White;
            con.Close();
        }


        //textboxa girilecek değerin int mi yoksa string mi olacağı belirleniyor
        private void id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
    }
