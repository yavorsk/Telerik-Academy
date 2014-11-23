using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryPasswords
{
    class BinaryPasswords
    {
        static void Main()
        {
            long comboCount = 0;

            string template = Console.ReadLine();

            int gapsCounter = 0;

            for (int i = 0; i < template.Length; i++)
            {
                if (template[i] == '*')
                {
                    gapsCounter++;
                }
            }

            if (gapsCounter == 0)
            {
                Console.WriteLine(1);
            }
            else
            {
                comboCount = (long)Math.Pow(2, gapsCounter);
                Console.WriteLine(comboCount);
            }
        }
    }
}
