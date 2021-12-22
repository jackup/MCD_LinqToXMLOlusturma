using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Xml.Linq;

namespace MCD_LinqToXMLOlusturma
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ogrenci> Ogrencilerim = new List<Ogrenci>();
            for (int i = 0; i < 50; i++)
            {
                Ogrenci temp = new Ogrenci();
                temp.ID = Guid.NewGuid();
                temp.Isim = FakeData.NameData.GetFirstName();
                temp.Soyisim = FakeData.NameData.GetSurname();
                temp.Numara = FakeData.NumberData.GetNumber(100, 500);
                Ogrencilerim.Add(temp);
            }
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "UTF-8", "yes"),
                new XElement("Ogrencilerim", Ogrencilerim.Select
                (x => new XElement("Ogrenci",
                      new XAttribute("ID", x.ID),
                      new XElement("İsim", x.Isim),
                      new XElement("Soyisim", x.Soyisim),
                      new XElement("Numara", x.Numara)
            ))));

            doc.Save("c:\\XML\\Ogrencilerim.xml");
        }
    }
}
