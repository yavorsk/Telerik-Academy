using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.FileSystem
{
    class File
    {
        public string Name { get; set; }

        public long Size { get; set; }

        public File(string name)
        {
            this.Name = name;
        }

        public File(string name, long size)
            : this(name)
        {
            this.Size = size;
        }
    }
}
