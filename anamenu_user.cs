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
    public partial class anamenu_user : Form
    {
        public anamenu_user()
        {
            InitializeComponent();
        }

        private void anamenu_user_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;  // form boyutunu sabitle
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kitap_arama qz = new kitap_arama(); // qz adında yeni bir kitap_arama formu türet
            
            qz.ShowDialog();


        }
    }
}
