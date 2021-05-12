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
    public partial class Form_SifreDegistir : Form
    {
        public Form_SifreDegistir()
        {
            InitializeComponent();
        }
        sinif s = new sinif();
        private void btOnayla_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == textBox4.Text)
            {
                s.SifreDegistir(textBox3.Text, Form_Giris.uyenogonder);
            }
            else
            {

                MessageBox.Show("Şifreniz Uyuşmuyor!!");
            }
            textBox3.Text = "";
            textBox4.Text = "";

        }

        private void Form_SifreDegistir_Load(object sender, EventArgs e)
        {
             textBox3.PasswordChar = '*';
             textBox4.PasswordChar = '*';
        }
    }
}
