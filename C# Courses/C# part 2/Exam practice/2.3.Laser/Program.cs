using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3.Laser
{
    class Program
    {
        static void Main()
        {
            string[] dimensions = Console.ReadLine().Split();
            int w = int.Parse(dimensions[0]);
            int h = int.Parse(dimensions[1]);
            int d = int.Parse(dimensions[2]);

            string[] startPosition = Console.ReadLine().Split();
            int[] position = new int[startPosition.Length];
            for (int i = 0; i < startPosition.Length; i++)
            {
                position[i] = int.Parse(startPosition[i]);
            }

            string[] startVector = Console.ReadLine().Split();
            int[] vector = new int[startVector.Length];
            for (int i = 0; i < startVector.Length; i++)
            {
                vector[i] = int.Parse(startVector[i]);
            }

            bool[, ,] burned = new bool[w, h, d];

            for (int i = 0; i < burned.GetLength(0); i++)
            {
                for (int j = 0; j < burned.GetLength(1); j++)
                {
                    for (int k = 0; k < burned.GetLength(2); k++)
                    {
                        if ((i==0 || i == burned.GetLength(0)-1) && (j == 0 || j == burned.GetLength(1) - 1))
                        {
                            burned[i, j, k] = true;
                            continue;
                        }
                        if ((i == 0 || i == burned.GetLength(0) - 1) && (k == 0 || k == burned.GetLength(2) - 1))
                        {
                            burned[i, j, k] = true;
                            continue;
                        }
                        if ((j == 0 || j == burned.GetLength(1) - 1) && (k == 0 || k == burned.GetLength(2) - 1))
                        {
                            burned[i, j, k] = true;
                            continue;
                        }
                    }
                }
            }

            burned[position[0]-1, position[1]-1, position[2]-1] = true;

            int[] nextPosition = new int[3];

            while (true)
            {
           

                if (position[0] == w && vector[0] == 1)
                {
                    vector[0] = -1;
                }

                else if (position[0] == 1 && vector[0] == -1)
                {
                    vector[0] = 1;
                }

                else if (position[1] == h && vector[1] == 1)
                {
                    vector[1] = -1;
                }

                else if (position[1] == 1 && vector[1] == -1)
                {
                    vector[1] = 1;
                }

                else if (position[2] == d && vector[2] == 1)
                {
                    vector[2] = -1;
                }

                else if (position[2] == 1 && vector[2] == -1)
                {
                    vector[2] = 1;
                }

                for (int i = 0; i < position.Length; i++)
                {
                    nextPosition[i] = position[i] + vector[i];
                }

                if (burned[nextPosition[0]-1,nextPosition[1]-1,nextPosition[2]-1])
                {
                    break;
                }

                for (int i = 0; i < position.Length; i++)
                {
                    position[i] = nextPosition[i];
                }

                burned[position[0] - 1, position[1] - 1, position[2] - 1] = true;
            }

            for (int i = 0; i < position.Length; i++)
            {
                Console.Write(i < 2 ? position[i] + " " : position[i].ToString());
            }
            Console.WriteLine();
        }
    }
}
