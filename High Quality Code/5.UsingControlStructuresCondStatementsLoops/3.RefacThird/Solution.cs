using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.RefacThird
{
    class Solution
    {
        static void main()
        {
            int[] array = new Array();

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(array[i]);
                if (array[i] == expectedValue)
                {
                    Console.WriteLine("Value Found");
                    break;
                }
            }
        }
    }
}
