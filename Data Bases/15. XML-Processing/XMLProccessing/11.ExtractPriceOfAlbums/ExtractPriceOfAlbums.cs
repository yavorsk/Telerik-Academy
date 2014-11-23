using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace _11.ExtractPriceOfAlbums
{
    class ExtractPriceOfAlbums
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("..\\..\\catalogue.xml");

            string query = "/catalogue/album[year<2009]";

            XmlNodeList olderAlbums = doc.SelectNodes(query);

            foreach (XmlNode node in olderAlbums)
            {
                var albumName = node.SelectSingleNode("albumName").InnerText;
                var albumPrice = node.SelectSingleNode("price").InnerText;
                var albumYear = node.SelectSingleNode("year").InnerText;

                Console.WriteLine("{0} -> {1} -> {2}", albumName, albumPrice, albumYear);
            }
        }
    }
}
