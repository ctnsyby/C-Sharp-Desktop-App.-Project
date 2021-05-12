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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //formlarımı tanımlıyorum
        Form_Giris grs = new Form_Giris();
        Form_Anasayfa ana = new Form_Anasayfa();
        Profil profil = new Profil();
        Form_ArkadasIstekleri ai = new Form_ArkadasIstekleri();
        Form_Mesaj mesaj = new Form_Mesaj();
        Form_Ayarlar ayar = new Form_Ayarlar();

        

        sinif s = new sinif();

        public static Panel panelim; //başka bir formda, bu panel içinde form açmak için statik tanımladık.
        public static MenuStrip menum; //ana form açıldığında görünür olacağından statik tanımladık.

        
        private void Form1_Load(object sender, EventArgs e)
        {
            
            s.formacma(grs, panel1);//paneldeki formu değiştirmek için kullandığım fonksiyonum.
            menuStrip1.Hide();
            //aşağıda statiklerimi tanımlıyorum.
            Form1.panelim = panel1;
            menum = menuStrip1;
        }

        private void aNASAYFAToolStripMenuItem_Click(object sender, EventArgs e)
        {

            s.formacma(ana, panel1);
        }

        private void pROFİLToolStripMenuItem_Click(object sender, EventArgs e)
        {

            s.formacma(profil, panel1);
        }

        private void aRKADAŞİSTEKLERİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ai.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mESAJLARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            s.formacma(mesaj, panel1);
        }

        private void aYARLARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            s.formacma(ayar, panel1);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void çIKIŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.menum.Hide();
            Form_Giris fg = new Form_Giris();
            s.formacma(fg, Form1.panelim);
            Form_Giris.uyenogonder = -1;
            Application.Restart();
        }

        private void bİLDİRİMLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Bildirimler fb = new Form_Bildirimler();
            fb.ShowDialog();
        }
    }
}
