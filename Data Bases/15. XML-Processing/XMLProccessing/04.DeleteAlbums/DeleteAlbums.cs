using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _04.DeleteAlbums
{
    class DeleteAlbums
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("..\\..\\catalogue.xml");

            XmlNode rootNode = doc.DocumentElement;

            for (int i = 0; i < rootNode.ChildNodes.Count; i++)
            {
                if (double.Parse(rootNode.ChildNodes[i]["price"].InnerText) > 20)
                {
                    string albumName = rootNode.ChildNodes[i]["albumName"].InnerText;
                    var nodeToRemove = rootNode.ChildNodes[i];
                    rootNode.RemoveChild(nodeToRemove);
                    Console.WriteLine("Album {0} removed", albumName);
                }
            }

            doc.Save("..\\..\\newCatalogue.xml");
        }
    }
}
