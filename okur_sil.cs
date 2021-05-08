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
    public partial class okur_sil : Form
    {
        public okur_sil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (id.Text != "")  //textbox text sorgulanıyor
            {   //ms access bağlantısı
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");
                //query sorgusu
                OleDbCommand kmt = new OleDbCommand("delete *from okur  WHERE okur_tc_no = " + id.Text);
                kmt.Connection = con; // command bağlantıya eşitleniyor
                con.Open(); //bağlantı açılıyor
                kmt.ExecuteNonQuery(); // command derleniyor
                con.Close();  //bağlantı kapatılıyor

                OleDbDataAdapter da;
                DataSet ds;
                //query sorgusu
                da = new OleDbDataAdapter("SELECT okur_tc_no, okur_ismi, okur_soyismi, okur_gsm FROM  okur", con);
                ds = new DataSet();
                con.Open();
                da.Fill(ds, "okur_sil");
                con.Close();
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.DataSource = ds.Tables["okur_sil"]; // db'deki okursil tablosunu datagridview'e çekme
                dataGridView1.ReadOnly = true;
                dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.White;


                con.Close();
                MessageBox.Show("Silme İşlemi Başarılı!");
            
            }
            else
            {
                MessageBox.Show("TC Kimlik Kısmı Boş Bırakılamaz.!");
            }
        }


        private void sp_okur_sil_Load(object sender, EventArgs e)
        {
            id.MaxLength = 9; //text'e girilebilecek maksimum karakter sayısını belirleme
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //form boyutunu sabitleme
            
            label2.Text = "      Silinecek Okurun" + Environment.NewLine + "Tc Kimlik No'sunu Giriniz.";
            //ms access bağlantısı
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");
            OleDbDataAdapter da;
            DataSet ds;
            //query sorgusu
            da = new OleDbDataAdapter("SELECT okur_tc_no, okur_ismi, okur_soyismi, okur_gsm FROM  okur", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "okur");
            con.Close();
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  //tüm sutunların datagridview'e sığdırılması
            dataGridView1.DataSource = ds.Tables["okur"];  //db'deki okur tablosunu datagridview'e çekme
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.White;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Selected = false;
            }


            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {  //ms access bağlantısı
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");
            OleDbDataAdapter da;
            DataSet ds;
            //query sorgusu
            da = new OleDbDataAdapter("Select *From okur", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "okur");
            DataView dv = ds.Tables["okur"].DefaultView; 

            // ARAMA İŞLEVİ DATAGRİDVİEW'İN TÜM HÜCRELERİNİ DOLAŞIP STRİNGE EŞİT OLUP OLMADIĞINI SORGULAMA
            string aranan = textBox1.Text.Trim().ToUpper();
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
                    {
                        if (cell.Value != null)
                        {
                            if (cell.Value.ToString().ToUpper() == aranan)
                            {
                                cell.Style.BackColor = Color.DarkTurquoise;
                                break;
                            }
                        }
                    }
                }
            }
            }

        private void button2_Click(object sender, EventArgs e)
        {       //MS ACCESS BAĞLANTISI
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");
            OleDbDataAdapter da;
            DataSet ds;
            //QUERY SORGUSU
            da = new OleDbDataAdapter("SELECT okur_tc_no, okur_ismi, okur_soyismi, okur_gsm FROM  okur", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "okur");
            dataGridView1.DataSource = ds.Tables["okur"];   //DB'deki okur tablosunu datagridview'e çekme
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.White;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Selected = false;
            }


            con.Close();  //bağlantı kapatılıyor
            //textbox textleri temizleniyor
            textBox1.Text = "";
            id.Text = "";
        }

        //textboxa girilecek değerin int mi yoksa string mi olacağının kararlaştırıldığı blok
        private void id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
