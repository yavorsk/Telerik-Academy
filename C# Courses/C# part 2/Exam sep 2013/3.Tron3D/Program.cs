using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Tron3D
{
    class Program
    {
        static int[] redDirection = new int[] { 0, 1, 0 };
        static int[] blueDirection = new int[] { 0, 1, 0 };

        static void Main()
        {
            string[] dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int x = int.Parse(dimensions[0]);
            int y = int.Parse(dimensions[1]);
            int z = int.Parse(dimensions[2]);

            char[] moveRed = Console.ReadLine().ToCharArray();
            char[] moveBlue = Console.ReadLine().ToCharArray();

            int[,,] playField = new int[x+1,y+1,z+1];

            bool[,,] redVisited = new bool[x+1,y+1,z+1];
            bool[,,] blueVisited = new bool[x+1,y+1,z+1];

            int[] redPosition = new int[] { x / 2, y / 2, 0 };

            bool redCrash = false;

            int[] bluePosition = new int[] { x / 2, y / 2, z };

            bool blueCrash = false;

            for (int instruction = 0; instruction < moveRed.Length; instruction++)
            {
                if (moveRed[instruction] == 'L')
                {
                    CalculateRedDirection('L');
                }
                else if (moveRed[instruction] == 'R')
                {
                    CalculateRedDirection('R');
                }


            }


            Console.WriteLine();
        }

        private static void CalculateRedDirection(char instr)
        {
            if (redDirection[0] == 1)
            {
                if (instr == 'L')
                {
                    
                }
                else if (instr == 'R')
                {
                    
                }
            }
        }




    }
}
