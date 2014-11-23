using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RemoveNegativeNums
{
    // 5.Write a program that removes from given sequence all negative numbers.

    static void Main()
    {
        List<int> givenSequence = new List<int>() { 3, -1, 4, -6, -5, 8, 8, 0 };

        for (int i = 0; i < givenSequence.Count; i++)
        {
            if (givenSequence[i] < 0)
            {
                givenSequence.Remove(givenSequence[i]);
                i--;
            }
        }

        // givenSequence.RemoveAll(element => element < 0);

        Console.WriteLine(string.Join(", ", givenSequence));
    }
}
