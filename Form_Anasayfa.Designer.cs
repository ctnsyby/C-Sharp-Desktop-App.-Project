namespace KafaKagidi_ver._0
{
    partial class Form_Anasayfa
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
            this.btFoto = new System.Windows.Forms.Button();
            this.lbAd = new System.Windows.Forms.Label();
            this.pbResim = new System.Windows.Forms.PictureBox();
            this.pnlAnasayfa = new System.Windows.Forms.Panel();
            this.tbAra = new System.Windows.Forms.TextBox();
            this.btYazi = new System.Windows.Forms.Button();
            this.btLink = new System.Windows.Forms.Button();
            this.btAra = new System.Windows.Forms.Button();
            this.pArkadaslar = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbResim)).BeginInit();
            this.SuspendLayout();
            // 
            // btFoto
            // 
            this.btFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btFoto.ForeColor = System.Drawing.Color.Navy;
            this.btFoto.Location = new System.Drawing.Point(422, 70);
            this.btFoto.Name = "btFoto";
            this.btFoto.Size = new System.Drawing.Size(155, 23);
            this.btFoto.TabIndex = 0;
            this.btFoto.Text = "Fotoğraf Paylaş";
            this.btFoto.UseVisualStyleBackColor = true;
            this.btFoto.Click += new System.EventHandler(this.btFoto_Click);
            // 
            // lbAd
            // 
            this.lbAd.AutoSize = true;
            this.lbAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbAd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbAd.Location = new System.Drawing.Point(24, 293);
            this.lbAd.Name = "lbAd";
            this.lbAd.Size = new System.Drawing.Size(46, 17);
            this.lbAd.TabIndex = 1;
            this.lbAd.Text = "label1";
            // 
            // pbResim
            // 
            this.pbResim.Location = new System.Drawing.Point(27, 99);
            this.pbResim.Name = "pbResim";
            this.pbResim.Size = new System.Drawing.Size(190, 181);
            this.pbResim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbResim.TabIndex = 2;
            this.pbResim.TabStop = false;
            // 
            // pnlAnasayfa
            // 
            this.pnlAnasayfa.BackColor = System.Drawing.Color.White;
            this.pnlAnasayfa.Location = new System.Drawing.Point(422, 99);
            this.pnlAnasayfa.Name = "pnlAnasayfa";
            this.pnlAnasayfa.Size = new System.Drawing.Size(487, 568);
            this.pnlAnasayfa.TabIndex = 3;
            // 
            // tbAra
            // 
            this.tbAra.Location = new System.Drawing.Point(27, 46);
            this.tbAra.Name = "tbAra";
            this.tbAra.Size = new System.Drawing.Size(148, 20);
            this.tbAra.TabIndex = 4;
            // 
            // btYazi
            // 
            this.btYazi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btYazi.ForeColor = System.Drawing.Color.Navy;
            this.btYazi.Location = new System.Drawing.Point(597, 70);
            this.btYazi.Name = "btYazi";
            this.btYazi.Size = new System.Drawing.Size(140, 23);
            this.btYazi.TabIndex = 5;
            this.btYazi.Text = "Ne Düşünüyorsun?";
            this.btYazi.UseVisualStyleBackColor = true;
            this.btYazi.Click += new System.EventHandler(this.btYazi_Click);
            // 
            // btLink
            // 
            this.btLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btLink.ForeColor = System.Drawing.Color.Navy;
            this.btLink.Location = new System.Drawing.Point(757, 70);
            this.btLink.Name = "btLink";
            this.btLink.Size = new System.Drawing.Size(156, 23);
            this.btLink.TabIndex = 6;
            this.btLink.Text = "Link Ver";
            this.btLink.UseVisualStyleBackColor = true;
            this.btLink.Click += new System.EventHandler(this.btLink_Click);
            // 
            // btAra
            // 
            this.btAra.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btAra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btAra.ForeColor = System.Drawing.Color.Navy;
            this.btAra.Location = new System.Drawing.Point(181, 46);
            this.btAra.Name = "btAra";
            this.btAra.Size = new System.Drawing.Size(93, 20);
            this.btAra.TabIndex = 7;
            this.btAra.Text = "ARA";
            this.btAra.UseVisualStyleBackColor = false;
            this.btAra.Click += new System.EventHandler(this.btAra_Click);
            // 
            // pArkadaslar
            // 
            this.pArkadaslar.BackColor = System.Drawing.Color.White;
            this.pArkadaslar.Location = new System.Drawing.Point(27, 325);
            this.pArkadaslar.Name = "pArkadaslar";
            this.pArkadaslar.Size = new System.Drawing.Size(200, 342);
            this.pArkadaslar.TabIndex = 8;
            this.pArkadaslar.Paint += new System.Windows.Forms.PaintEventHandler(this.pArkadaslar_Paint);
            // 
            // Form_Anasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1340, 679);
            this.Controls.Add(this.pArkadaslar);
            this.Controls.Add(this.lbAd);
            this.Controls.Add(this.btAra);
            this.Controls.Add(this.btLink);
            this.Controls.Add(this.btYazi);
            this.Controls.Add(this.tbAra);
            this.Controls.Add(this.pnlAnasayfa);
            this.Controls.Add(this.pbResim);
            this.Controls.Add(this.btFoto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Anasayfa";
            this.Text = "Form_Anasayfa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Anasayfa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbResim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btFoto;
        private System.Windows.Forms.Label lbAd;
        private System.Windows.Forms.PictureBox pbResim;
        private System.Windows.Forms.Panel pnlAnasayfa;
        private System.Windows.Forms.TextBox tbAra;
        private System.Windows.Forms.Button btYazi;
        private System.Windows.Forms.Button btLink;
        private System.Windows.Forms.Button btAra;
        private System.Windows.Forms.Panel pArkadaslar;
    }
}