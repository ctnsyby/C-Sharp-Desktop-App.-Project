namespace KafaKagidi_ver._0
{
    partial class Form_LinkVer
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
            this.tbBaslik = new System.Windows.Forms.TextBox();
            this.btPaylas = new System.Windows.Forms.Button();
            this.tbLink = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbBaslik
            // 
            this.tbBaslik.Location = new System.Drawing.Point(105, 76);
            this.tbBaslik.Name = "tbBaslik";
            this.tbBaslik.Size = new System.Drawing.Size(253, 20);
            this.tbBaslik.TabIndex = 0;
            // 
            // btPaylas
            // 
            this.btPaylas.Location = new System.Drawing.Point(274, 185);
            this.btPaylas.Name = "btPaylas";
            this.btPaylas.Size = new System.Drawing.Size(75, 23);
            this.btPaylas.TabIndex = 1;
            this.btPaylas.Text = "Paylaş";
            this.btPaylas.UseVisualStyleBackColor = true;
            this.btPaylas.Click += new System.EventHandler(this.btPaylas_Click);
            // 
            // tbLink
            // 
            this.tbLink.Location = new System.Drawing.Point(105, 131);
            this.tbLink.Name = "tbLink";
            this.tbLink.Size = new System.Drawing.Size(253, 20);
            this.tbLink.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "LİNK";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "BAŞLIK";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(105, 185);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // Form_LinkVer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(469, 288);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbLink);
            this.Controls.Add(this.btPaylas);
            this.Controls.Add(this.tbBaslik);
            this.Name = "Form_LinkVer";
            this.Text = "Link Paylaş";
            this.Load += new System.EventHandler(this.Form_LinkVer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbBaslik;
        private System.Windows.Forms.Button btPaylas;
        private System.Windows.Forms.TextBox tbLink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}