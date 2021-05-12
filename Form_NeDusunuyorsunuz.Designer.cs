namespace KafaKagidi_ver._0
{
    partial class Form_NeDusunuyorsunuz
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
            this.btpaylas = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbnedusunuyorsun = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbbaslik = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btpaylas
            // 
            this.btpaylas.Location = new System.Drawing.Point(367, 274);
            this.btpaylas.Name = "btpaylas";
            this.btpaylas.Size = new System.Drawing.Size(88, 23);
            this.btpaylas.TabIndex = 0;
            this.btpaylas.Text = "Paylaş";
            this.btpaylas.UseVisualStyleBackColor = true;
            this.btpaylas.Click += new System.EventHandler(this.btpaylas_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(76, 274);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ne Düşünüyorsunz?";
            // 
            // rtbnedusunuyorsun
            // 
            this.rtbnedusunuyorsun.Location = new System.Drawing.Point(76, 84);
            this.rtbnedusunuyorsun.Name = "rtbnedusunuyorsun";
            this.rtbnedusunuyorsun.Size = new System.Drawing.Size(379, 165);
            this.rtbnedusunuyorsun.TabIndex = 3;
            this.rtbnedusunuyorsun.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Başlık";
            // 
            // tbbaslik
            // 
            this.tbbaslik.Location = new System.Drawing.Point(76, 25);
            this.tbbaslik.Name = "tbbaslik";
            this.tbbaslik.Size = new System.Drawing.Size(379, 20);
            this.tbbaslik.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Grup";
            // 
            // Form_NeDusunuyorsunuz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(533, 329);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbbaslik);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtbnedusunuyorsun);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btpaylas);
            this.Name = "Form_NeDusunuyorsunuz";
            this.Text = "Ne Düşünüyorsun?";
            this.Load += new System.EventHandler(this.Form_NeDusunuyorsunuz_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btpaylas;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbnedusunuyorsun;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbbaslik;
        private System.Windows.Forms.Label label3;
    }
}