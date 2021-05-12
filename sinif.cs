using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace KafaKagidi_ver._0
{
    class sinif
    {

        public sinif()
        { }
        public static int ArkadasNo = -1;
        public static int PaylasimNoGonder = -1;// YORUM YAPMAK VEYA YORUMLARI GÖRMEK İÇİN
        string baglanti_cumlesi = "data source=MYCOMPUTER; initial catalog=Nesne_Proje_2; integrated security=true";
        //Giriş
        public int giris_yap(string kadi, string sifre)
        {
            string sql = "select * from Uyeler where UyeKullaniciAdi='" + kadi + "' and UyeSifre='" + sifre + "'";
            SqlDataAdapter adaptorum = new SqlDataAdapter(sql, baglanti_cumlesi);
            DataTable tablom = new DataTable();
            adaptorum.Fill(tablom);

            if (tablom.Rows.Count > 0)
            {
                return Convert.ToInt32(tablom.Rows[0][0]);
            }
            return -1;
        }
        public void kaydol(string kadi, string sifresi, string adi, string soyadi, string dogum, string meslek, string egitim, string email, OpenFileDialog of)
        {

            string sql = "insert into Uyeler(UyeKullaniciAdi,UyeSifre, UyeAdi, UyeSoyadi, UyeDogumTarihi, UyeMeslek, UyeEgitim, UyeEmail,UyeMedeniDurum,UyeResim) " +
                "values('" + kadi + "','" + sifresi + "','" + adi + "','" + soyadi + "','" + dogum + "','" + meslek + "','" + egitim + "','" + email + "',1,@veri)";
            SqlConnection baglantim = new SqlConnection(baglanti_cumlesi);
            SqlCommand komutum = new SqlCommand(sql, baglantim);

            MemoryStream msResim1 = new MemoryStream();
            Image img = Image.FromFile(of.FileName);
            img.Save(msResim1, System.Drawing.Imaging.ImageFormat.Bmp);
            // Parametre olarak içeriği aktarıyorum.
            komutum.Parameters.Add("@veri", msResim1.ToArray());

            baglantim.Open();
            komutum.ExecuteNonQuery();
            MessageBox.Show("Kayit Başarılı");
            baglantim.Close();
        }
        //menustrip de gezinti
        public void formacma(Form frm, Panel pnl)
        {
            //  Menustrip de tıklama yapıldığında istenilen sayfayı açmak için
            pnl.Controls.Clear();
            frm.TopLevel = false;//bu form üst düzey bir form değildir.
            pnl.Controls.Add(frm);
            frm.Show();
            pnl.Dock = DockStyle.Fill;
            frm.WindowState = FormWindowState.Maximized;

        }
        //Anasayfa da kullanıcı resmini ve kallanıcı ad,soyadı nı getirmek için
        public void anasayfa_doldur(int uyeno, PictureBox foto, Label isim)//PROFİLDE DE KULLANILABİLİR
        {
            //ÜYE RESMİNİ,ADINI,SOYADINI DÖNDÜRÜR
            string sql = "select UyeAdi,UyeSoyadi from Uyeler where UyeId='" + uyeno + "'";
            SqlDataAdapter adaptorum = new SqlDataAdapter(sql, baglanti_cumlesi);
            DataTable tablom = new DataTable();
            adaptorum.Fill(tablom);
            Image resim = resim_getir(uyeno, 1);
            foto.Image = resim;

            string adsoyad = tablom.Rows[0][0].ToString() + " " + tablom.Rows[0][1].ToString();
            isim.Text = adsoyad;
        }
        //Üye resmini veya paylaşılan resmi getirmek için
        public Image resim_getir(int id, int tur)
        {
            string sql = null;
            if (tur == 1)
                sql = "select UyeResim from Uyeler where UyeId='" + id + "'";
            else if (tur == 2)
                sql = "select Resim from Paylasim where PaylasimId='" + id + "'";

            SqlConnection baglanti = new SqlConnection(baglanti_cumlesi);
            SqlCommand komutum = new SqlCommand(sql, baglanti);
            baglanti.Open();
            SqlDataReader veri = komutum.ExecuteReader();
            Image img = null;

            if (veri.Read())
            {
                byte[] bitlerim = (byte[])veri[0];
                MemoryStream resmim = new MemoryStream(bitlerim);
                img = Image.FromStream(resmim);
            }
            baglanti.Close();
            return img;
        }
        private string YorumSayisi(int PaylasimNo)
        {
            string sql = " select * from Yorumlar where PaylasimId='" + PaylasimNo + "'";
            SqlDataAdapter adaptorum = new SqlDataAdapter(sql, baglanti_cumlesi);
            DataTable tablom = new DataTable();
            adaptorum.Fill(tablom);
            string sonuc = "Yorumlar(" + tablom.Rows.Count.ToString() + ")";
            return sonuc;
        }

        //----------------------------------PAYLAŞIM LİSTELEME----------------------------------------------
        public void paylasim_getir(Panel pnl, int uyeno)
        {
            string sql = "select p.PaylasimId,u.UyeAdi,u.UyeSoyadi,u.UyeResim,p.Tip,p.Baslik,p.Icerik,p.Tarih,p.Saat,p.Resim,u.UyeId " +
                "from Paylasim p,Uyeler u where p.UyeId=u.UyeId and " +
                "p.GrupId  in(select g.GrupId from Gruplar g,UyeGrup ug where ug.Grup=g.GrupId and ug.UyeId='" + uyeno + "' )" +
                "order by p.Tarih desc , p.saat desc";


            SqlDataAdapter Adaptor = new SqlDataAdapter(sql, baglanti_cumlesi);
            DataTable Tablo = new DataTable();
            Adaptor.Fill(Tablo);
            int y = 15;

            for (int i = 0; i < Tablo.Rows.Count; i++)
            {
                if (Tablo.Rows[i][4].ToString() == "1")
                {
                    GroupBox GrpPaylasim = new GroupBox();
                    GrpPaylasim.Location = new Point(92, y);
                    GrpPaylasim.Size = new Size(318, 254);
                    pnl.Controls.Add(GrpPaylasim);

                    LinkLabel lbUyeAdi = new LinkLabel();
                    lbUyeAdi.Text = Tablo.Rows[i][1].ToString() + " " + Tablo.Rows[i][2].ToString();
                    lbUyeAdi.Location = new Point(63, 16);
                    lbUyeAdi.Name = Tablo.Rows[i][10].ToString();
                    lbUyeAdi.Click += new EventHandler(lbUyeAdi_Click);
                    GrpPaylasim.Controls.Add(lbUyeAdi);

                    Image UyeResmi;
                    PictureBox pbUye = new PictureBox();
                    pbUye.Location = new Point(7, 20);
                    pbUye.Size = new Size(50, 50);
                    pbUye.SizeMode = PictureBoxSizeMode.StretchImage;
                    UyeResmi = resim_getir(Convert.ToInt32(Tablo.Rows[i][10]), 1);
                    pbUye.Image = UyeResmi;
                    GrpPaylasim.Controls.Add(pbUye);

                    Label lbTarihSaat = new Label();
                    lbTarihSaat.Location = new Point(210, 20);
                    lbTarihSaat.Text = Tablo.Rows[i][7].ToString() + " " + Tablo.Rows[i][8].ToString();
                    GrpPaylasim.Controls.Add(lbTarihSaat);

                    Label lbBaslik = new Label();
                    lbBaslik.Location = new Point(60, 50);
                    lbBaslik.Text = Tablo.Rows[i][5].ToString();
                    lbBaslik.Width = 300;
                    GrpPaylasim.Controls.Add(lbBaslik);

                    RichTextBox rtxPaylasim = new RichTextBox();
                    rtxPaylasim.Location = new Point(18, 80);
                    rtxPaylasim.Size = new Size(282, 130);
                    rtxPaylasim.Text = Tablo.Rows[i][6].ToString();
                    rtxPaylasim.Enabled = false;
                    GrpPaylasim.Controls.Add(rtxPaylasim);

                    LinkLabel lbYorumlar = new LinkLabel();
                    lbYorumlar.Text = YorumSayisi(Convert.ToInt32(Tablo.Rows[i][0]));
                    lbYorumlar.Location = new Point(80, 224);
                    lbYorumlar.Name = Tablo.Rows[i][0].ToString();
                    GrpPaylasim.Controls.Add(lbYorumlar);



                    Button btnYorum = new Button();
                    btnYorum.Location = new Point(180, 219);
                    btnYorum.Size = new Size(75, 23);
                    btnYorum.Text = "Yorum Yap";
                    btnYorum.Name = Tablo.Rows[i][0].ToString();
                    GrpPaylasim.Controls.Add(btnYorum);
                    btnYorum.Click += new EventHandler(btnYorum_Click);

                    y = y + 283;

                }
                else if (Tablo.Rows[i][4].ToString() == "2")
                {
                    Image PaylasımResmi;

                    GroupBox GrpPaylasim = new GroupBox();
                    GrpPaylasim.Location = new Point(92, y);
                    GrpPaylasim.Size = new Size(318, 254);
                    pnl.Controls.Add(GrpPaylasim);

                    LinkLabel lbUyeAdi = new LinkLabel();
                    lbUyeAdi.Text = Tablo.Rows[i][1].ToString() + " " + Tablo.Rows[i][2].ToString();
                    lbUyeAdi.Location = new Point(63, 23);
                    lbUyeAdi.Name = Tablo.Rows[i][10].ToString();
                    lbUyeAdi.Click += new EventHandler(lbUyeAdi_Click);
                    GrpPaylasim.Controls.Add(lbUyeAdi);

                    Label lbTarihSaat = new Label();
                    lbTarihSaat.Location = new Point(210, 20);
                    lbTarihSaat.Text = Tablo.Rows[i][7].ToString() + " " + Tablo.Rows[i][8].ToString();
                    GrpPaylasim.Controls.Add(lbTarihSaat);

                    Label lbBaslik = new Label();
                    lbBaslik.Location = new Point(60, 50);
                    lbBaslik.Text = Tablo.Rows[i][5].ToString();
                    lbBaslik.Width = 250;
                    GrpPaylasim.Controls.Add(lbBaslik);

                    Image UyeResmi;
                    PictureBox pbUye = new PictureBox();
                    pbUye.Location = new Point(7, 20);
                    pbUye.Size = new Size(50, 50);
                    pbUye.SizeMode = PictureBoxSizeMode.StretchImage;
                    UyeResmi = resim_getir(Convert.ToInt32(Tablo.Rows[i][10]), 1);
                    pbUye.Image = UyeResmi;
                    GrpPaylasim.Controls.Add(pbUye);

                    PictureBox pbPaylasim = new PictureBox();
                    pbPaylasim.Location = new Point(92, 76);
                    pbPaylasim.Size = new Size(160, 123);
                    pbPaylasim.SizeMode = PictureBoxSizeMode.StretchImage;
                    PaylasımResmi = resim_getir(Convert.ToInt32(Tablo.Rows[i][0]), 2);
                    pbPaylasim.Image = PaylasımResmi;
                    GrpPaylasim.Controls.Add(pbPaylasim);

                    LinkLabel lbYorumlar = new LinkLabel();
                    lbYorumlar.Text = YorumSayisi(Convert.ToInt32(Tablo.Rows[i][0]));
                    lbYorumlar.Location = new Point(80, 216);
                    lbYorumlar.Name = Tablo.Rows[i][0].ToString();
                    GrpPaylasim.Controls.Add(lbYorumlar);


                    Button btnYorum = new Button();
                    btnYorum.Location = new Point(180, 211);
                    btnYorum.Size = new Size(75, 23);
                    btnYorum.Text = "Yorum Yap";
                    btnYorum.Name = Tablo.Rows[i][0].ToString();
                    GrpPaylasim.Controls.Add(btnYorum);
                    btnYorum.Click += new EventHandler(btnYorum_Click);


                    y = y + 283;

                }
                else if (Tablo.Rows[i][4].ToString() == "3")
                {
                    GroupBox GrpPaylasim = new GroupBox();
                    GrpPaylasim.Location = new Point(92, y);
                    GrpPaylasim.Size = new Size(318, 164);
                    pnl.Controls.Add(GrpPaylasim);

                    LinkLabel lbUyeAdi = new LinkLabel();
                    lbUyeAdi.Text = Tablo.Rows[i][1].ToString() + " " + Tablo.Rows[i][2].ToString();
                    lbUyeAdi.Location = new Point(63, 16);
                    lbUyeAdi.Name = Tablo.Rows[i][10].ToString();
                    lbUyeAdi.Click += new EventHandler(lbUyeAdi_Click);
                    GrpPaylasim.Controls.Add(lbUyeAdi);

                    Image UyeResmi;
                    PictureBox pbUye = new PictureBox();
                    pbUye.Location = new Point(7, 20);
                    pbUye.Size = new Size(50, 50);
                    pbUye.SizeMode = PictureBoxSizeMode.StretchImage;
                    UyeResmi = resim_getir(Convert.ToInt32(Tablo.Rows[i][10]), 1);
                    pbUye.Image = UyeResmi;
                    GrpPaylasim.Controls.Add(pbUye);

                    Label lbTarihSaat = new Label();
                    lbTarihSaat.Location = new Point(210, 20);
                    lbTarihSaat.Text = Tablo.Rows[i][7].ToString() + " " + Tablo.Rows[i][8].ToString();
                    GrpPaylasim.Controls.Add(lbTarihSaat);

                    Label lbBaslik = new Label();
                    lbBaslik.Location = new Point(60, 50);
                    lbBaslik.Text = Tablo.Rows[i][5].ToString();
                    lbBaslik.Width = 300;
                    GrpPaylasim.Controls.Add(lbBaslik);

                    LinkLabel lbPaylasim = new LinkLabel();
                    lbPaylasim.Location = new Point(6, 82);
                    lbPaylasim.Size = new Size(100, 25);
                    lbPaylasim.Text = Tablo.Rows[i][6].ToString();

                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = Tablo.Rows[i][6].ToString();
                    lbPaylasim.Links.Add(link);
                    lbPaylasim.Name = Tablo.Rows[i][0].ToString();
                    GrpPaylasim.Controls.Add(lbPaylasim);
                    lbPaylasim.Click += new EventHandler(lbPaylasim_Click);

                    Button btnYorum = new Button();
                    btnYorum.Location = new Point(180, 110);
                    btnYorum.Size = new Size(75, 23);
                    btnYorum.Text = "Yorum Yap";
                    btnYorum.Name = Tablo.Rows[i][0].ToString();
                    GrpPaylasim.Controls.Add(btnYorum);
                    btnYorum.Click += new EventHandler(btnYorum_Click);

                    LinkLabel lbYorum = new LinkLabel();
                    lbYorum.Text = YorumSayisi(Convert.ToInt32(Tablo.Rows[i][0]));
                    lbYorum.Location = new Point(80, 120);
                    lbYorum.Size = new Size(100, 25);
                    lbYorum.Name = Tablo.Rows[i][0].ToString();
                    GrpPaylasim.Controls.Add(lbYorum);


                    y = y + 170;


                }
            }
        }
        private void lbPaylasim_Click(object sender, EventArgs e)
        {
            LinkLabel lb = (sender as LinkLabel);
            lb.LinkVisited = true;
            Process.Start(lb.Text);
        
        }
        private void btnYorum_Click(object sender, EventArgs e)
        {
            Button dinamik = (sender as Button);
            sinif.PaylasimNoGonder = Convert.ToInt32(dinamik.Name);
            YorumYap yp = new YorumYap();
            yp.ShowDialog();
            //    MessageBox.Show(dinamik.Name);
        }
        public void paylasim_getir_profil(Panel pnl, int uyeno)
        {
            string sql = "select p.PaylasimId,u.UyeAdi,u.UyeSoyadi,u.UyeResim,p.Tip,p.Baslik,p.Icerik,p.Tarih,p.Saat,p.Resim,u.UyeId " +
               "from Paylasim p,Uyeler u where p.UyeId=u.UyeId and p.UyeId='" + uyeno + "'" +
                // "p.GrupId  in(select g.GrupId from Gruplar g,UyeGrup ug where ug.Grup=g.GrupId and ug.UyeId='" + uyeno + "' )" +
               "order by p.Tarih desc , p.saat desc";


            SqlDataAdapter Adaptor = new SqlDataAdapter(sql, baglanti_cumlesi);
            DataTable Tablo = new DataTable();
            Adaptor.Fill(Tablo);
            int y = 15;

            for (int i = 0; i < Tablo.Rows.Count; i++)
            {
                if (Tablo.Rows[i][4].ToString() == "1")
                {
                    GroupBox GrpPaylasim = new GroupBox();
                    GrpPaylasim.Location = new Point(92, y);
                    GrpPaylasim.Size = new Size(318, 254);
                    pnl.Controls.Add(GrpPaylasim);

                    LinkLabel lbUyeAdi = new LinkLabel();
                    lbUyeAdi.Text = Tablo.Rows[i][1].ToString() + " " + Tablo.Rows[i][2].ToString();
                    lbUyeAdi.Location = new Point(63, 16);

                    GrpPaylasim.Controls.Add(lbUyeAdi);

                    Image UyeResmi;
                    PictureBox pbUye = new PictureBox();
                    pbUye.Location = new Point(7, 20);
                    pbUye.Size = new Size(50, 50);
                    pbUye.SizeMode = PictureBoxSizeMode.StretchImage;
                    UyeResmi = resim_getir(Convert.ToInt32(Tablo.Rows[i][10]), 1);
                    pbUye.Image = UyeResmi;
                    GrpPaylasim.Controls.Add(pbUye);

                    Label lbTarihSaat = new Label();
                    lbTarihSaat.Location = new Point(210, 20);
                    lbTarihSaat.Text = Tablo.Rows[i][7].ToString() + " " + Tablo.Rows[i][8].ToString();
                    GrpPaylasim.Controls.Add(lbTarihSaat);

                    Label lbBaslik = new Label();
                    lbBaslik.Location = new Point(60, 50);
                    lbBaslik.Text = Tablo.Rows[i][5].ToString();
                    lbBaslik.Width = 300;
                    GrpPaylasim.Controls.Add(lbBaslik);

                    RichTextBox rtxPaylasim = new RichTextBox();
                    rtxPaylasim.Location = new Point(18, 80);
                    rtxPaylasim.Size = new Size(282, 130);
                    rtxPaylasim.Text = Tablo.Rows[i][6].ToString();
                    rtxPaylasim.Enabled = false;
                    GrpPaylasim.Controls.Add(rtxPaylasim);

                    LinkLabel lbYorumlar = new LinkLabel();
                    lbYorumlar.Text = YorumSayisi(Convert.ToInt32(Tablo.Rows[i][0]));
                    lbYorumlar.Location = new Point(80, 224);
                    lbYorumlar.Name = Tablo.Rows[i][0].ToString();
                    GrpPaylasim.Controls.Add(lbYorumlar);



                    Button btnYorum = new Button();
                    btnYorum.Location = new Point(180, 219);
                    btnYorum.Size = new Size(75, 23);
                    btnYorum.Text = "Yorum Yap";
                    btnYorum.Name = Tablo.Rows[i][0].ToString();
                    GrpPaylasim.Controls.Add(btnYorum);
                    btnYorum.Click += new EventHandler(btnYorum_Click);

                    y = y + 283;

                }
                else if (Tablo.Rows[i][4].ToString() == "2")
                {
                    Image PaylasımResmi;

                    GroupBox GrpPaylasim = new GroupBox();
                    GrpPaylasim.Location = new Point(92, y);
                    GrpPaylasim.Size = new Size(318, 254);
                    pnl.Controls.Add(GrpPaylasim);

                    LinkLabel lbUyeAdi = new LinkLabel();
                    lbUyeAdi.Text = Tablo.Rows[i][1].ToString() + " " + Tablo.Rows[i][2].ToString();
                    lbUyeAdi.Location = new Point(63, 23);

                    GrpPaylasim.Controls.Add(lbUyeAdi);

                    Label lbTarihSaat = new Label();
                    lbTarihSaat.Location = new Point(210, 20);
                    lbTarihSaat.Text = Tablo.Rows[i][7].ToString() + " " + Tablo.Rows[i][8].ToString();
                    GrpPaylasim.Controls.Add(lbTarihSaat);

                    Label lbBaslik = new Label();
                    lbBaslik.Location = new Point(60, 50);
                    lbBaslik.Text = Tablo.Rows[i][5].ToString();
                    lbBaslik.Width = 250;
                    GrpPaylasim.Controls.Add(lbBaslik);

                    Image UyeResmi;
                    PictureBox pbUye = new PictureBox();
                    pbUye.Location = new Point(7, 20);
                    pbUye.Size = new Size(50, 50);
                    pbUye.SizeMode = PictureBoxSizeMode.StretchImage;
                    UyeResmi = resim_getir(Convert.ToInt32(Tablo.Rows[i][10]), 1);
                    pbUye.Image = UyeResmi;
                    GrpPaylasim.Controls.Add(pbUye);

                    PictureBox pbPaylasim = new PictureBox();
                    pbPaylasim.Location = new Point(92, 76);
                    pbPaylasim.Size = new Size(160, 123);
                    pbPaylasim.SizeMode = PictureBoxSizeMode.StretchImage;
                    PaylasımResmi = resim_getir(Convert.ToInt32(Tablo.Rows[i][0]), 2);
                    pbPaylasim.Image = PaylasımResmi;
                    GrpPaylasim.Controls.Add(pbPaylasim);

                    LinkLabel lbYorumlar = new LinkLabel();
                    lbYorumlar.Text = YorumSayisi(Convert.ToInt32(Tablo.Rows[i][0]));
                    lbYorumlar.Location = new Point(80, 216);
                    lbYorumlar.Name = Tablo.Rows[i][0].ToString();
                    GrpPaylasim.Controls.Add(lbYorumlar);


                    Button btnYorum = new Button();
                    btnYorum.Location = new Point(180, 211);
                    btnYorum.Size = new Size(75, 23);
                    btnYorum.Text = "Yorum Yap";
                    btnYorum.Name = Tablo.Rows[i][0].ToString();
                    GrpPaylasim.Controls.Add(btnYorum);
                    btnYorum.Click += new EventHandler(btnYorum_Click);


                    y = y + 283;

                }
                else if (Tablo.Rows[i][4].ToString() == "3")
                {
                    GroupBox GrpPaylasim = new GroupBox();
                    GrpPaylasim.Location = new Point(92, y);
                    GrpPaylasim.Size = new Size(318, 164);
                    pnl.Controls.Add(GrpPaylasim);

                    LinkLabel lbUyeAdi = new LinkLabel();
                    lbUyeAdi.Text = Tablo.Rows[i][1].ToString() + " " + Tablo.Rows[i][2].ToString();
                    lbUyeAdi.Location = new Point(63, 16);
                    lbUyeAdi.Name = Tablo.Rows[i][10].ToString();
                    lbUyeAdi.Click += new EventHandler(lbUyeAdi_Click);
                    GrpPaylasim.Controls.Add(lbUyeAdi);

                    Image UyeResmi;
                    PictureBox pbUye = new PictureBox();
                    pbUye.Location = new Point(7, 20);
                    pbUye.Size = new Size(50, 50);
                    pbUye.SizeMode = PictureBoxSizeMode.StretchImage;
                    UyeResmi = resim_getir(Convert.ToInt32(Tablo.Rows[i][10]), 1);
                    pbUye.Image = UyeResmi;
                    GrpPaylasim.Controls.Add(pbUye);

                    Label lbTarihSaat = new Label();
                    lbTarihSaat.Location = new Point(210, 20);
                    lbTarihSaat.Text = Tablo.Rows[i][7].ToString() + " " + Tablo.Rows[i][8].ToString();
                    GrpPaylasim.Controls.Add(lbTarihSaat);

                    Label lbBaslik = new Label();
                    lbBaslik.Location = new Point(60, 50);
                    lbBaslik.Text = Tablo.Rows[i][5].ToString();
                    lbBaslik.Width = 300;
                    GrpPaylasim.Controls.Add(lbBaslik);

                    LinkLabel lbPaylasim = new LinkLabel();
                    lbPaylasim.Location = new Point(6, 82);
                    lbPaylasim.Size = new Size(100, 25);
                    lbPaylasim.Text = Tablo.Rows[i][6].ToString();

                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = Tablo.Rows[i][6].ToString();
                    lbPaylasim.Links.Add(link);
                    lbPaylasim.Name = Tablo.Rows[i][0].ToString();
                    GrpPaylasim.Controls.Add(lbPaylasim);
                    lbPaylasim.Click += new EventHandler(lbPaylasim_Click);

                    Button btnYorum = new Button();
                    btnYorum.Location = new Point(180, 110);
                    btnYorum.Size = new Size(75, 23);
                    btnYorum.Text = "Yorum Yap";
                    btnYorum.Name = Tablo.Rows[i][0].ToString();
                    GrpPaylasim.Controls.Add(btnYorum);
                    btnYorum.Click += new EventHandler(btnYorum_Click);

                    LinkLabel lbYorum = new LinkLabel();
                    lbYorum.Text = YorumSayisi(Convert.ToInt32(Tablo.Rows[i][0]));
                    lbYorum.Location = new Point(80, 120);
                    lbYorum.Size = new Size(100, 25);
                    lbYorum.Name = Tablo.Rows[i][0].ToString();
                    GrpPaylasim.Controls.Add(lbYorum);


                    y = y + 170;


                }
            }
        }
        private void lbUyeAdi_Click(object sender, EventArgs e)
        {
            LinkLabel lbl = (sender as LinkLabel);
            sinif.ArkadasNo = Convert.ToInt32(lbl.Name);
            if (ArkadasNo != Form_Giris.uyenogonder)
            {
                Form_ArkadasProfil arkadasp = new Form_ArkadasProfil();
                formacma(arkadasp, Form1.panelim);
            }
            else
            {
                Profil p = new Profil();
                formacma(p, Form1.panelim);
            }
        }
        //Yorumyap butonu tıklandığında açılacak olan formun load olayı için
        public void YorumGösterForm(Panel Panel, int UyeNo, int PaylasimId)
        {
            string YorumGösterForm_SqlCumlesi = "select u.UyeAdi,u.UyeSoyadi,u.UyeResim,y.Yorum,y.Tarih,y.Saat,y.UyeId  from Uyeler u,Paylasim p,Yorumlar y where p.PaylasimId=y.PaylasimId and u.UyeId=y.UyeId and y.PaylasimId='" + PaylasimId + "'";

            SqlDataAdapter YorumGösterForm_Adaptor = new SqlDataAdapter(YorumGösterForm_SqlCumlesi, baglanti_cumlesi);
            DataTable YorumGösterForm_Tablo = new DataTable();
            YorumGösterForm_Adaptor.Fill(YorumGösterForm_Tablo);

            int y = 9;
            for (int i = 0; i < YorumGösterForm_Tablo.Rows.Count; i++)
            {
                GroupBox GrpYorum = new GroupBox();
                GrpYorum.Location = new Point(0, y);
                GrpYorum.Size = new Size(300, 125);
                Panel.Controls.Add(GrpYorum);

                LinkLabel lbUyeAdi = new LinkLabel();
                lbUyeAdi.Text = YorumGösterForm_Tablo.Rows[i][0].ToString() + " " + YorumGösterForm_Tablo.Rows[i][1].ToString();
                lbUyeAdi.Location = new Point(100, 25);
                GrpYorum.Controls.Add(lbUyeAdi);

                Image UyeResmi;
                PictureBox pbUye = new PictureBox();
                pbUye.Location = new Point(7, 20);
                pbUye.Size = new Size(50, 50);
                pbUye.SizeMode = PictureBoxSizeMode.StretchImage;
                UyeResmi = resim_getir(Convert.ToInt32(YorumGösterForm_Tablo.Rows[i][6]), 1);
                pbUye.Image = UyeResmi;
                GrpYorum.Controls.Add(pbUye);

                Label lbTarihSaat = new Label();
                lbTarihSaat.Location = new Point(65, 48);
                lbTarihSaat.Text = YorumGösterForm_Tablo.Rows[i][4].ToString() + " " + YorumGösterForm_Tablo.Rows[i][5].ToString();
                GrpYorum.Controls.Add(lbTarihSaat);

                RichTextBox rtxPaylasim = new RichTextBox();
                rtxPaylasim.Location = new Point(7, 76);
                rtxPaylasim.Size = new Size(298, 43);
                rtxPaylasim.Text = YorumGösterForm_Tablo.Rows[i][3].ToString();
                rtxPaylasim.Enabled = false;
                GrpYorum.Controls.Add(rtxPaylasim);

                Button btnYorumYap = new Button();
                btnYorumYap.Location = new Point(180, 219);
                btnYorumYap.Size = new Size(75, 23);
                btnYorumYap.Text = "yorum yap";
                btnYorumYap.Name = YorumGösterForm_Tablo.Rows[i][0].ToString();
                GrpYorum.Controls.Add(btnYorumYap);
                btnYorumYap.Click += new EventHandler(btnYorum_Click);

                y = y + 131;
            }
        }
        //üstdeki formun içinde olan yorum yap butonu içindekiler
        public void YorumEkle(int uyeno, int paylasimno, string yorum, string tarih, string saat)
        {
            string YorumEkle_SqlCumlesi = "insert into Yorumlar (UyeId,PaylasimId,Yorum,Tarih,Saat) " +
                "values('" + uyeno + "','" + paylasimno + "','" + yorum + "','" + tarih + "','" + saat + "')";
            SqlConnection YorumEkle_Baglanti = new SqlConnection(baglanti_cumlesi);
            SqlCommand YorumEkle_Komut = new SqlCommand(YorumEkle_SqlCumlesi, YorumEkle_Baglanti);
            YorumEkle_Baglanti.Open();
            YorumEkle_Komut.ExecuteNonQuery();
            MessageBox.Show("Yorum Eklendi");
            YorumEkle_Baglanti.Close();
        }
        //combo box ı üyenin gruplarıyla doldurmak
        public void ComboboxDoldur(ComboBox cb)
        {
            string ComboboxDoldur_SqlCumlesi = "select g.GrupId,g.GrupAdi from Gruplar g,Uyeler u where u.UyeId=g.UyeId and g.UyeId='" + Form_Giris.uyenogonder + "'";
            SqlDataAdapter ComboboxDoldur_Adaptor = new SqlDataAdapter(ComboboxDoldur_SqlCumlesi, baglanti_cumlesi);
            DataTable ComboboxDoldur_Tablo = new DataTable();
            ComboboxDoldur_Adaptor.Fill(ComboboxDoldur_Tablo);
            cb.DataSource = ComboboxDoldur_Tablo;
            cb.DisplayMember = ComboboxDoldur_Tablo.Columns[1].ColumnName;
            cb.ValueMember = ComboboxDoldur_Tablo.Columns[0].ColumnName;
        }
        //Resim paylaşırken FileDialog da seçilen resmi göstermek için
        public void ResimGetir(OpenFileDialog ofd, PictureBox pbx)
        {
            DialogResult cevap = ofd.ShowDialog();
            if (cevap == DialogResult.OK)
            {
                // OpenDialog nesnemle açtığım resmi PictureBox nesneme yerleştiriyorum.
                pbx.Image = Image.FromFile(ofd.FileName);
            }
            else
            {
                MessageBox.Show("Dosya Seçilmedi :)");
            }
        }
        public DataTable UyeProfilBilgileriGetir(int uyeıd)
        {
            string sql = "select u.UyeEmail,u.UyeMeslek,u.UyeOkul,u.UyeDogumTarihi,i.IliskiAdi from Uyeler u,Iliskiler i where u.UyeMedeniDurum=i.IliskiNo and u.UyeId="+uyeıd+"";


            SqlDataAdapter adap = new SqlDataAdapter(sql, baglanti_cumlesi);
            DataTable tab = new DataTable();

            adap.Fill(tab);
            return tab;
        
        }
        //--------------------------------PAYLAŞIMLAR-----------------------------------------------------
        public void ResimPaylas(OpenFileDialog ofd, string baslik, int grupid, string tarih, string saat)
        {
            // Öncelikle MemoryStream Sınıfını kullanarak, değişken oluşturuyoruz.
            // Ardından Image sınıfından bir değişken oluşturuyorum.
            MemoryStream msResim1 = new MemoryStream();
            Image img = Image.FromFile(ofd.FileName);
            img.Save(msResim1, System.Drawing.Imaging.ImageFormat.Bmp);
            // Parametre olarak içeriği aktarıyorum.
            SqlParameter parametrem = new SqlParameter("@veri", msResim1.ToArray());
            // Sql Sorgumu Yazıyorum.
            SqlConnection baglanti = new SqlConnection(baglanti_cumlesi);
            SqlCommand komutum = new SqlCommand("Insert Into Paylasim(Baslik, UyeId, GrupId, Tip, Tarih, Saat, Resim) Values('" + baslik + "','" + Form_Giris.uyenogonder + "','" + grupid + "','2','" + tarih + "','" + saat + "',@veri)", baglanti);
            // SqlCommand nesneme parametrelerin neler olduğunu gösteriyorum.
            komutum.Parameters.Add(parametrem);

            try
            {
                // Bağlantımı Açıyorum ve Çalıştırıyorum.
                komutum.Connection.Open();
                komutum.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarıyla Gerçekleşti");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                komutum.Connection.Close();
            }
        }
        public void MetinPaylas(string baslik, string metin, int grupid, string tarih, string saat)
        {
            string sql = "insert into Paylasim(Baslik,Icerik,UyeId,GrupId,Tip,Tarih,Saat) values('" + baslik + "','" + metin + "','" + Form_Giris.uyenogonder + "','" + grupid + "','1','" + tarih + "','" + saat + "')";

            SqlConnection baglanti = new SqlConnection(baglanti_cumlesi);
            SqlCommand komut = new SqlCommand(sql, baglanti);

            baglanti.Open();
            komut.ExecuteNonQuery();
            MessageBox.Show("Paylaşıldı Tebrikler İyi Halt Ettiniz.!");
            baglanti.Close();
        }
        public void LinkPaylas(string baslik, string link, int grupid, string tarih, string saat)
        {
            string sql = "insert into Paylasim(Baslik,Icerik,UyeId,GrupId,Tip,Tarih,Saat) " +
                         "values('" + baslik + "','" + link + "','" + Form_Giris.uyenogonder + "','" + grupid + "','3','" + tarih + "','" + saat + "')";
            SqlConnection baglanti = new SqlConnection(baglanti_cumlesi);
            SqlCommand komut = new SqlCommand(sql, baglanti);

            baglanti.Open();
            komut.ExecuteNonQuery();
            MessageBox.Show("Link Paylaşıldı!");
            baglanti.Close();
        }
        //----------------------------------ARKADAŞLAR---------------------------------------------------
        public void ArkadasGetir(Panel pnl, int uyeno)
        {
            Profil pr = new Profil();
            pnl.Controls.Clear();
            string sql = "select u.UyeId,u.UyeAdi,u.UyeSoyadi from Arkadaslar a,Uyeler u where a.Durum='1' and a.Kimin=u.UyeId and a.Kim='" + uyeno + "'";
            SqlDataAdapter Adaptorum = new SqlDataAdapter(sql, baglanti_cumlesi);
            DataTable Tablom = new DataTable();
            Adaptorum.Fill(Tablom);
            int y = 4;

            for (int i = 0; i < Tablom.Rows.Count; i++)
            {
                GroupBox GrpPaylasim = new GroupBox();
                GrpPaylasim.Location = new Point(4, y);
                GrpPaylasim.Size = new Size(173, 74);
                pnl.Controls.Add(GrpPaylasim);

                Image UyeResmi;
                PictureBox pbUye = new PictureBox();
                pbUye.Location = new Point(7, 20);
                pbUye.Size = new Size(52, 45);
                pbUye.SizeMode = PictureBoxSizeMode.StretchImage;
                UyeResmi = resim_getir(Convert.ToInt32(Tablom.Rows[i][0]), 1);
                pbUye.Image = UyeResmi;
                pbUye.Name = Tablom.Rows[i][0].ToString();
                pbUye.Click += new EventHandler(pbUye_Click);
                GrpPaylasim.Controls.Add(pbUye);

                Label lbAd = new Label();
                lbAd.Location = new Point(66, 25);
                lbAd.Text = Tablom.Rows[i][1].ToString();
                lbAd.Width = 100;
                GrpPaylasim.Controls.Add(lbAd);

                Label lbSoyad = new Label();
                lbSoyad.Location = new Point(66, 48);
                lbSoyad.Text = Tablom.Rows[i][2].ToString();
                lbSoyad.Width = 100;
                GrpPaylasim.Controls.Add(lbSoyad);


                y = y + 70;
            }

        }
        private void pbUye_Click(object sender, EventArgs e)
        {
            Profil prf = new Profil();
            PictureBox pb = (sender as PictureBox);
            sinif.ArkadasNo = Convert.ToInt32(pb.Name);
            //arkadaşının arkadaşlarından kendine tıkladığında profilini açmak için
            if (ArkadasNo != Form_Giris.uyenogonder)
            {
                Form_ArkadasProfil farkadas = new Form_ArkadasProfil();
                formacma(farkadas, Form1.panelim);
            }
            else
                formacma(prf, Form1.panelim);
        }
        public DataTable ArkadasDurum()
        {
            string sql;
            Form_ArkadasProfil ap = new Form_ArkadasProfil();
            sql = "select Durum from Arkadaslar where Kim='" + Form_Giris.uyenogonder + "' and Kimin='" + ArkadasNo + "'";
            SqlDataAdapter adap = new SqlDataAdapter(sql, baglanti_cumlesi);
            DataTable tab = new DataTable();
            adap.Fill(tab);
            return tab;
        }
        public void ArkadasArama(Panel pnl)
        {
            string sql = "select UyeId,UyeAdi+' '+UyeSoyadi as AdıSoyadi,UyeResim from Uyeler where UyeAdi+' '+UyeSoyadi like '%" + Form_Anasayfa.Aranan + "%'";
            SqlDataAdapter adaptor = new SqlDataAdapter(sql, baglanti_cumlesi);
            DataTable tablo = new DataTable();
            adaptor.Fill(tablo);
            int y = 12;
            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                GroupBox GrpPaylasim = new GroupBox();
                GrpPaylasim.Location = new Point(14, y);
                GrpPaylasim.Size = new Size(492, 83);
                pnl.Controls.Add(GrpPaylasim);

                LinkLabel lbarkadas_arama = new LinkLabel();
                lbarkadas_arama.Text = tablo.Rows[i][1].ToString();
                lbarkadas_arama.Location = new Point(78, 38);
                lbarkadas_arama.Size = new Size(100, 25);
                lbarkadas_arama.Name = tablo.Rows[i][0].ToString();
                GrpPaylasim.Controls.Add(lbarkadas_arama);
                lbarkadas_arama.Click += new EventHandler(lbarkadas_arama_Click);


                Image UyeResmi;
                PictureBox pbUye = new PictureBox();
                pbUye.Location = new Point(7, 20);
                pbUye.Size = new Size(64, 57);
                pbUye.SizeMode = PictureBoxSizeMode.StretchImage;
                UyeResmi = resim_getir(Convert.ToInt32(tablo.Rows[i][0]), 1);
                pbUye.Image = UyeResmi;
                GrpPaylasim.Controls.Add(pbUye);
                y = y + 88;
            }

        }
        private void lbarkadas_arama_Click(object sender, EventArgs e)
        {
            Form_AramaSonuclari a = new Form_AramaSonuclari();
            a.Close();
            Form_ArkadasProfil fap = new Form_ArkadasProfil();

            LinkLabel lb = (sender as LinkLabel);
            ArkadasNo = Convert.ToInt32(lb.Name);
            formacma(fap, Form1.panelim);
        }

        public void ArkadasIstekleri(Panel pnl)
        {
            // pnl.Controls.Clear();
            string sql = "select u.UyeId,u.UyeAdi+' '+u.UyeSoyadi,a.Kim  from Arkadaslar a,Uyeler u where Kimin=" + Form_Giris.uyenogonder + " and Durum=3 and a.Kim=u.UyeId";
            SqlDataAdapter adaptor = new SqlDataAdapter(sql, baglanti_cumlesi);
            DataTable tablo = new DataTable();
            adaptor.Fill(tablo);
            int y = 12;
            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                GroupBox GrpPaylasim = new GroupBox();
                GrpPaylasim.Location = new Point(14, y);
                GrpPaylasim.Size = new Size(492, 83);
                pnl.Controls.Add(GrpPaylasim);

                LinkLabel lb1 = new LinkLabel();
                lb1.Text = tablo.Rows[i][1].ToString();
                lb1.Location = new Point(78, 38);
                lb1.Size = new Size(100, 25);
                lb1.Name = tablo.Rows[i][1].ToString();
                GrpPaylasim.Controls.Add(lb1);
                lb1.Click += new EventHandler(lbarkadas_arama_Click);


                Image UyeResmi;
                PictureBox pbUye = new PictureBox();
                pbUye.Location = new Point(7, 20);
                pbUye.Size = new Size(64, 57);
                pbUye.SizeMode = PictureBoxSizeMode.StretchImage;
                UyeResmi = resim_getir(Convert.ToInt32(tablo.Rows[i][0]), 1);
                pbUye.Image = UyeResmi;
                GrpPaylasim.Controls.Add(pbUye);
                y = y + 88;

                Button btnKabul = new Button();
                btnKabul.Location = new Point(314, 19);
                btnKabul.Size = new Size(86, 43);
                btnKabul.Text = "Kabul";
                btnKabul.Name = tablo.Rows[i][2].ToString();
                GrpPaylasim.Controls.Add(btnKabul);
                btnKabul.Click += new EventHandler(btnKabul_Click);

                Button btnRed = new Button();
                btnRed.Location = new Point(400, 19);
                btnRed.Size = new Size(86, 43);
                btnRed.Text = "Red";
                btnRed.Name = tablo.Rows[i][2].ToString();
                GrpPaylasim.Controls.Add(btnRed);
                btnRed.Click += new EventHandler(btnRed_Click);
            }
        }
        private void btnKabul_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            ArkadasNo = Convert.ToInt32(btn.Name);

            string sql;
            sql = "update Arkadaslar set Durum=1 where Kim=" + ArkadasNo + " and Kimin=" + Form_Giris.uyenogonder + "";
            SqlConnection bag = new SqlConnection(baglanti_cumlesi);
            SqlCommand komut = new SqlCommand(sql, bag);

            bag.Open();
            komut.ExecuteNonQuery();
            MessageBox.Show("Arkadaş Eklendi LO");
            bag.Close();
            Form_ArkadasIstekleri.panel.Controls.Clear();
            ArkadasIstekleri(Form_ArkadasIstekleri.panel);
        }
        private void btnRed_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            ArkadasNo = Convert.ToInt32(btn.Name);

            string sql;
            sql = "delete from Arkadaslar where Kim=" + ArkadasNo + " and Kimin=" + Form_Giris.uyenogonder + "";
            SqlConnection bag = new SqlConnection(baglanti_cumlesi);
            SqlCommand komut = new SqlCommand(sql, bag);

            bag.Open();
            komut.ExecuteNonQuery();
            MessageBox.Show("Arkadaş Silindi");
            bag.Close();
            Form_ArkadasIstekleri.panel.Controls.Clear();
            ArkadasIstekleri(Form_ArkadasIstekleri.panel);
        }

        public void Arkadasekle()
        {
            string sql;
            sql = "insert into Arkadaslar(Kim,Kimin,Durum) values(" + Form_Giris.uyenogonder + "," + ArkadasNo + ",3) ";

            SqlConnection bag = new SqlConnection(baglanti_cumlesi);
            SqlCommand kom = new SqlCommand(sql, bag);
            bag.Open();
            kom.ExecuteNonQuery();
            MessageBox.Show("Arkadaşlık İstegi Gönderildi.");
            bag.Close();

        }
        public void Arkadassilme()
        {
            string sql;

            sql = "delete from Arkadaslar where Kim=" + Form_Giris.uyenogonder + " and Kimin=" + ArkadasNo + "  ";
            SqlConnection bag = new SqlConnection(baglanti_cumlesi);
            SqlCommand kom = new SqlCommand(sql, bag);
            bag.Open();
            kom.ExecuteNonQuery();
            MessageBox.Show("Arkadaşlık Silindi.");
            bag.Close();
        }
        public void Arkadasıptal()
        {
            string sql;

            sql = "delete from Arkadaslar where Kim=" + Form_Giris.uyenogonder + " and Kimin=" + ArkadasNo + " and Durum=3 ";
            SqlConnection bag = new SqlConnection(baglanti_cumlesi);
            SqlCommand kom = new SqlCommand(sql, bag);
            bag.Open();
            kom.ExecuteNonQuery();
            MessageBox.Show("Arkadaşlık İsteği İptal Edildi.");
            bag.Close();
        }
        //--------------------------------MESAJLAR-------------------------------------------------------

        //mesaj gönderme
        public void MesajYaz(string mesaj)
        {
            string sql;
            sql = "insert into Mesajlar(Mesaj,Kimden,Kime,Tarih,Saat) values('" + mesaj + "'," + Form_Giris.uyenogonder + "," + ArkadasNo + ",'" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "') ";
            SqlConnection bag = new SqlConnection(baglanti_cumlesi);
            SqlCommand kom = new SqlCommand(sql, bag);

            bag.Open();
            kom.ExecuteNonQuery();
            MessageBox.Show("Mesaj Gönderildi");
            bag.Close();
        }
        //mesaj formunda arkadaşları listelemek için
        public void ArkadaşlarıGetirMesaj(Panel pnl)
        {
            Profil pr = new Profil();
            pnl.Controls.Clear();
            string sql = "select a.Kimin,u.UyeAdi,u.UyeSoyadi from Arkadaslar a,Uyeler u where u.UyeId=a.Kimin and a.Durum=1 and Kim=" + Form_Giris.uyenogonder + "";
            SqlDataAdapter Adaptorum = new SqlDataAdapter(sql, baglanti_cumlesi);
            DataTable Tablom = new DataTable();
            Adaptorum.Fill(Tablom);
            int y = 4;

            for (int i = 0; i < Tablom.Rows.Count; i++)
            {
                GroupBox GrpPaylasim = new GroupBox();
                GrpPaylasim.Location = new Point(4, y);
                GrpPaylasim.Size = new Size(173, 74);
                pnl.Controls.Add(GrpPaylasim);

                Image UyeResmi;
                PictureBox pbUyeMesaj = new PictureBox();
                pbUyeMesaj.Location = new Point(7, 20);
                pbUyeMesaj.Size = new Size(52, 45);
                pbUyeMesaj.SizeMode = PictureBoxSizeMode.StretchImage;
                UyeResmi = resim_getir(Convert.ToInt32(Tablom.Rows[i][0]), 1);
                pbUyeMesaj.Image = UyeResmi;
                pbUyeMesaj.Name = Tablom.Rows[i][0].ToString();
                pbUyeMesaj.Click += new EventHandler(pbUyeMesaj_Click);
                GrpPaylasim.Controls.Add(pbUyeMesaj);

                Label lbAd = new Label();
                lbAd.Location = new Point(66, 25);
                lbAd.Text = Tablom.Rows[i][1].ToString() + " " + Tablom.Rows[i][2].ToString();
                lbAd.Width = 100;
                GrpPaylasim.Controls.Add(lbAd);


                y = y + 70;
            }



        }
        //Mesajlar sayfasında arkadaş üzerine tıklandığında arkadaş noyu almak için
        private void pbUyeMesaj_Click(object sender, EventArgs e)
        {
            PictureBox pbUyeMesaj_Click = (sender as PictureBox);
            ArkadasNo = Convert.ToInt32(pbUyeMesaj_Click.Name);
            Form_Mesaj.pnlsohbetstk.Controls.Clear();
            Mesajlari_Listele(Form_Mesaj.pnlsohbetstk, ArkadasNo);
            Form_Mesaj.rtcevap.Enabled = true;
        }
        //mesajları listelemek için
        public void Mesajlari_Listele(Panel pnl, int arkadasno)
        {
            string sql = "select m.Mesaj,u.UyeAdi,u.UyeSoyadi,m.Kimden,m.Tarih+' '+m.Saat from Mesajlar m, Uyeler u " +
            "where ((m.Kimden=u.UyeId) and ((m.Kimden=" + arkadasno + " and m.Kime=" + Form_Giris.uyenogonder + ") or " +
                                           "(m.Kimden=" + Form_Giris.uyenogonder + " and m.Kime=" + arkadasno + "))) " +
            "order by Tarih desc, Saat desc";
            SqlDataAdapter Adaptorum = new SqlDataAdapter(sql, baglanti_cumlesi);
            DataTable Tablom = new DataTable();
            Adaptorum.Fill(Tablom);
            int y = 4;

            for (int i = 0; i < Tablom.Rows.Count; i++)
            {
                GroupBox GrpMesajlar = new GroupBox();
                GrpMesajlar.Location = new Point(4, y);
                GrpMesajlar.Size = new Size(427, 114);
                pnl.Controls.Add(GrpMesajlar);

                Image UyeResmi;
                PictureBox pbmsj = new PictureBox();
                pbmsj.Location = new Point(6, 19);
                pbmsj.Size = new Size(40, 40);
                pbmsj.SizeMode = PictureBoxSizeMode.StretchImage;
                UyeResmi = resim_getir(Convert.ToInt32(Tablom.Rows[i][3]), 1);
                pbmsj.Image = UyeResmi;
                GrpMesajlar.Controls.Add(pbmsj);

                Label lbAd = new Label();
                lbAd.Location = new Point(9, 89);
                lbAd.Size = new Size(35, 15);
                lbAd.Text = Tablom.Rows[i][1].ToString() + " " + Tablom.Rows[i][2].ToString();
                lbAd.Width = 100;
                GrpMesajlar.Controls.Add(lbAd);

                Label lbTarih = new Label();
                lbTarih.Location = new Point(300, 89);
                lbTarih.Size = new Size(35, 15);
                lbTarih.Text = Tablom.Rows[i][4].ToString();
                lbTarih.Width = 100;
                GrpMesajlar.Controls.Add(lbTarih);

                RichTextBox rtb = new RichTextBox();
                rtb.Size = new Size(365, 60);
                rtb.Location = new Point(52, 19);
                rtb.Text = Tablom.Rows[i][0].ToString();
                rtb.Enabled = false;
                GrpMesajlar.Controls.Add(rtb);


                y = y + 150;
            }
        }

        //------------------------HESAP AYARLARI---------------------------------------------------------
        public void KullaniciAdiDegistir(string metin, int uyeno)
        {
            string sql;
            sql = "update Uyeler set UyeKullaniciAdi='" + metin + "' where UyeId=" + uyeno + "  ";
            SqlConnection bag = new SqlConnection(baglanti_cumlesi);
            SqlCommand kom = new SqlCommand(sql, bag);

            bag.Open();
            kom.ExecuteNonQuery();
            MessageBox.Show("Kullanıcı Adınız Değiştirildi.");
            bag.Close();
        }
        public void SifreDegistir(string yenisifre, int uyeno)
        {
            string sql;

            sql = "update Uyeler set UyeSifre='" + yenisifre + "' where UyeId=" + uyeno + "";
            SqlConnection bag = new SqlConnection(baglanti_cumlesi);
            SqlCommand kom = new SqlCommand(sql, bag);

            bag.Open();
            kom.ExecuteNonQuery();
            MessageBox.Show("Şifreniz  Değiştirildi.");
            bag.Close();
        }
        public void ResimDegistir(OpenFileDialog op, PictureBox pb)
        {
            string sql = "update Uyeler set UyeResim=@veri where UyeId='" + Form_Giris.uyenogonder + "'";
            SqlConnection baglantim = new SqlConnection(baglanti_cumlesi);
            SqlCommand komutum = new SqlCommand(sql, baglantim);

            MemoryStream msResim1 = new MemoryStream();
            Image img = Image.FromFile(op.FileName);

            img.Save(msResim1, System.Drawing.Imaging.ImageFormat.Bmp);

            // Parametre olarak içeriği aktarıyorum.
           komutum.Parameters.Add("@veri", msResim1.ToArray());


            baglantim.Open();
            komutum.ExecuteNonQuery();
            MessageBox.Show("Kayit Başarılı");
            baglantim.Close();


        }
        public void BilgileriDegistir(string egitim, string okul, string meslek, int uyeno,int iliskino)
        {
            string sql;
            sql = "update Uyeler Set UyeEgitim='" + egitim + "',UyeMedeniDurum="+iliskino+",UyeOkul='" + okul + "',UyeMeslek='" + meslek + "' where UyeId='" + Form_Giris.uyenogonder + "'";
            SqlConnection bag = new SqlConnection(baglanti_cumlesi);
            SqlCommand kom = new SqlCommand(sql, bag);
            bag.Open();
            kom.ExecuteNonQuery();
            MessageBox.Show("Bilgileriniz Güncellendi.");
            bag.Close();


        }
        public void MedeniDurumGetir(ComboBox cb)
        {

            string ComboboxDoldur_SqlCumlesi = "select u.UyeMedeniDurum,i.IliskiAdi from Uyeler u,Iliskiler i where u.UyeMedeniDurum=i.İliskiNo and u.UyeId='" + Form_Giris.uyenogonder + "'";
            SqlDataAdapter ComboboxDoldur_Adaptor = new SqlDataAdapter(ComboboxDoldur_SqlCumlesi, baglanti_cumlesi);
            DataTable ComboboxDoldur_Tablo = new DataTable();
            ComboboxDoldur_Adaptor.Fill(ComboboxDoldur_Tablo);
            cb.DataSource = ComboboxDoldur_Tablo;
            cb.DisplayMember = ComboboxDoldur_Tablo.Columns[1].ColumnName;
            cb.ValueMember = ComboboxDoldur_Tablo.Columns[0].ColumnName;
        }
        public void GrupAyarlarıGrupListele(ListBox lb)
        {
            string sql = "select GrupId,GrupAdi from Gruplar where UyeId='" + Form_Giris.uyenogonder + "'";

            SqlDataAdapter adap = new SqlDataAdapter(sql, baglanti_cumlesi);
            DataTable tablo = new DataTable();

            adap.Fill(tablo);
            tablo.Rows[0].Delete();
            lb.DataSource = tablo;
            lb.DisplayMember = tablo.Columns[1].ColumnName;
            lb.ValueMember = tablo.Columns[0].ColumnName;

        }
        public void GrupArkadasListele(ListBox lb, int grupid)
        {
            string sql = "select u.UyeId,u.UyeAdi+' '+u.UyeSoyadi from UyeGrup ug,Uyeler u where ug.Grup=" + grupid + " and ug.UyeId=u.UyeId";

            SqlDataAdapter adap = new SqlDataAdapter(sql, baglanti_cumlesi);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);

            for (int i = 0; i <= tablo.Rows.Count; i++)
            {
                lb.DataSource=tablo;
                lb.DisplayMember=tablo.Columns[1].ToString();
                lb.ValueMember = tablo.Columns[0].ToString();
            }
        }
        public void YeniGrupOluştur(string yenigrupadı)
        {
            string sql = "insert into Gruplar(GrupAdi,UyeId) values('" + yenigrupadı + "'," + Form_Giris.uyenogonder + ")";
            SqlConnection baglan = new SqlConnection(baglanti_cumlesi);
            SqlCommand komutum = new SqlCommand(sql, baglan);

            baglan.Open();
            komutum.ExecuteNonQuery();
            MessageBox.Show(yenigrupadı + " Adlı Yeni Bir Grup Oluşturuldu.");
            baglan.Close();
        }
        public void TumArkadasları_Grup(ListBox lb)
        {
            string sql = "select u.UyeId,u.UyeAdi+' '+u.UyeSoyadi from Arkadaslar a,Uyeler u where a.Durum='1' and a.Kimin=u.UyeId and a.Kim='" + Form_Giris.uyenogonder + "'";
            SqlDataAdapter Adaptorum = new SqlDataAdapter(sql, baglanti_cumlesi);
            DataTable tablo = new DataTable();
            Adaptorum.Fill(tablo);

                for (int i = 0; i < tablo.Rows.Count; i++)
                {
                    lb.DataSource = tablo;
                    lb.DisplayMember = tablo.Columns[1].ToString();
                    lb.ValueMember = tablo.Columns[0].ToString();
                }
        }
        public void ArkadasiGruptanCikar(int uyeno, int grupno)
        {
            string sql = "delete from UyeGrup where UyeId='"+uyeno+"' and Grup='"+grupno+"'";
            SqlConnection baglan = new SqlConnection(baglanti_cumlesi);
            SqlCommand komutum = new SqlCommand(sql, baglan);

            baglan.Open();
            komutum.ExecuteNonQuery();
            MessageBox.Show("Arkadaş Gruptan Çıkarıldı");
            baglan.Close();
        }
        public void GrubaArkadasEkle(int uye, int grupno)
        {
            string sql = "select * from UyeGrup where UyeId=" + uye + " and Grup=" + grupno + "";
            SqlDataAdapter Adaptor = new SqlDataAdapter(sql, baglanti_cumlesi);
            DataTable tablo = new DataTable();
            Adaptor.Fill(tablo);
            if (tablo.Rows.Count == 0)
            {
                string sqlekle = "insert into UyeGrup(UyeId,Grup) values(" + uye + "," + grupno + ")";
                SqlConnection bag = new SqlConnection(baglanti_cumlesi);
                SqlCommand komut = new SqlCommand(sqlekle, bag);
                bag.Open();
                komut.ExecuteNonQuery();
                MessageBox.Show("Gruba Eklendi");
                bag.Close();
            }
            else
                MessageBox.Show("Zaten grupta");
        }
        public void GrubuSil(int grupno)
        {
            string sqluyegrupsil = "delete from UyeGrup where Grup=" + grupno + "";
            string sqlgrupsil = "delete from Gruplar where GrupId=" + grupno + "";
            SqlConnection bag_uyegrupsil = new SqlConnection(baglanti_cumlesi);
            SqlCommand komut_uyegrupsil = new SqlCommand(sqluyegrupsil, bag_uyegrupsil);
            SqlConnection bag_grupsil = new SqlConnection(baglanti_cumlesi);
            SqlCommand komut_grupsil = new SqlCommand(sqlgrupsil, bag_grupsil);
            bag_uyegrupsil.Open();
            komut_uyegrupsil.ExecuteNonQuery();
            bag_uyegrupsil.Close();
            bag_grupsil.Open();
            komut_grupsil.ExecuteNonQuery();
            bag_grupsil.Close();
            MessageBox.Show("Grup Silindi");
        }
        public void BildirimleriGoster(ListBox lb)
        {
            string sql = "select Bildirim from Bildirimler where UyeId="+Form_Giris.uyenogonder+" order by TarihZaman desc";
            SqlDataAdapter adap = new SqlDataAdapter(sql, baglanti_cumlesi);
            DataTable tab = new DataTable();
            adap.Fill(tab);
            lb.DataSource = tab;
            lb.DisplayMember = tab.Columns[0].ToString();
        }
        public void Durtme()
        {
            string sql = "insert into Durtme(Durten,Durtulen) values(" + Form_Giris.uyenogonder + "," + sinif.ArkadasNo + ")";
            SqlConnection bag = new SqlConnection(baglanti_cumlesi);
            SqlCommand komut = new SqlCommand(sql, bag);
            bag.Open();
            komut.ExecuteNonQuery();
            MessageBox.Show("Dürttün");
            bag.Close();
        }

    }
}


