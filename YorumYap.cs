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
    public partial class YorumYap : Form
    {
        public YorumYap()
        {
            InitializeComponent();
        }
        sinif s = new sinif();
        private void YorumYap_Load(object sender, EventArgs e)
        {
            panel1.AutoScroll = true;
            s.YorumGösterForm(panel1, Form_Giris.uyenogonder, sinif.PaylasimNoGonder);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tarih = DateTime.Now.ToShortDateString();
            string saat = DateTime.Now.ToShortTimeString();
            s.YorumEkle(Form_Giris.uyenogonder, sinif.PaylasimNoGonder, richTextBox1.Text,tarih,saat);
            s.YorumGösterForm(panel1, Form_Giris.uyenogonder, sinif.PaylasimNoGonder);
            richTextBox1.Text = "";
        }
    }
}
