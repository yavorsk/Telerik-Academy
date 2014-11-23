using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.FileSystem
{
    class Folder
    {
        public string Name { get; set; }

        public List<File> Files { get; set; }

        public List<Folder> ChildDirectories { get; set; }

        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.ChildDirectories = new List<Folder>();
        }

        public long GetSizeOfFilesInDir()
        {
            long cumulativeSize = 0;

            foreach (var file in this.Files)
            {
                cumulativeSize += file.Size;
            }

            return cumulativeSize;
        }
    }
}
