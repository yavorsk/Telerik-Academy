using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine('a'.CompareTo('A'));
            Console.WriteLine("a".CompareTo("A"));

            Console.WriteLine((int)'a');
            Console.WriteLine((int)'A');
        }
    }
}
