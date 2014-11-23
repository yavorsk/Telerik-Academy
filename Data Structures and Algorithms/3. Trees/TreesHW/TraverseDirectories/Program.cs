using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraverseDirectories
{
    class Program
    {
        static List<string> foundFiles = new List<string>();

        static void Main()
        {
            string rootPath = "C:\\Windows";
            string searchedFilePattern = "*.exe";

            TraverseAndFind(rootPath, searchedFilePattern);

            foreach (var fileName in foundFiles)
            {
                Console.WriteLine(fileName);
            }
        }

        private static void TraverseAndFind(string path, string fileNamePattern)
        {

            string[] filesInCurrentDir = Directory.GetFiles(path, fileNamePattern);
            foundFiles.AddRange(filesInCurrentDir);

            string[] dirsIncurrentDir = Directory.GetDirectories(path);

            try
            {
                foreach (var dir in dirsIncurrentDir)
                {
                    TraverseAndFind(dir, fileNamePattern);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}