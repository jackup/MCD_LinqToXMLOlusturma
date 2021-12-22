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
            #region Linq ile xml'e veri yazma
            /*List<Ogrenci> Ogrencilerim = new List<Ogrenci>();
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

            doc.Save("c:\\XML\\Ogrencilerim.xml");*/
            #endregion

            #region Xml Okuma
            XDocument DockOku = XDocument.Load(@"c:\\XML\\Ogrencilerim.xml");
            List<XElement> OkunanXElements = DockOku.Descendants("Ogrenci").ToList();
            List<Ogrenci> okunanData = new List<Ogrenci>();

            foreach (XElement item in OkunanXElements)
            {
                Ogrenci Temp = new Ogrenci();
                Temp.ID = Guid.Parse(item.Attribute("ID").Value);
                Temp.Isim = item.Element("İsim").Value;
                Temp.Soyisim = item.Element("Soyisim").Value;
                Temp.Numara = int.Parse(item.Element("Numara").Value);
                okunanData.Add(Temp);
            }
            #endregion
        }
    }
}
