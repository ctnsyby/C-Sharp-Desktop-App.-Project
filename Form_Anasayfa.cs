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
    public partial class Form_Anasayfa : Form
    {
        public Form_Anasayfa()
        {
            InitializeComponent();
        }

        
        sinif s = new sinif();
       
        
        public static Panel panl = null;

        public static string Aranan = "";
       
        private void Form_Anasayfa_Load(object sender, EventArgs e)
        {
            int uyeno = Form_Giris.uyenogonder;
            Form1.menum.Show();
            s.anasayfa_doldur(uyeno,pbResim,lbAd);
            s.paylasim_getir(pnlAnasayfa, uyeno);
            panl = pnlAnasayfa;
            pnlAnasayfa.AutoScroll = true;
            pArkadaslar.AutoScroll = true;
            s.ArkadasGetir(pArkadaslar, uyeno);
        }

        private void btFoto_Click(object sender, EventArgs e)
        {
            Form_FotografPaylas ffp = new Form_FotografPaylas();
            ffp.ShowDialog();
            pnlAnasayfa.Controls.Clear();
            s.anasayfa_doldur(Form_Giris.uyenogonder, pbResim, lbAd);
            s.paylasim_getir(pnlAnasayfa, Form_Giris.uyenogonder);
        
        }

        private void btYazi_Click(object sender, EventArgs e)
        {
            Form_NeDusunuyorsunuz n = new Form_NeDusunuyorsunuz();
            n.ShowDialog();
            pnlAnasayfa.Controls.Clear();
            s.anasayfa_doldur(Form_Giris.uyenogonder, pbResim, lbAd);
            s.paylasim_getir(pnlAnasayfa, Form_Giris.uyenogonder);
            
        }

        private void btLink_Click(object sender, EventArgs e)
        {
            Form_LinkVer link = new Form_LinkVer();
            link.ShowDialog();
            pnlAnasayfa.Controls.Clear();
            s.anasayfa_doldur(Form_Giris.uyenogonder, pbResim, lbAd);
            s.paylasim_getir(pnlAnasayfa, Form_Giris.uyenogonder);
          

        }

        private void btAra_Click(object sender, EventArgs e)
        {
            if (tbAra.Text != "")
            {
                Aranan = tbAra.Text;
                Form_AramaSonuclari arama = new Form_AramaSonuclari();
                arama.Show();
                tbAra.Text = "";
            }
            else
                MessageBox.Show("Lütfen Arayacağınız Kişiyi Yazınız");
        }

        private void pArkadaslar_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
