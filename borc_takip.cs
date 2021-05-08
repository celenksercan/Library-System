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
    public partial class borc_takip : Form
    {
        public borc_takip()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")    //textbox text'i sorgulama
            {

                MessageBox.Show("TC No boş geçilemez!");

                return;

            }
            else {
                //MsAccess bağlantısı
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");

                DataSet ds;
                //query sorgusu
                OleDbCommand kmt = new OleDbCommand("SELECT bugun_tarih_saat,teslim FROM  odunc_kitap where okur_tc_no=" + textBox1.Text, con);

                ds = new DataSet();
                con.Open(); //bağlantı açılıyor
                OleDbDataReader rdr = kmt.ExecuteReader(); //command derleniyor
                
                

                    DateTime son = DateTime.Now; // güncel zamanı son adlı değişkene ata
                    if (rdr.Read()) //datareader'i oku
                    {
                        DateTime buguntarih = Convert.ToDateTime(rdr["bugun_tarih_saat"]); //db'de bugun tarih saat tablosundan veriyi çekip değişkene ata
                        DateTime teslim = Convert.ToDateTime(rdr["teslim"]);    //db'de teslim tablosundan veriyi çekip değişkene ata
                        DateTime xy = DateTime.Now;  // güncel zamanı xy değişkenine ata
                        TimeSpan sonuc = teslim - xy;   // tarihleri birbirinden çıkar
                        double c = Convert.ToDouble(sonuc.TotalDays.ToString());    //çıkan sonucu güne çevir ve değişkene ata
                        int a = (int)c;
                        int z = 0;

                        z = (-a);
                        int ceza = z * 1;
                        if (a < 0)
                        {
                        int x = 0;
                            MessageBox.Show("teslim tarihi " + ceza + " gün geçmiştir.\n" + ceza + " TL cezanız vardır.");
                        //query sorgusu
                            OleDbCommand komut = new OleDbCommand("UPDATE odunc_kitap SET ceza = '" + ceza + "',teslime_kalan_gun='"+x+"'  WHERE okur_tc_no = " + textBox1.Text, con);
                        //tüm datagridview 5.sütunlarının hücrelerini dolaşmak için yapılan if bloğu --arama işlevi
                        if (dataGridView1.Rows.Count > 0)
                        {
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                if (dataGridView1.Rows[i].Cells[5].Value != DBNull.Value)
                                {

                                    if (textBox1.Text == Convert.ToString(dataGridView1.Rows[i].Cells[5].Value))
                                    {
                                        dataGridView1.FirstDisplayedCell = dataGridView1.Rows[i].Cells[5];
                                        dataGridView1.Rows[i].Cells[5].Style.BackColor = Color.CadetBlue;

                                    }


                                }

                            }
                        }

                        komut.ExecuteNonQuery(); //komut derleme


                        //query sorgusu
                            OleDbDataAdapter da = new OleDbDataAdapter("SELECT *from odunc_kitap", con);
                            ds = new DataSet();

                            da.Fill(ds, "odunc_kitap");

                            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dataGridView1.DataSource = ds.Tables["odunc_kitap"];  //db'deki odunc kitap tablosunu datagridview'e çek
                            dataGridView1.ReadOnly = true;
                            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.White;





                        }
                        else
                        {
                        //tüm datagridview 5.sütunlarının hücrelerini dolaşmak için yapılan if bloğu --arama işlevi
                        if (dataGridView1.Rows.Count > 0)
                        {
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                if (dataGridView1.Rows[i].Cells[5].Value != DBNull.Value)
                                {

                                    if (textBox1.Text == Convert.ToString(dataGridView1.Rows[i].Cells[5].Value))
                                    {
                                        dataGridView1.FirstDisplayedCell = dataGridView1.Rows[i].Cells[5];
                                        dataGridView1.Rows[i].Cells[5].Style.BackColor = Color.CadetBlue;

                                    }


                                }

                            }
                        }
                        MessageBox.Show("teslim tarihinize" + a + "gün vardır.");

                        }

                        con.Close();


                    }
                else
                {
                    MessageBox.Show("TC No sistemde kayıtlı degil.!");
                }

                ////tüm datagridview 11.sütunlarının ücrelerini dolaşmak için yapılan if bloğu -- teslim tarihi renklendirmesi
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
            }
        private void Form1_Load(object sender, EventArgs e)
        { label3.Text="Hocam program gerçek zamanlı çalıştığından dolayı"+Environment.NewLine+"2 gün kala olan kitapları görmek için 13 gün beklemek gerekiyor."+Environment.NewLine+"O yüzden databaseden elle değiştirme yaptım, çalıştığını görmeniz için.";

            this.FormBorderStyle = FormBorderStyle.FixedSingle; // form boyutunu sabitleme
            //MsAccess bağlantısı
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");
            OleDbDataAdapter da;
            DataSet ds;
            //dataadapter query sorgusu
            da = new OleDbDataAdapter("SELECT *from odunc_kitap", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "odunc_kitap");
            con.Close();
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //tüm sutunları datagridview'e sığdırma
            dataGridView1.DataSource = ds.Tables["odunc_kitap"]; //db'deki odunc kitap tablosunu datagridviewe çek
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.White;
            for (int i = 0; i < dataGridView1.Rows.Count; i++) //datagridview'deki tüm select ifadeleri false yap.
            {
                dataGridView1.Rows[i].Selected = false;
            }


            con.Close();
            //datagridview tüm 11.sütun huclerini dolaş -- ceza işlevi
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


        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Selected = false;
            }
            textBox1.Text = ""; //textbox text temizle
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
            //datagridview tüm 11.sütun huclerini dolaş -- ceza işlevi
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
    }
    }

