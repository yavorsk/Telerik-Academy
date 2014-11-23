using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace _12.ExtractPricesLinq
{
    class ExtractPricesLinq
    {
        static void Main()
        {
            XDocument doc = XDocument.Load("..\\..\\catalogue.xml");

            var result =
                from album in doc.Descendants("album")
                where int.Parse(album.Element("year").Value) < 2009
                select new
                {
                    Name = album.Element("albumName").Value,
                    Price = album.Element("price").Value,
                    Year = album.Element("year").Value
                };

            foreach (var elem in result)
            {
                Console.WriteLine("{0} -> {1} -> {2}", elem.Name, elem.Price, elem.Year);
            }
        }
    }
}
