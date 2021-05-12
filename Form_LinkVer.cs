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
    public partial class Form_LinkVer : Form
    {
        public Form_LinkVer()
        {
            InitializeComponent();
        }
        sinif s = new sinif();
        private void btPaylas_Click(object sender, EventArgs e)
        {
            string baslik = tbBaslik.Text;
            string link = tbLink.Text;
            string tarih = DateTime.Now.ToShortDateString();
            string saat = DateTime.Now.ToShortTimeString();
            int grupid = Convert.ToInt32(comboBox1.SelectedValue);
            s.LinkPaylas(baslik,link,grupid,tarih,saat);
            Form_Anasayfa.panl.Controls.Clear();
            s.paylasim_getir(Form_Anasayfa.panl, Form_Giris.uyenogonder);



        }

        private void Form_LinkVer_Load(object sender, EventArgs e)
        {
            
            s.ComboboxDoldur(comboBox1);


        }
    }
}
