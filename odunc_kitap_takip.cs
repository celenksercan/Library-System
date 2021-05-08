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
    public partial class odunc_kitap_takip : Form
    {
        public odunc_kitap_takip()
        {
            InitializeComponent();
        }



        private void oduc_kitap_takip_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;  //form boyutunu sabitleme
            //MsAccess bağlantısı
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");
            OleDbDataAdapter da;
            DataSet ds;
            //dataadapter query sorgusu
            da = new OleDbDataAdapter("SELECT *FROM  odunc_kitap", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "odunc_kitap");  //db'deki odunckitap tablosunu datagridview'e çekme
            con.Close();
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //tüm sütunları datagridview'e sığdırma
            dataGridView1.DataSource = ds.Tables["odunc_kitap"];
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.White;
            //seçilen tüm selected ifadeleri false yap
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Selected = false;
            }
            //datagridview tüm 11.sütunların hücrelerini dolaş  -- ceza fonksiyonu
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[11].Value != DBNull.Value)
                    {
                        int rak = Convert.ToInt32(dataGridView1.Rows[i].Cells[11].Value);
                        if (rak == 2)
                        {
                            dataGridView1.Rows[i].Cells[11].Style.BackColor = Color.Yellow;
                        }
                        else if (rak <= 0)
                        {
                            dataGridView1.Rows[i].Cells[11].Style.BackColor = Color.Red;
                        }

                    }

                }
            }
            con.Close();    //bağlantıyı kapatma
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // arama fonksiyonu
            //msaccess bağlantısı
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");
                OleDbDataAdapter da;
                DataSet ds;
            //query sorgusu
                da = new OleDbDataAdapter("Select *From odunc_kitap", con);
                ds = new DataSet();
                con.Open();
                da.Fill(ds, "odunc_kitap");
                DataView dv = ds.Tables["odunc_kitap"].DefaultView;
                string aranan = textBox1.Text.Trim().ToUpper();
            // ARAMA İŞLEVİ, TÜM DATAGRİDVİEW HÜCRELERİNİ DOLAŞMA
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
                                    cell.Style.BackColor = Color.Magenta;
                                dataGridView1.FirstDisplayedCell = cell;
                                break;
                                }
                            }
                        }
                    }
                }

            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";  // TEXTBOX TEXTİ TEMİZLEME
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
                    {
                        cell.Style.BackColor = Color.White;
                    }
                }
            }
            // DATAGRİDVİEW 11.SÜTÜN TÜM HÜCRELERİNİ DOLAŞMA -- CEZA FONKSİYONU
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[11].Value != DBNull.Value)
                    {
                        int rak = Convert.ToInt32(dataGridView1.Rows[i].Cells[11].Value);
                        if (rak == 2)
                        {
                            dataGridView1.Rows[i].Cells[11].Style.BackColor = Color.Yellow;
                        }
                        else if (rak <= 0)
                        {
                            dataGridView1.Rows[i].Cells[11].Style.BackColor = Color.Red;
                        }

                    }

                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
