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
    public partial class Form_KullaniciAdiDegistir : Form
    {
        public Form_KullaniciAdiDegistir()
        {
            InitializeComponent();
        }
        sinif s = new sinif();
        private void Form_HesapAyarı_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            s.KullaniciAdiDegistir(textBox1.Text, Form_Giris.uyenogonder);
            textBox1.Text = "";
        }
    }
}
