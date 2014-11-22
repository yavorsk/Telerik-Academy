namespace _2._2.JoroTheRabbit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] terrain = new int[input.Length];

            int longestRun = 0;

            for (int i = 0; i < input.Length; i++)
            {
                terrain[i] = int.Parse(input[i]);
            }

            for (int startPos = 0; startPos < terrain.Length; startPos++)
            {
                for (int step = 1; step <= terrain.Length; step++)
                {
                    int currentPosition = startPos;
                    int currentRun = 0;

                    while (true)
                    {
                        int nextPosition = 0;
                        nextPosition = (currentPosition + step) % terrain.Length; //CalculateNextPosition(currentPosition, step, terrain.Length);                      

                        if (terrain[currentPosition] < terrain[nextPosition])
                        {
                            currentRun++;
                            currentPosition = nextPosition;
                        }
                        else
                        {
                            if (longestRun<currentRun)
                            {
                                longestRun = currentRun;
                            }
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(longestRun+1);
        }

        private static int CalculateNextPosition(int currentPosition, int step, int arrLength)
        {
            if (currentPosition + step < arrLength)
            {
                return currentPosition + step;
            }
            else
            {
                return step - (arrLength - currentPosition);
            }
        }
    }
}
