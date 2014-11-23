using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Tron2D
{
    class Program
    {
        static int[] redDirection = new int[] { 0, 1,};
        static int[] blueDirection = new int[] { 0, -1};

        static void Main(string[] args)
        {
            string[] dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int x = int.Parse(dimensions[0]);
            int y = int.Parse(dimensions[1]);
            int z = int.Parse(dimensions[2]);

            char[] moveRed = Console.ReadLine().ToCharArray();
            char[] moveBlue = Console.ReadLine().ToCharArray();

            int[,] playField = new int[x + 1, 2*y + z*2];

            bool[,] redVisited = new bool[x + 1, 2 * y + z * 2];
            bool[,] blueVisited = new bool[x + 1, 2 * y + z * 2];


            int[] redPosition = new int[] { x / 2, y / 2 };
            bool redCrash = false;
            redVisited[x / 2, y / 2] = true;

            int[] bluePosition = new int[] { x / 2, y + z + y / 2 };
            bool blueCrash = false;
            blueVisited[x / 2, y + z + y / 2] = true;

            string matchResult = string.Empty;

            for (int instruction = 0; instruction < moveRed.Length; instruction++)
            {
                // move red
                if (moveRed[instruction] == 'L')
                {
                    CalculateRedDirection(redDirection, 'L');
                }
                else if (moveRed[instruction] == 'R')
                {
                    CalculateRedDirection(redDirection, 'R');
                }

                int newPosXred = redPosition[0] + redDirection[0];
                int newPosYred = redPosition[1] + redDirection[1];

                if (newPosXred < 0 || newPosXred > playField.GetLength(0)-1)
                {
                    redCrash = true;
                }
                else
                {
                    redPosition[0] = newPosXred;
                }

                if (newPosYred < 0)
                {
                    redPosition[1] = playField.GetLength(1) - 1;
                }
                else if (newPosYred > playField.GetLength(1) - 1)
                {
                    redPosition[1] = 0;
                }
                else
                {
                    redPosition[1] = newPosYred;
                }
                redVisited[redPosition[0], redPosition[1]] = true;

                // move blue
                if (moveBlue[instruction] == 'L')
                {
                    CalculateBlueDirection(blueDirection, 'L');
                }
                else if (moveBlue[instruction] == 'R')
                {
                    CalculateBlueDirection(blueDirection, 'R');
                }

                int newPosXblue = bluePosition[0] + blueDirection[0];
                int newPosYblue = bluePosition[1] + blueDirection[1];

                if (newPosXblue < 0 || newPosXblue > playField.GetLength(0) - 1)
                {
                    blueCrash = true;
                }
                else
                {
                    bluePosition[0] = newPosXblue;
                }

                if (newPosYblue < 0)
                {
                    bluePosition[1] = playField.GetLength(1) - 1;
                }
                else if (newPosYblue > playField.GetLength(1) - 1)
                {
                    bluePosition[1] = 0;
                }
                else
                {
                    bluePosition[1] = newPosYblue;
                }
                blueVisited[bluePosition[0], bluePosition[1]] = true;


                if (redVisited[bluePosition[0], bluePosition[1]])
                {
                    blueCrash = true;
                }

                if (blueVisited[redPosition[0], redPosition[1]])
                {
                    redCrash = true;
                }

                if (redCrash && blueCrash)
                {
                    matchResult = "DRAW";
                    break;
                }
                else if (redCrash && !blueCrash)
                {
                    matchResult = "BLUE";
                    break;
                }
                else if (!redCrash && blueCrash)
                {
                    matchResult = "RED";
                    break;
                }
            }

            if (!redCrash && !blueCrash)
            {
                matchResult = "DRAW";
            }

            int dist1 = Math.Abs(redPosition[0] - (x / 2))  + playField.GetLength(1) - redPosition[1] + y/2 -2;
            int distance = Math.Abs(redPosition[0] - (x / 2)) + Math.Abs(redPosition[1] - (y / 2));

            Console.WriteLine(matchResult);
            Console.WriteLine(distance);
        }

        private static void CalculateBlueDirection(int[] direction, char instr)
        {
            if (direction[0] == 1)
            {
                if (instr == 'L')
                {
                    blueDirection[0] = 0;
                    blueDirection[1] = -1;
                }
                else if (instr == 'R')
                {
                    blueDirection[0] = 0;
                    blueDirection[1] = 1;
                }
            }

            else if (direction[0] == -1)
            {
                if (instr == 'L')
                {
                    blueDirection[0] = 0;
                    blueDirection[1] = 1;
                }
                else if (instr == 'R')
                {
                    blueDirection[0] = 0;
                    blueDirection[1] = -1;
                }
            }

            else if (direction[1] == 1)
            {
                if (instr == 'L')
                {
                    blueDirection[0] = 1;
                    blueDirection[1] = 0;
                }
                else if (instr == 'R')
                {
                    blueDirection[0] = -1;
                    blueDirection[1] = 0;
                }
            }

            else if (direction[1] == -1)
            {
                if (instr == 'L')
                {
                    blueDirection[0] = -1;
                    blueDirection[1] = 0;
                }
                else if (instr == 'R')
                {
                    blueDirection[0] = 1;
                    blueDirection[1] = 0;
                }
            }
        }

        private static void CalculateRedDirection(int[] direction, char instr)
        {
            if (direction[0] == 1)
            {
                if (instr == 'L')
                {
                    redDirection[0] = 0;
                    redDirection[1] = -1;
                }
                else if (instr == 'R')
                {
                    redDirection[0] = 0;
                    redDirection[1] = 1;
                }
            }

            else if (direction[0] == -1)
            {
                if (instr == 'L')
                {
                    redDirection[0] = 0;
                    redDirection[1] = 1;
                }
                else if (instr == 'R')
                {
                    redDirection[0] = 0;
                    redDirection[1] = -1;
                }
            }

            else if (direction[1] == 1)
            {
                 if (instr == 'L')
                {
                    redDirection[0] = 1;
                    redDirection[1] = 0;
                }
                else if (instr == 'R')
                {
                    redDirection[0] = -1;
                    redDirection[1] = 0;
                }
            }

            else if (direction[1] == -1)
            {
                if (instr == 'L')
                {
                    redDirection[0] = -1;
                    redDirection[1] = 0;
                }
                else if (instr == 'R')
                {
                    redDirection[0] = 1;
                    redDirection[1] = 0;
                }
            }
        }
    }
}
