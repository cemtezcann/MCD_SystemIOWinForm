using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCD_SystemIOWinForm
{
    public partial class Form1 : Form
    {
        DataIslemleri dataIslemleri;
        List<Personel> personelListesi;
        public Form1()
        {
            InitializeComponent();
            dataIslemleri = new DataIslemleri();
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnPersonelGetir_Click(object sender, EventArgs e)
        {
            personelListesi = dataIslemleri.PersonelGetir(150);
            lstPersonel.DataSource = personelListesi;
        }

        private void lstPersonel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Personel secilenPersonel = (Personel)lstPersonel.SelectedItem;
            txtIsim.Text = secilenPersonel.isim;
            txtSoyisim.Text = secilenPersonel.soyisim;
            txtEmailAdres.Text = secilenPersonel.emailAdres;
            txtFirma.Text = secilenPersonel.firmaAdi;
            txtUlke.Text = secilenPersonel.ulke;
        }

        private void btnPersonelKaydet_Click(object sender, EventArgs e)
        {
            dataIslemleri.PersonelKaydet("c:\\NetworkAkademi", personelListesi);
        }
    }
}
