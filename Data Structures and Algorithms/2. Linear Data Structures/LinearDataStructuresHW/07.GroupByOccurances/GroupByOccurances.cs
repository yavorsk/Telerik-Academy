using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class GroupByOccurances
{
    // 7. Write a program that finds in given array of integers (all belonging to the range [0..1000]) 
    // how many times each of them occurs.
    //    Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
    //    2  2 times
    //    3  4 times
    //    4  3 times

    static void Main()
    {
        List<int> givenSequence = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

        Dictionary<int, int> numberOccurances = new Dictionary<int, int>();

        for (int i = 0; i < givenSequence.Count; i++)
        {
            if (numberOccurances.ContainsKey(givenSequence[i]))
            {
                numberOccurances[givenSequence[i]]++;
            }
            else
            {
                //numberOccurances[givenSequence[i]] = 1;
                numberOccurances.Add(givenSequence[i], 1);
            }
        }

        foreach (var kvp in numberOccurances)
        {
            Console.WriteLine("{0} --> {1} times", kvp.Key, kvp.Value);
        }
    }
}
