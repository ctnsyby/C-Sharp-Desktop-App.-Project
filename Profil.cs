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
    public partial class Profil : Form
    {
        public Profil()
        {
            InitializeComponent();
        }
        sinif s = new sinif();
       
        DataTable bilgi_tablom = new DataTable();
        private void Profil_Load(object sender, EventArgs e)
        {

            bilgi_tablom = s.UyeProfilBilgileriGetir(Form_Giris.uyenogonder);
            lbmail.Text = bilgi_tablom.Rows[0][0].ToString();
            lbmeslek.Text = bilgi_tablom.Rows[0][1].ToString();
            lbokul.Text = bilgi_tablom.Rows[0][2].ToString();
            lbDogumTarihi.Text = bilgi_tablom.Rows[0][3].ToString();
            lbiliski.Text = bilgi_tablom.Rows[0][4].ToString();
            pArkadaslar.AutoScroll = true;
            pnlProfil.AutoScroll = true;
            s.anasayfa_doldur(Form_Giris.uyenogonder, pbResim, lbAd);
            pnlProfil.Controls.Clear();
            s.paylasim_getir_profil(pnlProfil, Form_Giris.uyenogonder);
            s.ArkadasGetir(pArkadaslar, Form_Giris.uyenogonder);
            
        }


        private void btFoto_Click(object sender, EventArgs e)
        {
            Form_FotografPaylas ffp = new Form_FotografPaylas();
            ffp.ShowDialog();
            pnlProfil.Controls.Clear();
            s.paylasim_getir_profil(pnlProfil, Form_Giris.uyenogonder);
        }

        private void btYazi_Click(object sender, EventArgs e)
        {
            Form_NeDusunuyorsunuz n = new Form_NeDusunuyorsunuz();
            n.ShowDialog();
            pnlProfil.Controls.Clear();
            s.paylasim_getir_profil(pnlProfil, Form_Giris.uyenogonder);
        }

        private void btLink_Click(object sender, EventArgs e)
        {
            Form_LinkVer link = new Form_LinkVer();
            link.ShowDialog();
            pnlProfil.Controls.Clear();
            s.paylasim_getir_profil(pnlProfil, Form_Giris.uyenogonder);
        }

        private void btAra_Click(object sender, EventArgs e)
        {
            
            if (tbAra.Text != "")
            {
                Form_Anasayfa.Aranan = tbAra.Text;
                Form_AramaSonuclari arama = new Form_AramaSonuclari();
                arama.Show();
                tbAra.Text = "";
            }
            else
                MessageBox.Show("Lütfen Arayacağınız Kişiyi Yazınız");
        }

        
    }
}
