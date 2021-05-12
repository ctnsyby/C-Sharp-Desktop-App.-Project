namespace KafaKagidi_ver._0
{
    partial class Form_FotografPaylas
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
            this.btKaydet = new System.Windows.Forms.Button();
            this.btGozat = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbbaslik = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btKaydet
            // 
            this.btKaydet.Location = new System.Drawing.Point(534, 203);
            this.btKaydet.Name = "btKaydet";
            this.btKaydet.Size = new System.Drawing.Size(75, 23);
            this.btKaydet.TabIndex = 7;
            this.btKaydet.Text = "Paylaş";
            this.btKaydet.UseVisualStyleBackColor = true;
            this.btKaydet.Click += new System.EventHandler(this.btKaydet_Click);
            // 
            // btGozat
            // 
            this.btGozat.Location = new System.Drawing.Point(247, 165);
            this.btGozat.Name = "btGozat";
            this.btGozat.Size = new System.Drawing.Size(75, 23);
            this.btGozat.TabIndex = 6;
            this.btGozat.Text = "Gözat";
            this.btGozat.UseVisualStyleBackColor = true;
            this.btGozat.Click += new System.EventHandler(this.btGozat_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(28, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(250, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Başlık";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(357, 166);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tbbaslik
            // 
            this.tbbaslik.Location = new System.Drawing.Point(255, 73);
            this.tbbaslik.Name = "tbbaslik";
            this.tbbaslik.Size = new System.Drawing.Size(312, 20);
            this.tbbaslik.TabIndex = 10;
            // 
            // Form_FotografPaylas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(643, 249);
            this.Controls.Add(this.tbbaslik);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btKaydet);
            this.Controls.Add(this.btGozat);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form_FotografPaylas";
            this.Text = "Fotoğraf Paylaş";
            this.Load += new System.EventHandler(this.Form_FotografPaylas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btKaydet;
        private System.Windows.Forms.Button btGozat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tbbaslik;
    }
}