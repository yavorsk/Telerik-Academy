using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _08.ReadWriteXml
{
    class ReadWriteXml
    {
        static void Main()
        {
            var filename = @"..\..\catalogue.xml";
            XmlReader reader = XmlReader.Create(filename);

            Encoding encoding = Encoding.GetEncoding("windows-1251");
            XmlTextWriter writer = new XmlTextWriter("..\\..\\output.xml", encoding);

            using (reader)
            {
                using (writer)
                {
                    writer.Formatting = Formatting.Indented;
                    writer.IndentChar = '\t';
                    writer.Indentation = 1;

                    writer.WriteStartDocument();
                    writer.WriteStartElement("albums");

                    string albumName = string.Empty;
                    string artist = string.Empty;

                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "album"))
                        {
                            albumName = string.Empty;
                            artist = string.Empty;
                        }

                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "albumName"))
                        {
                            albumName = reader.ReadElementString();
                        }

                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "artist"))
                        {
                            artist = reader.ReadElementString();
                        }

                        if ((reader.NodeType == XmlNodeType.EndElement) && (reader.Name == "album"))
                        {
                            writer.WriteStartElement("album");
                            writer.WriteElementString("albumName", albumName);
                            writer.WriteElementString("artist", artist);
                            writer.WriteEndElement();
                        }
                    }

                    writer.WriteEndDocument();
                }
            }
        }
    }
}
