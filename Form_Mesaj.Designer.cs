namespace KafaKagidi_ver._0
{
    partial class Form_Mesaj
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
            this.pnlMesajGonderenler = new System.Windows.Forms.Panel();
            this.pnlSohbet = new System.Windows.Forms.Panel();
            this.btGonder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbSohbet = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // pnlMesajGonderenler
            // 
            this.pnlMesajGonderenler.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlMesajGonderenler.Location = new System.Drawing.Point(12, 12);
            this.pnlMesajGonderenler.Name = "pnlMesajGonderenler";
            this.pnlMesajGonderenler.Size = new System.Drawing.Size(195, 639);
            this.pnlMesajGonderenler.TabIndex = 0;
            // 
            // pnlSohbet
            // 
            this.pnlSohbet.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlSohbet.Location = new System.Drawing.Point(250, 28);
            this.pnlSohbet.Name = "pnlSohbet";
            this.pnlSohbet.Size = new System.Drawing.Size(454, 623);
            this.pnlSohbet.TabIndex = 1;
            // 
            // btGonder
            // 
            this.btGonder.Location = new System.Drawing.Point(913, 238);
            this.btGonder.Name = "btGonder";
            this.btGonder.Size = new System.Drawing.Size(183, 52);
            this.btGonder.TabIndex = 3;
            this.btGonder.Text = "Gönder";
            this.btGonder.UseVisualStyleBackColor = true;
            this.btGonder.Click += new System.EventHandler(this.btGonder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(771, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cevap YAZ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(247, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "GELEN MESAJLAR";
            // 
            // rtbSohbet
            // 
            this.rtbSohbet.Location = new System.Drawing.Point(774, 28);
            this.rtbSohbet.Name = "rtbSohbet";
            this.rtbSohbet.Size = new System.Drawing.Size(454, 180);
            this.rtbSohbet.TabIndex = 6;
            this.rtbSohbet.Text = "";
            // 
            // Form_Mesaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1336, 677);
            this.Controls.Add(this.rtbSohbet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btGonder);
            this.Controls.Add(this.pnlSohbet);
            this.Controls.Add(this.pnlMesajGonderenler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Mesaj";
            this.Text = "Form_Mesaj";
            this.Load += new System.EventHandler(this.Form_Mesaj_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMesajGonderenler;
        private System.Windows.Forms.Panel pnlSohbet;
        private System.Windows.Forms.Button btGonder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbSohbet;
    }
}