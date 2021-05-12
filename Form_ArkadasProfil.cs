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
    public partial class Form_ArkadasProfil : Form
    {
        public Form_ArkadasProfil()
        {
            InitializeComponent();
        }
        sinif s = new sinif();
        DataTable tablom = new DataTable();
        Profil p = new Profil();
        //Form_ArkadasProfil ap = new Form_ArkadasProfil();
        DataTable bilgi_tablom = new DataTable();

        private void Form_ArkadasProfil_Load(object sender, EventArgs e)
        {
            //Uye Bilgilerinin Getirilmesi
            bilgi_tablom = s.UyeProfilBilgileriGetir(sinif.ArkadasNo);
            if (bilgi_tablom.Rows.Count > 0)
            {
                lbmail.Text = bilgi_tablom.Rows[0][0].ToString();
                lbmeslek.Text = bilgi_tablom.Rows[0][1].ToString();
                lbokul.Text = bilgi_tablom.Rows[0][2].ToString();
                lbDogumTarihi.Text = bilgi_tablom.Rows[0][3].ToString();
                lbiliski.Text = bilgi_tablom.Rows[0][4].ToString();
            }
            else
                MessageBox.Show("Tabloda Kayıt Bulunamadı!");

            pArkadaslar.AutoScroll = true;
            pnlAnasayfa.AutoScroll = true;
            s.paylasim_getir_profil(pnlAnasayfa,sinif.ArkadasNo);
            s.ArkadasGetir(pArkadaslar, sinif.ArkadasNo);
            s.anasayfa_doldur(sinif.ArkadasNo, pbArkadas, label1);


            tablom = s.ArkadasDurum();
            if (tablom.Rows.Count > 0)
            {
                if (tablom.Rows[0][0].ToString() == "1")
                {
                    button1.Visible = false;
                    // button2.Visible = true;
                    button3.Visible = false;
                }
               /* else if (tablom.Rows[0][0].ToString() == "2" || tablom.Rows[0][0] == null)
                {
                    //   button1.Visible = true;
                    button2.Visible = false;
                    button3.Visible = false;

                }*/
                else if (tablom.Rows[0][0].ToString() == "3")
                {
                    button1.Visible = false;
                    button2.Visible = false;
                    //  button3.Visible = true;
                }
                else if (tablom.Rows.Count == 0)
                {
                    //  button1.Visible = true;
                    button2.Visible = false;
                    button3.Visible = false;
                }
                

           
            }
            else
            {
           //   button1.Visible = true;
                button2.Visible = false;
                button3.Visible = false;

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            s.Arkadasekle();
            s.ArkadasGetir(pArkadaslar, sinif.ArkadasNo);
          // s.formacma(p, Form1.panelim);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            s.Arkadassilme();
            s.ArkadasGetir(pArkadaslar, sinif.ArkadasNo);
         //  s.formacma(, Form1.panelim);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            s.Arkadasıptal();
            s.ArkadasGetir(pArkadaslar, sinif.ArkadasNo);
           // s.formacma(p, Form1.panelim);

        }

        private void btDurt_Click(object sender, EventArgs e)
        {
            s.Durtme();
        }


    }
}
