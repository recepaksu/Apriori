namespace Apriori
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDosya = new System.Windows.Forms.Button();
            this.btnApriori = new System.Windows.Forms.Button();
            this.tbSupport = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tbConfidence = new System.Windows.Forms.TextBox();
            this.tbLift = new System.Windows.Forms.TextBox();
            this.tbLeverage = new System.Windows.Forms.TextBox();
            this.tbConviction = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFiltre = new System.Windows.Forms.Button();
            this.btnAra = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbKural = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnDosyaYaz = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDosya
            // 
            this.btnDosya.Location = new System.Drawing.Point(13, 13);
            this.btnDosya.Name = "btnDosya";
            this.btnDosya.Size = new System.Drawing.Size(75, 23);
            this.btnDosya.TabIndex = 0;
            this.btnDosya.Text = "Dosya Seç";
            this.btnDosya.UseVisualStyleBackColor = true;
            this.btnDosya.Click += new System.EventHandler(this.btnDosya_Click);
            // 
            // btnApriori
            // 
            this.btnApriori.Location = new System.Drawing.Point(190, 13);
            this.btnApriori.Name = "btnApriori";
            this.btnApriori.Size = new System.Drawing.Size(75, 23);
            this.btnApriori.TabIndex = 4;
            this.btnApriori.Text = "Apriori";
            this.btnApriori.UseVisualStyleBackColor = true;
            this.btnApriori.Click += new System.EventHandler(this.btnApriori_Click);
            // 
            // tbSupport
            // 
            this.tbSupport.Location = new System.Drawing.Point(357, 15);
            this.tbSupport.Name = "tbSupport";
            this.tbSupport.Size = new System.Drawing.Size(50, 20);
            this.tbSupport.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.ItemSize = new System.Drawing.Size(42, 18);
            this.tabControl1.Location = new System.Drawing.Point(13, 43);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1262, 489);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1254, 463);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Veriler";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1244, 450);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1254, 463);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Kurallar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(4, 7);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1244, 450);
            this.dataGridView2.TabIndex = 0;
            // 
            // tbConfidence
            // 
            this.tbConfidence.Location = new System.Drawing.Point(649, 15);
            this.tbConfidence.Name = "tbConfidence";
            this.tbConfidence.Size = new System.Drawing.Size(50, 20);
            this.tbConfidence.TabIndex = 8;
            // 
            // tbLift
            // 
            this.tbLift.Location = new System.Drawing.Point(744, 15);
            this.tbLift.Name = "tbLift";
            this.tbLift.Size = new System.Drawing.Size(50, 20);
            this.tbLift.TabIndex = 9;
            // 
            // tbLeverage
            // 
            this.tbLeverage.Location = new System.Drawing.Point(877, 15);
            this.tbLeverage.Name = "tbLeverage";
            this.tbLeverage.Size = new System.Drawing.Size(50, 20);
            this.tbLeverage.TabIndex = 10;
            // 
            // tbConviction
            // 
            this.tbConviction.Location = new System.Drawing.Point(1018, 15);
            this.tbConviction.Name = "tbConviction";
            this.tbConviction.Size = new System.Drawing.Size(50, 20);
            this.tbConviction.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(304, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Support:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(579, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Confidence:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(714, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Lift:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(816, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Leverage:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(952, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Conviction:";
            // 
            // btnFiltre
            // 
            this.btnFiltre.Location = new System.Drawing.Point(1075, 13);
            this.btnFiltre.Name = "btnFiltre";
            this.btnFiltre.Size = new System.Drawing.Size(75, 23);
            this.btnFiltre.TabIndex = 17;
            this.btnFiltre.Text = "Filtrele";
            this.btnFiltre.UseVisualStyleBackColor = true;
            this.btnFiltre.Click += new System.EventHandler(this.btnFiltre_Click);
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(100, 13);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(75, 23);
            this.btnAra.TabIndex = 18;
            this.btnAra.Text = "Ara İşlemler";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(426, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Kural Sayısı:";
            // 
            // tbKural
            // 
            this.tbKural.Location = new System.Drawing.Point(496, 15);
            this.tbKural.Name = "tbKural";
            this.tbKural.Size = new System.Drawing.Size(65, 20);
            this.tbKural.TabIndex = 20;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 548);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1287, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // btnDosyaYaz
            // 
            this.btnDosyaYaz.Location = new System.Drawing.Point(1181, 13);
            this.btnDosyaYaz.Name = "btnDosyaYaz";
            this.btnDosyaYaz.Size = new System.Drawing.Size(87, 36);
            this.btnDosyaYaz.TabIndex = 22;
            this.btnDosyaYaz.Text = "Sonucları Dosyaya Yaz";
            this.btnDosyaYaz.UseVisualStyleBackColor = true;
            this.btnDosyaYaz.Click += new System.EventHandler(this.btnDosyaYaz_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 570);
            this.Controls.Add(this.btnDosyaYaz);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tbKural);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.btnFiltre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbConviction);
            this.Controls.Add(this.tbLeverage);
            this.Controls.Add(this.tbLift);
            this.Controls.Add(this.tbConfidence);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tbSupport);
            this.Controls.Add(this.btnApriori);
            this.Controls.Add(this.btnDosya);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apriori";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDosya;
        private System.Windows.Forms.Button btnApriori;
        private System.Windows.Forms.TextBox tbSupport;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox tbConfidence;
        private System.Windows.Forms.TextBox tbLift;
        private System.Windows.Forms.TextBox tbLeverage;
        private System.Windows.Forms.TextBox tbConviction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFiltre;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbKural;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnDosyaYaz;
    }
}

