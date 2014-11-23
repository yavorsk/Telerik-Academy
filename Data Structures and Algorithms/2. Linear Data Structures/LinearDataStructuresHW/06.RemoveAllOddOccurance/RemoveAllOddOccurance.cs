using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RemoveAllOddOccurance
{
    // Write a program that removes from given sequence all numbers that occur odd number of times. Example:
    // {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}  {5, 3, 3, 5}

    static void Main()
    {
        List<int> givenSequence = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

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

        givenSequence.RemoveAll(element => numberOccurances[element] % 2 != 0);

        //// Remove elements with Loop:
        //for (int i = 0; i < givenSequence.Count; i++)
        //{
        //    if (numberOccurances[givenSequence[i]] % 2 != 0)
        //    {
        //        givenSequence.Remove(givenSequence[i]);
        //        i--;
        //    }
        //}

        Console.WriteLine(string.Join(", ", givenSequence));
    }
}
