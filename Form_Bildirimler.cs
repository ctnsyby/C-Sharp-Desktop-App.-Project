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
    public partial class Form_Bildirimler : Form
    {
        public Form_Bildirimler()
        {
            InitializeComponent();
        }
        sinif s = new sinif();
        private void Form_Bildirimler_Load(object sender, EventArgs e)
        {
            s.BildirimleriGoster(listBox1);
        }
    }
}
