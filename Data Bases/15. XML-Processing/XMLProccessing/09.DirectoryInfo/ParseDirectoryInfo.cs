using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace _09.ParseDirectoryInfo
{
    class ParseDirectoryInfo
    {
        static void Main()
        {
            string folderPath = "..\\..\\";
            string outputFile = "..\\..\\directory.xml";
            DirectoryInfo dir = new DirectoryInfo(folderPath);

            Encoding encoding = Encoding.GetEncoding("windows-1251");

            XmlTextWriter writer = new XmlTextWriter(outputFile, encoding);

            using (writer)
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("directories");

                TraverseAndWriteDirs(writer, dir);

                writer.WriteEndDocument();
            }
        }

        private static void TraverseAndWriteDirs(XmlTextWriter writer, DirectoryInfo currentdir)
        {
            foreach (var file in currentdir.GetFiles())
            {
                writer.WriteStartElement("file");
                writer.WriteAttributeString("name", file.Name);
                writer.WriteEndElement();
            }

            foreach (var folder in currentdir.GetDirectories())
            {
                DirectoryInfo newDir = new DirectoryInfo(currentdir.FullName + "\\" + folder.Name);

                writer.WriteStartElement("directory");
                writer.WriteAttributeString("name", folder.Name);
                TraverseAndWriteDirs(writer, newDir);
                writer.WriteEndElement();
            }
        }
    }
}
