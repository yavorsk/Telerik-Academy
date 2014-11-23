using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _03.ExtractArtXPath
{
    class ExtractArtXPath
    {
        // 3. Implement the previous using XPath.

        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalogue.xml");

            Dictionary<string, int> artistsAlbums = new Dictionary<string, int>();

            string xPathQuery = "catalogue/album";
            XmlNodeList albumsList = doc.SelectNodes(xPathQuery);

            foreach (XmlNode node in albumsList)
            {
                var artist = node["artist"].InnerText;

                if (artistsAlbums.ContainsKey(artist))
                {
                    artistsAlbums[artist]++;
                }
                else
                {
                    artistsAlbums[artist] = 1;
                }
            }

            foreach (var pair in artistsAlbums)
            {
                Console.WriteLine("{0} --> {1}", pair.Key, pair.Value);
            }
        }
    }
}
