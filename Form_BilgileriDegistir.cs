using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace KafaKagidi_ver._0
{
    public partial class Form_BilgileriDegistir : Form
    {
        public Form_BilgileriDegistir()
        {
            InitializeComponent();
        }
        sinif s = new sinif();
        string baglanti_cumlesi = "data source=MYCOMPUTER; initial catalog=Nesne_Proje_2; integrated security=true";
        private void btOnayla_Click(object sender, EventArgs e)
        {
            s.BilgileriDegistir(textBox5.Text, textBox6.Text, textBox7.Text, Form_Giris.uyenogonder,Convert.ToInt32(comboBox1.SelectedValue));
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7 .Text= "";
        }

        private void Form_BilgileriDegistir_Load(object sender, EventArgs e)
        {
            string sql = "select IliskiNo,IliskiAdi from Iliskiler";
            SqlDataAdapter adaptor = new SqlDataAdapter(sql, baglanti_cumlesi);
            DataTable tablo = new DataTable();

            adaptor.Fill(tablo);
            
            comboBox1.DataSource = tablo;
            comboBox1.DisplayMember = tablo.Columns[1].ToString();
            comboBox1.ValueMember = tablo.Columns[0].ToString();


            
        }
    }
}
