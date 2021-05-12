using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace KafaKagidi_ver._0
{
    public partial class Form_FotografPaylas : Form
    {
        
        public Form_FotografPaylas()
        {
            InitializeComponent();
        }
        sinif s = new sinif();
        

        private void Form_FotografPaylas_Load(object sender, EventArgs e)
        {
            s.ComboboxDoldur(comboBox1);
        }

        private void btGozat_Click(object sender, EventArgs e)
        {
            s.ResimGetir(openFileDialog1, pictureBox1);
        }

        private void btKaydet_Click(object sender, EventArgs e)
        {

            string baslik = tbbaslik.Text;
            int grupid = Convert.ToInt32(comboBox1.SelectedValue);
            string tarih = DateTime.Now.ToShortDateString();
            string saat = DateTime.Now.ToShortTimeString();
            s.ResimPaylas(openFileDialog1, baslik, grupid,tarih,saat);
            Form_Anasayfa.panl.Controls.Clear();
            s.paylasim_getir(Form_Anasayfa.panl, Form_Giris.uyenogonder);
            

        }

    }
}
