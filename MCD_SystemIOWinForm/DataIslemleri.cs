using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MCD_SystemIOWinForm
{
    class DataIslemleri
    {
        public DataIslemleri()
        {
            
        }

        public List<Personel>PersonelGetir(int adet)
        {
            List<Personel> personelListe = new List<Personel>();

            int id = 0;
            for (int i = 0; i <= adet; i++)
            {
                Personel personel = new Personel();
                personel.id = id++;
                personel.isim = FakeData.NameData.GetFirstName();
                personel.soyisim = FakeData.NameData.GetSurname();
                personel.firmaAdi = FakeData.NetworkData.GetDomain();
                personel.emailAdres = personel.isim + "." + personel.soyisim + "@" + personel.firmaAdi;
                personel.ulke = FakeData.PlaceData.GetCountry();
                personelListe.Add(personel);
            }
            return personelListe;
        }

        public void PersonelKaydet(string path, List<Personel>personeListesi)
        {
            DirectoryInfo ulkeBilgisi = null;
            for (int i = 0; i < personeListesi.Count; i++)
            {
                if (Directory.Exists(path + "\\" + personeListesi[i].ulke))
                {
                    ulkeBilgisi = new DirectoryInfo(path + "\\" + personeListesi[i].ulke);
                }
                else
                {
                    ulkeBilgisi = Directory.CreateDirectory(path + "\\" + personeListesi[i].ulke);
                }
                FileStream fs = File.Create(ulkeBilgisi.FullName + "\\" + personeListesi[i].isim + "." + personeListesi[i].soyisim + ".txt");
                byte[] personelBilgi = new UTF8Encoding(true).GetBytes(personeListesi[i].personelBilgiGetir());

                fs.Write(personelBilgi, 0, personelBilgi.Length);
                fs.Close();
            }
        }
    }
}
