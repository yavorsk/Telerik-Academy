using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _05.ExtractSongTitles
{
    class ExtractSongTitles
    {
        static void Main()
        {
            var filename = @"..\..\catalogue.xml";
            XmlReader reader = XmlReader.Create(filename);
            List<string> songTitles = new List<string>();

            using (reader)
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "song"))
                    {
                        string songTitle = reader.ReadElementString();
                        songTitles.Add(songTitle);
                        
                    }
                }
            }

            foreach (var song in songTitles)
            {
                Console.WriteLine(song);
            }
        }
    }
}
