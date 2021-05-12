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
    public partial class Form_Ayarlar : Form
    {
        public Form_Ayarlar()
        {
            InitializeComponent();
        }
        sinif s = new sinif();
        Form_KullaniciAdiDegistir kad = new Form_KullaniciAdiDegistir();
        Form_SifreDegistir sd = new Form_SifreDegistir();
        Form_BilgileriDegistir bd = new Form_BilgileriDegistir();
        Form_ResimDegistir rd = new Form_ResimDegistir();
        Form_GrupOlustur go = new Form_GrupOlustur();

        
      
        
        
   
        private void Form_Ayarlar_Load(object sender, EventArgs e)
        {
         

        }

        private void lbkullanıcı_Click(object sender, EventArgs e)
        {
            this.Refresh();
            pnlAyarlar.Controls.Clear();
            kad.TopLevel = false;//bu form üst düzey bir form değildir.
            kad.WindowState = FormWindowState.Maximized;
            pnlAyarlar.Controls.Add(kad);
            kad.Show();

            
            
        }

        private void lbSifredegistir_Click(object sender, EventArgs e)
        {
            this.Refresh();
            pnlAyarlar.Controls.Clear();
            sd.TopLevel = false;//bu form üst düzey bir form değildir.
            sd.WindowState = FormWindowState.Maximized;
            pnlAyarlar.Controls.Add(sd);
            sd.Show();
        }

        private void lbFotodegistir_Click(object sender, EventArgs e)
        {
            this.Refresh();
            pnlAyarlar.Controls.Clear();
            rd.TopLevel = false;//bu form üst düzey bir form değildir.
            rd.WindowState = FormWindowState.Maximized;
            pnlAyarlar.Controls.Add(rd);
            rd.Show();
        }

        private void lbBilgiler_Click(object sender, EventArgs e)
        {
            this.Refresh();
            pnlAyarlar.Controls.Clear();
            bd.TopLevel = false;//bu form üst düzey bir form değildir.
            bd.WindowState = FormWindowState.Maximized;
            pnlAyarlar.Controls.Add(bd);
            bd.Show();

        }

        private void lbGrupAyarları_Click(object sender, EventArgs e)
        {
            this.Refresh();
            pnlAyarlar.Controls.Clear();
            go.TopLevel = false;//bu form üst düzey bir form değildir.
            go.WindowState = FormWindowState.Maximized;
            pnlAyarlar.Controls.Add(go);
            go.Show();

        }
    }
}
