using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.LabirynthMAtrix
{
    class LabirynthMAtrix
    {
        static char[,] labyrinth = new char[,]{
                                            {' ', ' ', ' ', '*', ' ', ' ', ' '},
                                            {'*', '*', ' ', '*', ' ', '*', ' '},
                                            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                            {' ', '*', '*', '*', '*', '*', ' '},
                                            {' ', ' ', ' ', '*', ' ', ' ', ' '},
                                            {' ', ' ', ' ', '*', ' ', 'e', ' '},
                                            {' ', '*', '*', '*', '*', '*', ' '},
                                            {' ', ' ', ' ', ' ', ' ', ' ', ' '}
                                        };

        static void Main()
        {
            int startRow = 2;
            int startCol = 2;

            FindPath(startRow, startCol);
        }

        private static void FindPath(int row, int col)
        {
            if (!IsPassable(row,col))
            {
                return;
            }

            if (labyrinth[row,col] == 'e')
            {
                PrintLabyrinth();
            }

            if (labyrinth[row,col] == ' ')
            {
                labyrinth[row, col] = '>';

                FindPath(row, col + 1); // right
                FindPath(row + 1, col); // down
                FindPath(row, col - 1); // left
                FindPath(row - 1, col); // up

                labyrinth[row, col] = ' ';
            }
        }

        private static void PrintLabyrinth()
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    Console.Write(labyrinth[i,j]);
                    Console.Write(" ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(new string('-', 20));
        }

        private static bool IsPassable(int row, int col)
        {
            bool result = true;

            if (row < 0 || labyrinth.GetLength(0) <= row ||
                col < 0 || labyrinth.GetLength(1) <= col ||
                labyrinth[row,col] == '*' ||
                labyrinth[row, col] == '>')
            {
                result = false;
            }

            return result;
        }


    }
}
