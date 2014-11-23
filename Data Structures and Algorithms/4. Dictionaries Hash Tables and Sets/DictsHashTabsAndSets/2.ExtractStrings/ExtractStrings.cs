using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.ExtractStrings
{
    // 1. Write a program that extracts from a given sequence of strings all elements that present in it 
    // odd number of times. Example:
    // {C#, SQL, PHP, PHP, SQL, SQL }  {C#, SQL}

    class ExtractStrings
    {
        static void Main()
        {
            var givenArray = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            var resultDict = new Dictionary<string, int>();

            foreach (var element in givenArray)
            {
                if (resultDict.ContainsKey(element))
                {
                    resultDict[element]++;
                }
                else
                {
                    resultDict[element] = 1;
                }
            }

            foreach (var pair in resultDict)
            {
                if (pair.Value % 2 != 0)
                {
                    Console.WriteLine(pair.Key);
                }
            }
        }
    }
}
