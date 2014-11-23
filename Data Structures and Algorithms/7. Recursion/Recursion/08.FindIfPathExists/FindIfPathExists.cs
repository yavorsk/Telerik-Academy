using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.LabirynthMAtrix
{
    class FindIfPathExists
    {
        static char[,] labyrinth = new char[100, 100];

        static void Main()
        {
            int startRow = 0;
            int startCol = 0;

            GenerateLabyrinth();

            bool pathFound = false;

            FindPath(startRow, startCol, ref pathFound);

            Console.WriteLine("Path found --> {0}", pathFound);
        }

        private static void FindPath(int row, int col, ref bool pathFound)
        {
            if (pathFound)
            {
                return;
            }

            if (!IsPassable(row, col))
            {
                return;
            }

            if (labyrinth[row, col] == 'e')
            {
                pathFound = true;
            }

            if (labyrinth[row, col] == ' ')
            {
                labyrinth[row, col] = '>';

                FindPath(row, col + 1, ref pathFound); // right
                FindPath(row + 1, col, ref pathFound); // down
                FindPath(row, col - 1, ref pathFound); // left
                FindPath(row - 1, col, ref pathFound); // up

                labyrinth[row, col] = ' ';
            }
        }

        private static bool IsPassable(int row, int col)
        {
            bool result = true;

            if (row < 0 || labyrinth.GetLength(0) <= row ||
                col < 0 || labyrinth.GetLength(1) <= col ||
                labyrinth[row, col] == '*' ||
                labyrinth[row, col] == '>')
            {
                result = false;
            }

            return result;
        }

        private static void GenerateLabyrinth()
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    labyrinth[i, j] = ' ';
                }
            }

            labyrinth[labyrinth.GetLength(0) - 1, labyrinth.GetLength(1) - 1] = 'e';
        }
    }
}
