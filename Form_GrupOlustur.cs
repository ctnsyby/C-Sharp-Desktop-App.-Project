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
    public partial class Form_GrupOlustur : Form
    {
        public Form_GrupOlustur()
        {
            InitializeComponent();
        }
        sinif s = new sinif();
        int grupid;
        private void Form_GrupOlustur_Load(object sender, EventArgs e)
        {
            s.GrupAyarlarıGrupListele(listBox1);
            s.TumArkadasları_Grup(lbTumArkds);
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            grupid = Convert.ToInt32(listBox1.SelectedValue);
           
            s.GrupArkadasListele(lbGrpArkds, grupid);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbGrup.Text != "")
            {
                s.YeniGrupOluştur(tbGrup.Text);
            }
            else
                MessageBox.Show("Grup Adını Boş Bırakamazsınız.");

            s.GrupAyarlarıGrupListele(listBox1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int arkadasno = Convert.ToInt32(lbTumArkds.SelectedValue);
            int grupno = Convert.ToInt32(listBox1.SelectedValue);
            s.GrubaArkadasEkle(arkadasno, grupno);
            s.GrupArkadasListele(lbGrpArkds, grupid);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int arkadasno =Convert.ToInt32(lbGrpArkds.SelectedValue);
            int grupno = Convert.ToInt32(listBox1.SelectedValue);
            s.ArkadasiGruptanCikar(arkadasno, grupno);
            s.GrupArkadasListele(lbGrpArkds, grupid);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
         
                int grupno = Convert.ToInt32(listBox1.SelectedValue);
                s.GrubuSil(grupno);
                s.GrupAyarlarıGrupListele(listBox1);
            
           

        }


    }
}
