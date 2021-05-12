namespace KafaKagidi_ver._0
{
    partial class Form_Ayarlar
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
            this.pnlAyarlar = new System.Windows.Forms.Panel();
            this.lbkullanıcı = new System.Windows.Forms.Label();
            this.lbSifredegistir = new System.Windows.Forms.Label();
            this.lbFotodegistir = new System.Windows.Forms.Label();
            this.lbGrupAyarları = new System.Windows.Forms.Label();
            this.lbBilgiler = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlAyarlar
            // 
            this.pnlAyarlar.BackColor = System.Drawing.Color.White;
            this.pnlAyarlar.Location = new System.Drawing.Point(621, 12);
            this.pnlAyarlar.Name = "pnlAyarlar";
            this.pnlAyarlar.Size = new System.Drawing.Size(700, 651);
            this.pnlAyarlar.TabIndex = 1;
            // 
            // lbkullanıcı
            // 
            this.lbkullanıcı.AutoSize = true;
            this.lbkullanıcı.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbkullanıcı.ForeColor = System.Drawing.Color.Navy;
            this.lbkullanıcı.Location = new System.Drawing.Point(57, 68);
            this.lbkullanıcı.Name = "lbkullanıcı";
            this.lbkullanıcı.Size = new System.Drawing.Size(173, 20);
            this.lbkullanıcı.TabIndex = 2;
            this.lbkullanıcı.Text = "Kullanıcı Adı Değiştir";
            this.lbkullanıcı.Click += new System.EventHandler(this.lbkullanıcı_Click);
            // 
            // lbSifredegistir
            // 
            this.lbSifredegistir.AutoSize = true;
            this.lbSifredegistir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbSifredegistir.ForeColor = System.Drawing.Color.Navy;
            this.lbSifredegistir.Location = new System.Drawing.Point(57, 129);
            this.lbSifredegistir.Name = "lbSifredegistir";
            this.lbSifredegistir.Size = new System.Drawing.Size(114, 20);
            this.lbSifredegistir.TabIndex = 3;
            this.lbSifredegistir.Text = "Şifre Değiştir";
            this.lbSifredegistir.Click += new System.EventHandler(this.lbSifredegistir_Click);
            // 
            // lbFotodegistir
            // 
            this.lbFotodegistir.AutoSize = true;
            this.lbFotodegistir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbFotodegistir.ForeColor = System.Drawing.Color.Navy;
            this.lbFotodegistir.Location = new System.Drawing.Point(57, 189);
            this.lbFotodegistir.Name = "lbFotodegistir";
            this.lbFotodegistir.Size = new System.Drawing.Size(145, 20);
            this.lbFotodegistir.TabIndex = 4;
            this.lbFotodegistir.Text = "Fotoğraf Değiştir";
            this.lbFotodegistir.Click += new System.EventHandler(this.lbFotodegistir_Click);
            // 
            // lbGrupAyarları
            // 
            this.lbGrupAyarları.AutoSize = true;
            this.lbGrupAyarları.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbGrupAyarları.ForeColor = System.Drawing.Color.Navy;
            this.lbGrupAyarları.Location = new System.Drawing.Point(57, 305);
            this.lbGrupAyarları.Name = "lbGrupAyarları";
            this.lbGrupAyarları.Size = new System.Drawing.Size(114, 20);
            this.lbGrupAyarları.TabIndex = 6;
            this.lbGrupAyarları.Text = "Grup Ayarları";
            this.lbGrupAyarları.Click += new System.EventHandler(this.lbGrupAyarları_Click);
            // 
            // lbBilgiler
            // 
            this.lbBilgiler.AutoSize = true;
            this.lbBilgiler.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbBilgiler.ForeColor = System.Drawing.Color.Navy;
            this.lbBilgiler.Location = new System.Drawing.Point(57, 243);
            this.lbBilgiler.Name = "lbBilgiler";
            this.lbBilgiler.Size = new System.Drawing.Size(143, 20);
            this.lbBilgiler.TabIndex = 7;
            this.lbBilgiler.Text = "Bilgileri Güncelle";
            this.lbBilgiler.Click += new System.EventHandler(this.lbBilgiler_Click);
            // 
            // Form_Ayarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1333, 675);
            this.Controls.Add(this.lbBilgiler);
            this.Controls.Add(this.lbGrupAyarları);
            this.Controls.Add(this.lbFotodegistir);
            this.Controls.Add(this.lbSifredegistir);
            this.Controls.Add(this.lbkullanıcı);
            this.Controls.Add(this.pnlAyarlar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Ayarlar";
            this.Text = "Form_Ayarlar";
            this.Load += new System.EventHandler(this.Form_Ayarlar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlAyarlar;
        private System.Windows.Forms.Label lbkullanıcı;
        private System.Windows.Forms.Label lbSifredegistir;
        private System.Windows.Forms.Label lbFotodegistir;
        private System.Windows.Forms.Label lbGrupAyarları;
        private System.Windows.Forms.Label lbBilgiler;
    }
}