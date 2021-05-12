using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KafaKagidi_ver._0
{
    public partial class Form_NeDusunuyorsunuz : Form
    {
        public Form_NeDusunuyorsunuz()
        {
            InitializeComponent();
        }

        sinif s = new sinif();
        private void btpaylas_Click(object sender, EventArgs e)
        {
            string baslik = tbbaslik.Text;
            string metin = rtbnedusunuyorsun.Text;
            string tarih = DateTime.Now.ToShortDateString();
            string saat = DateTime.Now.ToShortTimeString();
            int grupid = Convert.ToInt32(comboBox1.SelectedValue);

            s.MetinPaylas(baslik, metin, grupid, tarih, saat);
            Form_Anasayfa.panl.Controls.Clear();
            s.paylasim_getir(Form_Anasayfa.panl, Form_Giris.uyenogonder);
        }

        private void Form_NeDusunuyorsunuz_Load(object sender, EventArgs e)
        {
            s.ComboboxDoldur(comboBox1);
        }
    }
}
