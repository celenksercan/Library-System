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
    public partial class kitap_arama : Form
    {
        public kitap_arama()
        {
            InitializeComponent();
        }

        private void kitap_arama_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // form boyutunu sabitleme
           
            //MsAccess bağlantısı
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");
            OleDbDataAdapter da;
            DataSet ds;
            //dataadapter query sorgusu
            da = new OleDbDataAdapter("SELECT *from kitap", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "kitap");
            con.Close();
            this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // tüm sütunları datagridview'e sığdırma
            dataGridView2.DataSource = ds.Tables["kitap"];  //dbdeki kitap tablosunu datagridview'e çek
            dataGridView2.ReadOnly = true;
            dataGridView2.Columns[0].DefaultCellStyle.BackColor = Color.White;
            for (int i = 0; i < dataGridView2.Rows.Count; i++) // datagridview'deki tüm select ifadeleri false'a çevir
            {
                dataGridView2.Rows[i].Selected = false;
            }


            con.Close();
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";  //textbox text'i temizle
            //datagridview tüm hücleri dolaşıp backcoloru beyaz yap
            for (int i = 0; i <= dataGridView2.Rows.Count - 1; i++)
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    foreach (DataGridViewCell cell in dataGridView2.Rows[i].Cells)
                    {
                        cell.Style.BackColor = Color.White;
                    }
                }
            }
                   }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


            // ARAMA İŞLEVİ
            string aranan = textBox1.Text.Trim().ToUpper(); //gelen text değeri aranan stringine ata
            //tüm datagridview hücrelerini dolaş
            for (int i = 0; i <= dataGridView2.Rows.Count - 1; i++)
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    foreach (DataGridViewCell cell in dataGridView2.Rows[i].Cells)
                    {
                        if (cell.Value != null)
                        {

                            if (cell.Value.ToString().ToUpper() == aranan)  //aranan kelime hücreden gelen değere eşit ise
                            {
                                cell.Style.BackColor = Color.DarkTurquoise;  //backcolor değiştir
                                dataGridView2.FirstDisplayedCell = cell;    //hücreye git.
                                break;
                            }

                        }
                    }
                }
            }
            
        }
    
        }
    
}
