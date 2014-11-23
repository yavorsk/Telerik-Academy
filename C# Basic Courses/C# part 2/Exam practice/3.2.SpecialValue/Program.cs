using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2.SpecialValue
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            int[][] rows = new int[N][];

            for (int i = 0; i < N; i++)
            {
                string[] inputRow = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < inputRow.Length; j++)
                {
                    rows[i][j] = int.Parse(inputRow[j]);
                }
            }

            int MaxSpecialValue = int.MinValue;

            for (int i = 0; i < rows[0].Length; i++)
            {
                int currentCol = i;
                int currentRow = 0;
                int pathLength = 1;
                int specialValue = int.MinValue;

                while (true)
                {
                    if (rows[currentRow][currentCol] < 0 )
                    {
                        specialValue = pathLength + Math.Abs(rows[currentRow][currentCol]);

                        if (specialValue > MaxSpecialValue)
                        {
                            MaxSpecialValue = specialValue;
                        }
                        break;
                    }
                    else
                    {
                        if (currentRow < N-1)
                        {
                            currentRow++;
                        }
                        else
                        {
                            currentRow = 0;
                        }

                        currentCol = rows[currentRow][currentCol];
                        pathLength++;
                    }
                }
            }

            Console.WriteLine(MaxSpecialValue);
        }
    }
}
