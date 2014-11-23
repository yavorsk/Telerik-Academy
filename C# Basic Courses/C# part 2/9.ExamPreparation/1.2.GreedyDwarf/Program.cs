using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2.GreedyDwarff
{
    class GreedyDwarff
    {
        static void Main(string[] args)
        {
            string stringValley = Console.ReadLine();

            char[] splitChars = new char[] { ' ', ',' };
            string[] stringValleyArr = stringValley.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);

            int[] valley = new int[stringValleyArr.Length];

            for (int i = 0; i < stringValleyArr.Length; i++)
            {
                valley[i] = int.Parse(stringValleyArr[i]);
            }

            int m = int.Parse(Console.ReadLine());

            int maxCoins = int.MinValue;

            for (int i = 0; i < m; i++)
            {
                string stringPattern = Console.ReadLine();
                string[] stringPatternArr = stringPattern.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);

                int[] pattern = new int[stringPatternArr.Length];

                for (int j = 0; j < stringPatternArr.Length; j++)
                {
                    pattern[j] = int.Parse(stringPatternArr[j]);
                }

                int patternIndex = 0;
                int currentPosition = 0;
                List<int> visitedPositions = new List<int>();
                int currentCoins = valley[0];

                while (true)
                {
                    visitedPositions.Add(currentPosition);
                    if (Passable(patternIndex, currentPosition, valley, pattern, visitedPositions))
                    {
                        currentPosition += pattern[patternIndex];
                        currentCoins += valley[currentPosition];

                        if (patternIndex < pattern.Length - 1)
                        {
                            patternIndex++;
                        }
                        else
                        {
                            patternIndex = 0;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (maxCoins < currentCoins)
                {
                    maxCoins = currentCoins;
                }
            }

            Console.WriteLine(maxCoins);
        }

        private static bool Passable(int patternIndex, int currentPosition, int[] valley, int[] pattern, List<int> visitedPositions)
        {
            if (pattern[patternIndex] + currentPosition >= valley.Length)
            {
                return false;
            }
            else if (pattern[patternIndex] + currentPosition < 0)
            {
                return false;
            }
            else if (visitedPositions.Contains(currentPosition + pattern[patternIndex]))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
