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
    public partial class Form_Mesaj : Form
    {
        public Form_Mesaj()
        {
            InitializeComponent();
        }
        sinif s = new sinif();
        public static Panel pnlsohbetstk;
        public static Panel pnlmesajarkadas;
        public static RichTextBox rtcevap;
        private void Form_Mesaj_Load(object sender, EventArgs e)
        {
            rtbSohbet.Enabled = false;
            rtcevap = rtbSohbet;
            pnlmesajarkadas = pnlMesajGonderenler;
            pnlsohbetstk = pnlSohbet;
            pnlMesajGonderenler.AutoScroll = true;
            pnlSohbet.AutoScroll = true;
            s.ArkadaşlarıGetirMesaj(pnlMesajGonderenler);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btGonder_Click(object sender, EventArgs e)
        {
            s.MesajYaz(rtbSohbet.Text);
            rtbSohbet.Clear();
            pnlsohbetstk.Controls.Clear();
            s.Mesajlari_Listele(Form_Mesaj.pnlsohbetstk, sinif.ArkadasNo);

        }
    }
}
