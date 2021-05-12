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
    public partial class Form_ArkadasIstekleri : Form
    {
    
        public Form_ArkadasIstekleri()
        {
            InitializeComponent();
        }
        sinif s = new sinif();
        public static Panel panel;
        private void Form_ArkadasIstekleri_Load(object sender, EventArgs e)
        {
            panel = panel1;
            panel1.AutoScroll = true;
            panel1.Controls.Clear();
            s.ArkadasIstekleri(panel1);
            
        }

   
    }
}
