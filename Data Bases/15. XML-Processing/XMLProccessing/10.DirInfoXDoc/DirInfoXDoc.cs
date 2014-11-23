using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace _09.ParseDirectoryInfo
{
    class DirInfoXDoc
    {
        static void Main()
        {

            //XElement booksXml = new XElement("books",
            //    new XElement("book",
            //        new XElement("author", "Don Box"),
            //        new XElement("title", "ASP.NET")
            //    ),
            //    new XElement("book",
            //        new XElement("author", "Svetlin Nakov and his team"),
            //        new XElement("title", "Introduction to Programming with C#")
            //    )
            //);

            string folderPath = "..\\..\\";
            DirectoryInfo dirInfo = new DirectoryInfo(folderPath);

            XElement dirTree = new XElement("directories");

                TraverseAndWriteDirs(dirTree, dirInfo);

                dirTree.Save("..\\..\\directories.xml");
        }

        private static void TraverseAndWriteDirs(XElement parentDirTree, DirectoryInfo currentDirInfo)
        {
            foreach (var file in currentDirInfo.GetFiles())
            {
                parentDirTree.Add(new XElement("file", new XAttribute("name", file.Name)));
            }

            foreach (var folder in currentDirInfo.GetDirectories())
            {
                DirectoryInfo newDirInfo = new DirectoryInfo(currentDirInfo.FullName + "\\" + folder.Name);

                var newDirTree = new XElement("directory", new XAttribute("name", folder.Name));
                parentDirTree.Add(newDirTree);
                TraverseAndWriteDirs(newDirTree, newDirInfo);
            }
        }

        //private static void TraverseAndWriteDirs(XmlTextWriter writer, DirectoryInfo currentdir)
        //{
        //    foreach (var file in currentdir.GetFiles())
        //    {
        //        writer.WriteStartElement("file");
        //        writer.WriteAttributeString("name", file.Name);
        //        writer.WriteEndElement();
        //    }

        //    foreach (var folder in currentdir.GetDirectories())
        //    {
        //        DirectoryInfo newDir = new DirectoryInfo(currentdir.FullName + "\\" + folder.Name);

        //        writer.WriteStartElement("directory");
        //        writer.WriteAttributeString("name", folder.Name);
        //        TraverseAndWriteDirs(writer, newDir);
        //        writer.WriteEndElement();
        //    }
        //}
    }
}
