using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sums
{
    class PossibleSubsetSums
    {
        static void Main()
        {
            int[] numbers = { 4, 2, 7, 5 };
            List<int> sums = CalculateSums(numbers);

            foreach (var sum in sums)
            {
                Console.WriteLine(sum);
            }
        }

        private static List<int> CalculateSums(int[] numbers)
        {
            int maxSum = numbers.Sum();
            int currentMaxSum = 0;
            int currentMaxSumWithNumber = 0;

            bool[] possibleSums = new bool[maxSum + 1];
            possibleSums[0] = true;

            foreach (var currentNumber in numbers)
            {
                currentMaxSumWithNumber = currentMaxSum;

                for (int i = currentMaxSum; i >= 0; i--)
                {
                    if (possibleSums[i])
                    {
                        if (currentMaxSumWithNumber < i + currentNumber)
                        {
                            currentMaxSumWithNumber = i + currentNumber;
                        }

                        possibleSums[i + currentNumber] = true;
                    }
                }

                currentMaxSum = currentMaxSumWithNumber;
            }

            var sums = new List<int>();
            for (int i = 0; i < possibleSums.Length; i++)
            {
                if (possibleSums[i])
                {
                    sums.Add(i);
                }
            }

            return sums;
        }
    }
}
