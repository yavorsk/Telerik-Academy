using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.NumOfOccurances
{
    // 1.  Write a program that counts in a given array of double values the number of occurrences of each value. 
    // Use Dictionary<TKey,TValue>.
    // Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
    // -2.5  2 times
    // 3  4 times
    // 4  3 times

    class NumOfOccurances
    {
        static void Main()
        {
            var givenArr = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            var resulDict = new SortedDictionary<double, int>();

            foreach (var number in givenArr)
            {
                if (resulDict.ContainsKey(number))
                {
                    resulDict[number]++;
                }
                else
                {
                    resulDict[number] = 1;
                }
            }

            foreach (var keyValue in resulDict)
            {
                Console.WriteLine("{0} --> {1} times", keyValue.Key, keyValue.Value);
            }
        }
    }
}
