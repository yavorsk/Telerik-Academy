using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.LargestEmptyArea
{
    class LargestEmptyArea
    {
        static char[,] matrix = new char[,]{
                                            {' ', ' ', ' ', '*', ' ', ' ', ' '},
                                            {'*', '*', ' ', '*', ' ', '*', ' '},
                                            {' ', ' ', ' ', '*', ' ', ' ', ' '},
                                            {' ', '*', '*', '*', '*', '*', '*'},
                                            {' ', ' ', ' ', '*', ' ', ' ', ' '},
                                            {' ', ' ', ' ', '*', ' ', '*', ' '},
                                            {' ', '*', '*', '*', '*', '*', ' '},
                                            {' ', '*', ' ', ' ', ' ', ' ', ' '}
                                        };


        static Dictionary<int, int> areas = new Dictionary<int, int>();

        static void Main()
        {
            int areaNumber = 1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int areaSize = 0;

                    if (matrix[i,j] == ' ')
                    {
                        CalculateArea(i, j, areaNumber, ref areaSize);

                        areas.Add(areaNumber, areaSize);

                        areaNumber++;
                    }
                }
            }

            PrintMatrix();

            Console.WriteLine();

            foreach (var pair in areas)
            {
                Console.WriteLine("Area N {0} has size of {1}", pair.Key, pair.Value);
            }

            Console.WriteLine();

            Console.WriteLine("The max area has size of {0}", areas.Values.Max());
            
        }

        private static void CalculateArea(int row, int col, int areaNumber, ref int areaSize)
        {
            if (!IsPassable(row, col))
            {
                return;
            }

            if (matrix[row, col] == ' ')
            {
                matrix[row, col] = (char)areaNumber;
                areaSize++;

                CalculateArea(row, col + 1, areaNumber, ref areaSize); // right
                CalculateArea(row + 1, col, areaNumber, ref areaSize); // down
                CalculateArea(row, col - 1, areaNumber, ref areaSize); // left
                CalculateArea(row - 1, col, areaNumber, ref areaSize); // up
            }
        }

        private static bool IsPassable(int row, int col)
        {
            bool result = true;

            if (row < 0 || matrix.GetLength(0) <= row ||
                col < 0 || matrix.GetLength(1) <= col ||
                matrix[row, col] == '*' ||
                matrix[row, col] == '>')
            {
                result = false;
            }

            return result;
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                    Console.Write(" ");
                }

                Console.WriteLine();
            }
        }
    }
}
