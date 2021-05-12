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
    public partial class Form_Giris : Form
    {
        public Form_Giris()
        {
            InitializeComponent();
        }

        sinif s = new sinif();

        Form_Anasayfa ana = new Form_Anasayfa();


        public static int uyenogonder;

        private void Form_Giris_Load(object sender, EventArgs e)
        {
            tb_sifresi.PasswordChar = '*';
            tb_sifre.PasswordChar = '*';
            tb_tekrar.PasswordChar = '*';
            
        }

        private void bt_giris_Click(object sender, EventArgs e)
        {
            int onay = s.giris_yap(tb_adi.Text,tb_sifre.Text);
            if (onay >= 0)
            {
                uyenogonder = onay;
                s.formacma(ana, Form1.panelim);
            }
            else
                MessageBox.Show("Kullanıcı adı veya şifre yanlış!");

        }

        private void temizle()
        {
            tb_egitim.Text = "";
            tb_kuladi.Text = "";
            tb_email.Text = "";
            tb_isim.Text = "";
            tb_soyisim.Text = "";
            tb_meslek.Text = "";
            tb_sifresi.Text = "";
            tb_tekrar.Text = "";
            UyeResim.Image = null;
            dtp_dogum.Value = DateTime.Now;
        }
        private void bt_kaydol_Click(object sender, EventArgs e)
        {
            dtp_dogum.Format = DateTimePickerFormat.Custom;
            string dogumtarihi = dtp_dogum.Text;

            if (tb_sifresi.Text == tb_tekrar.Text && UyeResim.Image != null && tb_isim.Text!="" && tb_sifresi.Text!="" && tb_kuladi.Text!="")
            {
                s.kaydol(tb_kuladi.Text, tb_sifresi.Text, tb_isim.Text, tb_soyisim.Text, dogumtarihi, tb_meslek.Text, tb_egitim.Text, tb_email.Text,oFDResim);
                temizle();
            }
            else if (tb_sifresi.Text != tb_tekrar.Text)
            {
                MessageBox.Show("Şifrenizi Kontrol Edin");
                temizle();
            }
            else if (UyeResim.Image == null)
            {
                MessageBox.Show("Resim Seçmediniz");
            }
            else if (UyeResim.Image == null || tb_isim.Text == "" || tb_sifresi.Text == "" || tb_kuladi.Text == "")
            {
                MessageBox.Show("Bilgilerinizi Kontrol Ediniz!");
            }

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult cevap = oFDResim.ShowDialog();
            if (cevap == DialogResult.OK)
            {
                // OpenDialog nesnemle açtığım resmi PictureBox nesneme yerleştiriyorum.
                UyeResim.Image = Image.FromFile(oFDResim.FileName);

            }
            else
            {
                MessageBox.Show("Dosya Seçilmedi :)");
            }
        }




    }
}
