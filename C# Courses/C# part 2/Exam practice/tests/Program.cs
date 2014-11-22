using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    class Program
    {
        static void Main(string[] args)
        {
            //StringBuilder line = new StringBuilder("javor   stoychev kalina    j a v    oro v   a");
            //for (int j = 1; j < line.Length - 1; j++)
            //{
            //    if (line[j] == ' ' && line[j+1] == ' ')
            //    {
            //        line.Remove(j+1, 1);
            //        j--;
            //    }
            //}

            //Console.WriteLine(line.ToString());

            StringBuilder outputLine = new StringBuilder();

            outputLine.Append("drinkiiiing");

            Console.WriteLine(outputLine.ToString().IndexOf(' ', 0));
            
        }
    }
}
