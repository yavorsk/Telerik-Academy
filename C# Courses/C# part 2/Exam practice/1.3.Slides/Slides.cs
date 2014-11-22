using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3.Slides
{
    class Slides
    {
        static bool isPassable = true;
        static bool end = false;

        static void Main()
        {
            string[] inputDimensions = Console.ReadLine().Split(' ');

            int w = int.Parse(inputDimensions[0]);
            int h = int.Parse(inputDimensions[1]);
            int d = int.Parse(inputDimensions[2]);

            string[,,] cube = new string[w,h,d];

            for (int i = 0; i < h; i++)
            {
                string[] depth = Console.ReadLine().Trim().Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < depth.Length; j++)
                {
                    string[] width = depth[j].Trim().Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int k = 0; k < width.Length; k++)
                    {
                        cube[k, i, j] = width[k];
                    }
                }
            }

            //for (int i = 0; i < h; i++)
            //{
            //    for (int j = 0; j < d; j++)
            //    {
            //        for (int k = 0; k < w; k++)
            //        {
            //            Console.Write(cube[i, j, k] + " ");
            //        }
            //    }
            //    Console.WriteLine();
            //}

            string[] initialPosition = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] currentPosition = new int[] { int.Parse(initialPosition[0]), 0, int.Parse(initialPosition[1]) };



            while (true)
            {
                switch (cube[currentPosition[0], currentPosition[1], currentPosition[2]][0])
                {
                    case 'S': Array.Copy(SlideBall(currentPosition, cube), 0,currentPosition, 0, 3); break;
                    case 'T': Array.Copy(TeleportBall(currentPosition, cube), 0, currentPosition, 0, 3); break;
                    case 'E': Array.Copy(FallThrough(currentPosition, cube), 0, currentPosition, 0, 3); break;
                    case 'B': Array.Copy(Basket(currentPosition, cube), 0, currentPosition, 0, 3); break;
                }

                if (end)
                {
                    if (isPassable)
                    {
                        Console.WriteLine("Yes");
                        Console.WriteLine("{0} {1} {2}", currentPosition[0], currentPosition[1], currentPosition[2]);
                        break;
                    }
                    else if (!isPassable)
                    {
                        Console.WriteLine("No");
                        Console.WriteLine("{0} {1} {2}", currentPosition[0], currentPosition[1], currentPosition[2]);
                        break;
                    }
                }
            }
        }

        private static Array Basket(int[] currentPosition, string[, ,] cube)
        {
            isPassable = false;
            end = true;
            return currentPosition;
        }

        private static Array FallThrough(int[] currentPosition, string[, ,] cube)
        {
            if (currentPosition[1] == cube.GetLength(1) - 1)
            {
                isPassable = true;
                end = true;
                return currentPosition;
            }
            else
            {
                currentPosition[1]++;
                return currentPosition;
            }
        }

        private static Array TeleportBall(int[] currentPosition, string[, ,] cube)
        {
            string[] teleportDest = cube[currentPosition[0], currentPosition[1], currentPosition[2]].Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            currentPosition[0] = int.Parse(teleportDest[1]);
            currentPosition[2] = int.Parse(teleportDest[2]);

            return currentPosition;
        }

        private static Array SlideBall(int[] currentPosition, string[, ,] cube)
        {
            if (currentPosition[1] == cube.GetLength(1) - 1)
            {
                isPassable = true;
                end = true;
                return currentPosition;
            }
            else
            {
                string[] slideDirections = cube[currentPosition[0], currentPosition[1], currentPosition[2]].Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (currentPosition[1] == cube.GetLength(1) - 1)
                {
                    isPassable = true;
                    end = true;
                    return currentPosition;
                }
                else
                {
                    if (slideDirections[1] == "F")
                    {
                        if (currentPosition[2] == 0)
                        {
                            isPassable = false;
                            end = true;
                            return currentPosition;
                        }
                        else
                        {
                            currentPosition[1]++;
                            currentPosition[2]--;
                            return currentPosition;
                        }
                    }

                    if (slideDirections[1] == "B")
                    {
                        if (currentPosition[2] == cube.GetLength(2)-1)
                        {
                            isPassable = false;
                            end = true;
                            return currentPosition;
                        }
                        else
                        {
                            currentPosition[1]++;
                            currentPosition[2]++;
                            return currentPosition;
                        }
                    }

                    if (slideDirections[1] == "L")
                    {
                        if (currentPosition[0] == 0)
                        {
                            isPassable = false;
                            end = true;
                            return currentPosition;
                        }
                        else
                        {
                            currentPosition[1]++;
                            currentPosition[0]--;
                            return currentPosition;
                        }
                    }

                    if (slideDirections[1] == "R")
                    {
                        if (currentPosition[0] == cube.GetLength(0)-1)
                        {
                            isPassable = false;
                            end = true;
                            return currentPosition;
                        }
                        else
                        {
                            currentPosition[1]++;
                            currentPosition[0]++;
                            return currentPosition;
                        }
                    }

                    if (slideDirections[1] == "FL")
                    {
                        if (currentPosition[0] == 0 || currentPosition[2] == 0)
                        {
                            isPassable = false;
                            end = true;
                            return currentPosition;
                        }
                        else
                        {
                            currentPosition[1]++;
                            currentPosition[0]--;
                            currentPosition[2]--;
                            return currentPosition;
                        }
                    }

                    if (slideDirections[1] == "FR")
                    {
                        if (currentPosition[0] == cube.GetLength(0)-1 || currentPosition[2] == 0)
                        {
                            isPassable = false;
                            end = true;
                            return currentPosition;
                        }
                        else
                        {
                            currentPosition[1]++;
                            currentPosition[0]++;
                            currentPosition[2]--;
                            return currentPosition;
                        }
                    }

                    if (slideDirections[1] == "BL")
                    {
                        if (currentPosition[0] == 0 || currentPosition[2] == cube.GetLength(2)-1)
                        {
                            isPassable = false;
                            end = true;
                            return currentPosition;
                        }
                        else
                        {
                            currentPosition[1]++;
                            currentPosition[0]--;
                            currentPosition[2]++;
                            return currentPosition;
                        }
                    }

                    if (slideDirections[1] == "BR")
                    {
                        if (currentPosition[0] == cube.GetLength(0) - 1 || currentPosition[2] == cube.GetLength(2) - 1)
                        {
                            isPassable = false;
                            end = true;
                            return currentPosition;
                        }
                        else
                        {
                            currentPosition[1]++;
                            currentPosition[0]++;
                            currentPosition[2]++;
                            return currentPosition;
                        }
                    }
                }
            }

            return currentPosition;
        }
    }
}
