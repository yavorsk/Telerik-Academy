using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3dLabirynth
{
    class Program
    {
        static void Main()
        {
            string[] strStarting = Console.ReadLine().Split(new char[] { ' ' });
            string[] strDimensions = Console.ReadLine().Split(new char[] { ' ' });

            int[] startingLocation = new int[strStarting.Length];          // starting location
            for (int i = 0; i < strStarting.Length; i++)
            {
                startingLocation[i] = int.Parse(strStarting[i]);
            }

            int[] labDimensions = new int[strDimensions.Length];             // lab dimensions
            for (int i = 0; i < strDimensions.Length; i++)
            {
                labDimensions[i] = int.Parse(strDimensions[i]);
            }

            char[, ,] labirynth = new char[labDimensions[0], labDimensions[1], labDimensions[2]];     // labirynth
            for (int i = 0; i < labDimensions[0]; i++)
            {
                for (int j = 0; j < labDimensions[1]; j++)
                {
                    string strRow = Console.ReadLine();

                    for (int k = 0; k < strRow.Length; k++)
                    {
                        labirynth[i, j, k] = strRow[k];
                    }
                }
            }

            int[, ,] numbers = new int[labDimensions[0], labDimensions[1], labDimensions[2]];

            Queue<int[]> queue = new Queue<int[]>();
            int mark = 0;
            numbers[startingLocation[0], startingLocation[1], startingLocation[2]] = 0;
            queue.Enqueue(startingLocation);

            int[] finalLocation = new int[3];

            while (queue.Count > 0)
            {
                int[] currentLocation = queue.Dequeue();

                if (currentLocation[0] < 0 || currentLocation[0] >= labirynth.GetLength(0))
                {
                    break;
                }

                mark++;

                if (IsPassable(currentLocation, new int[] { 0, 0, 1 }, labirynth, numbers))   // east
                {
                    queue.Enqueue(new int[] { currentLocation[0], currentLocation[1], currentLocation[2] + 1 });
                    numbers[currentLocation[0], currentLocation[1], currentLocation[2] + 1] = numbers[currentLocation[0], currentLocation[1], currentLocation[2]] + 1;
                }
                if (IsPassable(currentLocation, new int[] { 0, 1, 0 }, labirynth, numbers))    // south
                {
                    queue.Enqueue(new int[] { currentLocation[0], currentLocation[1] + 1, currentLocation[2] });
                    numbers[currentLocation[0], currentLocation[1] + 1, currentLocation[2]] = numbers[currentLocation[0], currentLocation[1], currentLocation[2]] + 1;

                }
                if (IsPassable(currentLocation, new int[] { 0, 0, -1 }, labirynth, numbers))   //west
                {
                    queue.Enqueue(new int[] { currentLocation[0], currentLocation[1], currentLocation[2] - 1 });
                    numbers[currentLocation[0], currentLocation[1], currentLocation[2] - 1] = numbers[currentLocation[0], currentLocation[1], currentLocation[2]] + 1;

                }
                if (IsPassable(currentLocation, new int[] { 0, -1, 0 }, labirynth, numbers))    // north
                {
                    queue.Enqueue(new int[] { currentLocation[0], currentLocation[1] - 1, currentLocation[2] });
                    numbers[currentLocation[0], currentLocation[1] - 1, currentLocation[2]] = numbers[currentLocation[0], currentLocation[1], currentLocation[2]] + 1;

                }
                if (IsPassable(currentLocation, new int[] { 1, 0, 0 }, labirynth, numbers))      // up
                {
                    if (currentLocation[0] + 1 == labirynth.GetLength(0))
                    {
                        finalLocation = currentLocation;
                        break;
                    }
                    queue.Enqueue(new int[] { currentLocation[0] + 1, currentLocation[1], currentLocation[2] });
                    if (!(labirynth[currentLocation[0], currentLocation[1], currentLocation[2]] == 'U' && currentLocation[0] == labirynth.GetLength(0) - 1))
                    {
                        numbers[currentLocation[0] + 1, currentLocation[1], currentLocation[2]] = numbers[currentLocation[0], currentLocation[1], currentLocation[2]] + 1;
                    }
                }
                if (IsPassable(currentLocation, new int[] { -1, 0, 0 }, labirynth, numbers))      // down
                {
                    if (currentLocation[0] == 0)
                    {
                        finalLocation = currentLocation;
                        break;
                    }
                    queue.Enqueue(new int[] { currentLocation[0] - 1, currentLocation[1], currentLocation[2] });
                    if (!(labirynth[currentLocation[0], currentLocation[1], currentLocation[2]] == 'D' && currentLocation[0] == 0))
                    {
                        numbers[currentLocation[0] - 1, currentLocation[1], currentLocation[2]] = numbers[currentLocation[0], currentLocation[1], currentLocation[2]] + 1;
                    }
                }

                finalLocation = currentLocation;
            }

            Console.WriteLine(numbers[finalLocation[0], finalLocation[1], finalLocation[2]] + 1);
            // BFS(node)
            //{
            //  queue  node
            //  while queue not empty
            //    v  queue
            //    print v
            //    for each child c of v
            //      queue  c
            //}

        }

        static bool IsPassable(int[] location, int[] direction, char[, ,] lab, int[, ,] numbers)
        {
            bool result = true;

            if (direction[1] != 0 || direction[2] != 0)
            {
                if (location[1] + direction[1] >= lab.GetLength(1) || location[1] + direction[1] < 0)
                {
                    return false;
                }

                if (location[2] + direction[2] >= lab.GetLength(2) || location[2] + direction[2] < 0)
                {
                    return false;
                }

                if (lab[location[0] + direction[0], location[1] + direction[1], location[2] + direction[2]] == '#')
                {
                    return false;
                }


                if (numbers[location[0] + direction[0], location[1] + direction[1], location[2] + direction[2]] != 0)
                {
                    return false;
                }
            }
            else
            {
                if (direction[0] == 1)
                {
                    if (lab[location[0], location[1], location[2]] == 'U')
                    {
                        if (location[0] + 1 == lab.GetLength(0))
                        {
                            return true;
                        }
                        else
                        {
                            if (lab[location[0] + direction[0], location[1] + direction[1], location[2] + direction[2]] == '#' ||
                                numbers[location[0] + direction[0], location[1] + direction[1], location[2] + direction[2]] != 0)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                if (direction[0] == -1)
                {
                    if (lab[location[0], location[1], location[2]] == 'D')
                    {
                        if (location[0] - 1 == -1)
                        {
                            return true;
                        }
                        else
                        {
                            if (lab[location[0] + direction[0], location[1] + direction[1], location[2] + direction[2]] == '#' ||
                                numbers[location[0] + direction[0], location[1] + direction[1], location[2] + direction[2]] != 0)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return result;
        }
    }
}
