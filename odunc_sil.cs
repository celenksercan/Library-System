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
    public partial class odunc_sil : Form
    {
        public odunc_sil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (id.Text == "")      // textboxtan gelen değer sorgulanıyor
                {
                    MessageBox.Show("ID kısmı boş bırakılamaz!");
                }
                else
                {   //ms access bağlantısı
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");
                    // query sorgusu
                    OleDbCommand kmt = new OleDbCommand("delete *from odunc_kitap  WHERE id = " + id.Text);
                    kmt.Connection = con; // command bağlantıya eşitleniyor
                    con.Open();     //bağlantı açılıyor
                    kmt.ExecuteNonQuery(); // command derleniyor
                    con.Close();        // bağlantı kapatılıyor
                    OleDbDataAdapter da;
                    DataSet ds;
                    //query sorgusunun dataadaptere atanması
                    da = new OleDbDataAdapter("SELECT id,barkod, kitap_ismi, yazar_ismi, kategori, okur_tc_no, okur_ismi, okur_soyismi, okur_gsm, bugun_tarih_saat FROM  odunc_kitap", con);
                    ds = new DataSet();
                    con.Open();
                    da.Fill(ds, "odunc_kitap");
                    dataGridView1.DataSource = ds.Tables["odunc_kitap"];  //db'deki odunckitap tablosunu datagridview'e çekme
                    dataGridView1.ReadOnly = true;
                    dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.White;


                    con.Close();        //bağlantı kapatılıyor
                    id.Text = "";       //textbox temizleme
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SercanCelenk");
            }
        }

        private void sp_odunc_sil_Load(object sender, EventArgs e)
        {
            id.MaxLength = 9;  // textboxa girilecek değerin uzunluğunu belirleme
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // form boyutunu sabitleme
            label3.Text = "Silinecek ödünç kitap" + Environment.NewLine + "    ID'sini giriniz.";
            //ms acces bağlantısı
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");
            OleDbDataAdapter da;
            DataSet ds;
            //query sorgusu
            da = new OleDbDataAdapter("SELECT id,barkod, kitap_ismi, yazar_ismi, kategori, okur_tc_no, okur_ismi, okur_soyismi, okur_gsm FROM  odunc_kitap", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "odunc_kitap");
            con.Close();
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //tüm sütunları datagridview'e sığdırma
            dataGridView1.DataSource = ds.Tables["odunc_kitap"];  // db'deki odunckitap tablosunu datagridview'e çekme
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.White;


            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            // ARAMA İŞLEVİ
            //MS ACCESS BAĞLANTISI
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");
            OleDbDataAdapter da;
            DataSet ds;
            //QUERY SORGUSU
            da = new OleDbDataAdapter("Select *From odunc_kitap", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "kitap");
            DataView dv = ds.Tables["kitap"].DefaultView; //db'deki kitap tablosunu datagridview'e aktarma
            string aranan = textBox1.Text.Trim().ToUpper();
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
                    {
                        if (cell.Value != null)
                        {
                            if (cell.Value.ToString().ToUpper() == aranan)  //aranan stringi hücreden gelen değere eşit ise
                            {
                                cell.Style.BackColor = Color.DarkTurquoise;     //hücre backcolorunu değiştir
                                dataGridView1.FirstDisplayedCell = cell;        //hücreye git
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {  // MS ACCESS BAĞLANTISI
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");
            OleDbDataAdapter da;
            DataSet ds;
            //QUERY SORGUSU
            da = new OleDbDataAdapter("SELECT id,barkod, kitap_ismi, yazar_ismi, kategori, okur_tc_no, okur_ismi, okur_soyismi, okur_gsm, bugun_tarih_saat FROM  odunc_kitap", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "odunc_kitap");
            dataGridView1.DataSource = ds.Tables["odunc_kitap"];   //db'deki odunckitap tablosunu datagridview'e çekme
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.White;


            con.Close();
            textBox1.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        //textbox'a girilecek değerin int mi yoksa string mi olacağını belirleme 
        private void id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
