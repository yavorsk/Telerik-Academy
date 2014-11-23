using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _06.ExtractSongsLinq
{
    class ExtractSongsLinq
    {
        static void Main()
        {
            XDocument xmlDoc = XDocument.Load("../../catalogue.xml");
            var songTitles =
                from song in xmlDoc.Descendants("song")
                select song.Value;

            foreach (var songTitle in songTitles)
            {
                Console.WriteLine(songTitle);
            }
            
        }
    }
}
