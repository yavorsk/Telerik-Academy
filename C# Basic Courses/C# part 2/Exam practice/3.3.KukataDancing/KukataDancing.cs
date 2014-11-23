using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3.KukataDancing
{
    class KukataDancing
    {
        static void Main()
        {
            int numOfDances = int.Parse(Console.ReadLine());

            string[,] danceFloor = new string[3,3] {{"RED", "BLUE", "RED" }, {"BLUE", "GREEN", "BLUE"}, {"RED", "BLUE", "RED" }};

            int[,] facing = new int[4, 2] { {0, -1}, {1, 0}, {0, 1}, {-1, 0} }; // up right down left

            List<string> result = new List<string>();

            for (int i = 0; i < numOfDances; i++)
            {
                string dance = Console.ReadLine();
                int currentFacing = 0;
                int[] currentPosition = new int[2] { 1, 1 };

                for (int j = 0; j < dance.Length; j++)
                {
                    if (dance[j] == 'L')
                    {
                        if (currentFacing == 0)
                        {
                            currentFacing = 3;
                        }
                        else
                        {
                            currentFacing--;
                        }
                    }
                    else if (dance[j] == 'R')
                    {
                        if (currentFacing == 3)
                        {
                            currentFacing = 0;
                        }
                        else
                        {
                            currentFacing++;
                        }
                    }
                    else if (dance[j] == 'W')
                    {
                        if ((currentPosition[0] + facing[currentFacing, 0]) == 3)
                        {
                            currentPosition[0] = 0;
                        }
                        else if ((currentPosition[0] + facing[currentFacing, 0]) == -1)
                        {
                            currentPosition[0] = 2;
                        }
                        else
                        {
                            currentPosition[0] = (currentPosition[0] + facing[currentFacing, 0]);
                        }

                        if ((currentPosition[1] + facing[currentFacing, 1]) == 3)
                        {
                            currentPosition[1] = 0;
                        }
                        else if ((currentPosition[1] + facing[currentFacing, 1]) == -1)
                        {
                            currentPosition[1] = 2;
                        }
                        else
                        {
                            currentPosition[1] = (currentPosition[1] + facing[currentFacing, 1]);
                        }
                    }
                }

                result.Add(danceFloor[currentPosition[0], currentPosition[1]]);
            }

            foreach (var color in result)
            {
                Console.WriteLine(color);
            }
        }
    }
}
