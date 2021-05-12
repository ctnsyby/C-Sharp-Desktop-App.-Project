namespace KafaKagidi_ver._0
{
    partial class Form_AramaSonuclari
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
            this.pnlArama = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlArama
            // 
            this.pnlArama.Location = new System.Drawing.Point(13, 13);
            this.pnlArama.Name = "pnlArama";
            this.pnlArama.Size = new System.Drawing.Size(557, 292);
            this.pnlArama.TabIndex = 0;
            // 
            // Form_AramaSonuclari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(595, 321);
            this.Controls.Add(this.pnlArama);
            this.Name = "Form_AramaSonuclari";
            this.Text = "Arama Sonucları";
            this.Load += new System.EventHandler(this.Form_AramaSonuclari_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlArama;
    }
}