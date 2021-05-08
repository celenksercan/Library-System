using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.Data.OleDb;

namespace kutuphane
{
    public partial class zedgraph : Form
    {
        int toplam = 0;
        
        public zedgraph()
        {
            
            InitializeComponent();
        }


        
        
        private void test_Load(object sender, EventArgs e)
        {
          
            checkBox2.Text = "Kütüphanedeki Toplam Kitap Sayısı" + Environment.NewLine + "Grafiğini Göster/Gizle";
            checkBox3.Text = "Kütüphanede Verilmeye Hazır Kitap Sayısı" + Environment.NewLine + "Grafiğini Göster/Gizle";
            //ms access bağlantısı
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphane.accdb");
            //query sorgusu
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT *from odunc_kitap", con);
            DataSet ds;
            ds = new DataSet();
            da.Fill(ds, "odunc_kitap");
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  //tüm sütunları datagridview'e sığdırma
            dataGridView1.DataSource = ds.Tables["odunc_kitap"]; //db'deki ödünçkitap tablosunu datagridview'e çekme
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.White;
            
            // DATAGRİDVİEW 0.SÜTUNU YANİ ID SUTUNUNU DOLAŞIP ÖDÜNÇ KİTAP SAYISINI BULMA
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value != DBNull.Value)
                    {
                        string rak =Convert.ToString((dataGridView1.Rows[i].Cells[0].Value));
                        if (rak==null)
                        {
                            MessageBox.Show("odunc kitap yok");
                        }
                        else
                        {
                            toplam = toplam + 1;
                        }
                        
                    }

                }
            }
            label1.Text = "Toplam ödünç kitap sayısı = " + (toplam - 1);
            

            GraphPane grafik1 = zedGraphControl1.GraphPane; //graphane sınıfından grafik1 adında yeni bir graphane türet.
            grafik1.Title.Text = "Toplam Ödünç Kitap Sayısı";   //grafik1 adı
            grafik1.YAxis.Title.Text = "Kitap Sayısı";      //grafik1 y eksen adı
            grafik1.XAxis.Title.Text = "   ";   //grafik1 x eksen adı

            ZedGraph.PointPairList liste1 = new ZedGraph.PointPairList();  //pointpairlist sınıfından liste1 adında yeni bir pointpairlist türet.
            liste1.Add(0, toplam-1);
            BarItem bar1 = zedGraphControl1.GraphPane.AddBar("Toplam Ödünç Kitap Sayısı", liste1, Color.Red);
            bar1.Bar.Fill = new Fill(Color.Green);
            grafik1.BarSettings.Type = BarType.Cluster;  // bar tipi
            grafik1.BarSettings.ClusterScaleWidth = 1; //bar sıklığı
            zedGraphControl1.AxisChange();  // grafiği güncelle




            OleDbCommand xy = new OleDbCommand("SELECT COUNT(id) FROM kitap", con);  // kitap tablosundaki id'i sayıp kütüphanedeki toplam-
            con.Open();                                                              //kitap sayısını bulma

            Int32 zt = (Int32)xy.ExecuteScalar();

            GraphPane grafik2 = zedGraphControl2.GraphPane;     //graphane sınıfından grafik2 adında yeni bir graphane türet.
            grafik2.Title.Text = "Kütüphanedeki Toplam Kitap Sayısı";  //grafik2 adı
            grafik2.YAxis.Title.Text = "Kitap Sayısı";      //grafik2 y eksen adı
            grafik2.XAxis.Title.Text = "   ";   //grafik2 x eksen adı

            ZedGraph.PointPairList liste2 = new ZedGraph.PointPairList(); //pointpairlist sınıfından liste2 adında yeni bir pointpairlist türet.
            liste2.Add(0, zt);
            BarItem bar2 = zedGraphControl2.GraphPane.AddBar("Kütüphanedeki Toplam Kitap Sayısı", liste2, Color.Red);
            bar2.Bar.Fill = new Fill(Color.Yellow);
            grafik2.BarSettings.Type = BarType.Cluster; // bar tipi
            grafik2.BarSettings.ClusterScaleWidth = 1;  //bar sıklığı
            zedGraphControl2.AxisChange();  // grafiği güncelle
            label2.Text = "Toplam Kitap sayısı = " + zt;



            GraphPane grafik3 = zedGraphControl3.GraphPane;     //graphane sınıfından grafik1 adında yeni bir graphane türet.
            grafik3.Title.Text = "Kütüphanede Verilmeye Hazır Kitap Sayısı";  //grafik3 adı
            grafik3.YAxis.Title.Text = "Kitap Sayısı";      //grafik3 y eksen adı
            grafik3.XAxis.Title.Text = "   ";       //grafik1 x eksen adı

            ZedGraph.PointPairList liste3 = new ZedGraph.PointPairList();  //pointpairlist sınıfından liste1 adında yeni bir pointpairlist türet.
            //KÜTÜPHANEDEKİ TOPLAM KİTAP SAYISINDAN ÖDÜNÇ KİTAP SAYISI ÇIKARILDI.
            liste3.Add(0, zt-toplam+1);
            BarItem bar3 = zedGraphControl3.GraphPane.AddBar("Kütüphanede Verilmeye Hazır Kitap Sayısı", liste3, Color.Orange);
            bar3.Bar.Fill = new Fill(Color.Orange);
            grafik3.BarSettings.Type = BarType.Cluster; // bar tipi
            grafik3.BarSettings.ClusterScaleWidth = 1;  //bar sıklığı
            zedGraphControl3.AxisChange(); // grafiği güncelle
            label3.Text = "Toplam Kitap sayısı = " + (zt-toplam+1);







        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {


        }
          // CHECKBOX GÖR/GİZLE FONKSİYONLARININ DENETİMİNİN YAPILDIĞI BLOK
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (zedGraphControl1.Visible)
            {
                zedGraphControl1.Visible = false;
                label1.Visible = false;
            }
            else
            {
                zedGraphControl1.Visible = true;
                label1.Visible = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (zedGraphControl2.Visible)
            {
                zedGraphControl2.Visible = false;
                label2.Visible = false;
            }

            else
            {
                zedGraphControl2.Visible = true;
                label2.Visible = true;
            }
        }

        

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (zedGraphControl3.Visible)
            {
                zedGraphControl3.Visible = false;
                label3.Visible = false;
            }

            else
            {
                zedGraphControl3.Visible = true;
                label3.Visible = true;
            }
        }
    }
}
