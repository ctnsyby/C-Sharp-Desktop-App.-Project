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
    public partial class Form_ResimDegistir : Form
    {
        public Form_ResimDegistir()
        {
            InitializeComponent();
        }
            sinif s=new sinif();
            OpenFileDialog op = new OpenFileDialog();


        private void button1_Click(object sender, EventArgs e)
        {

            s.ResimGetir(op, pictureBox1);
        }

        private void btOnayla_Click(object sender, EventArgs e)
        {
            s.ResimDegistir(op, pictureBox1);
          
        }

        private void Form_ResimDegistir_Load(object sender, EventArgs e)
        {

        }
    }
}
