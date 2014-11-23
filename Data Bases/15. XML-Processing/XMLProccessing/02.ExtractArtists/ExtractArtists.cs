using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _02.ExtractArtists
{
    class ExtractArtists
    {
        // 2. Write program that extracts all different artists which are found in the catalog.xml. 
        // For each author you should print the number of albums in the catalogue. 
        // Use the DOM parser and a hash-table.

        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalogue.xml");

            Dictionary<string, int> artistsAlbums = new Dictionary<string, int>();

            XmlNode rootNode = doc.DocumentElement;

            foreach (XmlNode node in rootNode.ChildNodes)
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
