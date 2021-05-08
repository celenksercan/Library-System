
namespace kutuphane
{
    partial class kitap_ekle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kitap_ekle));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.barkod = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.sira_no = new System.Windows.Forms.TextBox();
            this.kitap_sayisi = new System.Windows.Forms.TextBox();
            this.kitap_ismi = new System.Windows.Forms.TextBox();
            this.yazar_ismi = new System.Windows.Forms.TextBox();
            this.kategori = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(58, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barkod Numarası*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(56, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sıra Numarası";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(59, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Adet";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(59, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Kitap İsmi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(56, 338);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Yazar İsmi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(58, 412);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Kategori";
            // 
            // barkod
            // 
            this.barkod.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.barkod.Location = new System.Drawing.Point(64, 83);
            this.barkod.Multiline = true;
            this.barkod.Name = "barkod";
            this.barkod.Size = new System.Drawing.Size(208, 30);
            this.barkod.TabIndex = 0;
            this.barkod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.barkod_KeyPress);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(466, 450);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 51);
            this.button1.TabIndex = 6;
            this.button1.Text = "Kaydet";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(374, 125);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(258, 256);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Location = new System.Drawing.Point(207, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(218, 39);
            this.label7.TabIndex = 18;
            this.label7.Text = "Kitap Ekleme";
            // 
            // sira_no
            // 
            this.sira_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sira_no.Location = new System.Drawing.Point(63, 153);
            this.sira_no.Multiline = true;
            this.sira_no.Name = "sira_no";
            this.sira_no.Size = new System.Drawing.Size(208, 30);
            this.sira_no.TabIndex = 1;
            this.sira_no.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sira_no_KeyPress);
            // 
            // kitap_sayisi
            // 
            this.kitap_sayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kitap_sayisi.Location = new System.Drawing.Point(63, 223);
            this.kitap_sayisi.Multiline = true;
            this.kitap_sayisi.Name = "kitap_sayisi";
            this.kitap_sayisi.Size = new System.Drawing.Size(208, 30);
            this.kitap_sayisi.TabIndex = 2;
            this.kitap_sayisi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kitap_sayisi_KeyPress);
            // 
            // kitap_ismi
            // 
            this.kitap_ismi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kitap_ismi.Location = new System.Drawing.Point(61, 293);
            this.kitap_ismi.Multiline = true;
            this.kitap_ismi.Name = "kitap_ismi";
            this.kitap_ismi.Size = new System.Drawing.Size(208, 30);
            this.kitap_ismi.TabIndex = 3;
            // 
            // yazar_ismi
            // 
            this.yazar_ismi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yazar_ismi.Location = new System.Drawing.Point(64, 366);
            this.yazar_ismi.Multiline = true;
            this.yazar_ismi.Name = "yazar_ismi";
            this.yazar_ismi.Size = new System.Drawing.Size(208, 30);
            this.yazar_ismi.TabIndex = 4;
            this.yazar_ismi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.yazar_ismi_KeyPress);
            // 
            // kategori
            // 
            this.kategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kategori.Location = new System.Drawing.Point(64, 440);
            this.kategori.Multiline = true;
            this.kategori.Name = "kategori";
            this.kategori.Size = new System.Drawing.Size(208, 30);
            this.kategori.TabIndex = 5;
            this.kategori.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kategori_KeyPress);
            // 
            // sp_kitap_ekle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(690, 535);
            this.Controls.Add(this.kategori);
            this.Controls.Add(this.yazar_ismi);
            this.Controls.Add(this.kitap_ismi);
            this.Controls.Add(this.kitap_sayisi);
            this.Controls.Add(this.sira_no);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.barkod);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "sp_kitap_ekle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Kitap Kartı Girişi";
            this.Load += new System.EventHandler(this.sp_kitap_ekle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox barkod;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox sira_no;
        private System.Windows.Forms.TextBox kitap_sayisi;
        private System.Windows.Forms.TextBox kitap_ismi;
        private System.Windows.Forms.TextBox yazar_ismi;
        private System.Windows.Forms.TextBox kategori;
    }
}

