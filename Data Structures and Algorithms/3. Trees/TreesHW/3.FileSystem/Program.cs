using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.FileSystem
{
    class Program
    {
        static StringBuilder tree = new StringBuilder();

        static void Main()
        {
            string rootDirPath = "C:\\Windows";

            Folder fileSystemTree = BuildFileSystemTree(rootDirPath);

            string padding = string.Empty;

            PrintFolderTree(fileSystemTree, padding);
            //Console.WriteLine(tree.ToString());

            Console.WriteLine(GetSizeOfSubTree(fileSystemTree).ToString() + " bytes");
        }

        private static long GetSizeOfSubTree(Folder fileSystemTree)
        {
            long size = fileSystemTree.GetSizeOfFilesInDir();

            foreach (var folder in fileSystemTree.ChildDirectories)
            {
                size += folder.GetSizeOfFilesInDir();
            }

            return size;
        }

        private static void PrintFolderTree(Folder rootFolder, string padding)
        {
            tree.AppendLine(rootFolder.Name);

            padding += " ";

            foreach (var file in rootFolder.Files)
            {
                tree.AppendLine(padding + file.Name);
            }

            foreach (var folder in rootFolder.ChildDirectories)
            {
                PrintFolderTree(folder, padding);
            }
        }

        private static Folder BuildFileSystemTree(string rootDirPath)
        {
            Folder rootFolder = new Folder(rootDirPath);

            string[] filesInCUrrentDir = Directory.GetFiles(rootDirPath);

            foreach (var path in filesInCUrrentDir)
            {
                FileInfo fInfo = new FileInfo(path);
                long fileSize = fInfo.Length;

                File curFile = new File(path, fileSize);

                rootFolder.Files.Add(curFile);
            }

            string[] foldersInCurrentDir = Directory.GetDirectories(rootDirPath);

            try
            {
                foreach (var folderPath in foldersInCurrentDir)
                {
                    Folder currFolder = BuildFileSystemTree(folderPath);

                    rootFolder.ChildDirectories.Add(currFolder);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return rootFolder;
        }
    }
}