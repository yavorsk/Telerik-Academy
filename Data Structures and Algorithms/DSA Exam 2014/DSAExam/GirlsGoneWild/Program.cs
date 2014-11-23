using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirlsGoneWild
{
    class Program
    {
        static int n;
        static int k;
        static string[] arr;

        static SortedSet<string> result = new SortedSet<string>();
        static List<string> possibleOutfits = new List<string>();

        static void Main()
        {
            int numberOfShirts = int.Parse(Console.ReadLine());
            string skirts = Console.ReadLine();
            int numberOfGirls = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfShirts; i++)
            {
                for (int j = 0; j < skirts.Length; j++)
                {
                    if (!possibleOutfits.Contains(i.ToString() + skirts[j].ToString()))
                    {
                        possibleOutfits.Add(i.ToString() + skirts[j].ToString());
                    }
                }
            }

            k = numberOfGirls;
            n = possibleOutfits.Count;
            arr = new string[k];

            GenerateCombinationsNoRepetitions(0, 0);

            Console.WriteLine(result.Count);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        static void GenerateCombinationsNoRepetitions(int index, int start)
        {
            if (index >= k)
            {
                var repetition = false;

                for (int i = 0; i < arr.Length; i++)
                {
                    char startsWith = arr[i][0];

                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (startsWith == arr[j][0])
                        {
                            repetition = true;
                            break;
                        }
                    }

                    if (repetition)
                    {
                        break;
                    }
                }

                for (int i = 0; i < arr.Length; i++)
                {
                    char endsWith = arr[i][1];

                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (endsWith == arr[j][1])
                        {
                            repetition = true;
                            break;
                        }
                    }

                    if (repetition)
                    {
                        break;
                    }
                }

                if (!repetition)
                {
                    var combo = string.Join("-", arr);
                    result.Add(combo);
                }
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    arr[index] = possibleOutfits[i];
                    GenerateCombinationsNoRepetitions(index + 1, i + 1);
                }
            }
        }
    }
}
