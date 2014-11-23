using System;

class MatrixNbyN
{
    static void Main()
    {
        Console.Write("Number of rows and columns: ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];

        // a):
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = row + 1 + col * n;
                Console.Write("{0,3}", matrix[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        // b):
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (col % 2 == 1)
                {
                    matrix[row, col] = col * n + n - row;
                    Console.Write("{0,3}", matrix[row, col]);
                }
                else
                {
                    matrix[row, col] = row + 1 + col * n;
                    Console.Write("{0,3}", matrix[row, col]);
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        //c):
        int counter = 1;
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col <= row; col++)
            {
                matrix[n-1  - row + col, col] = counter++ ;
            }
        }
        for (int row = n-2; row >= 0; row--)
        {
            for (int col = row; col >= 0; col--)
            {
                matrix[row-col, n-col-1] = counter++ ;
            }
        }

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                    Console.Write("{0,3}", matrix[row, col]);                  
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        //d):
        int roww = 0;
        int coll = 0;
        counter = 1;

        while (counter <= n*n ) // n*n
        {
            for (int i = roww; i < n - roww; i++)  //assign matrix elements from downward
            {
                matrix[i, coll] = counter++;
            }
            for (int i = coll + 1; i < n - coll; i++)  //assign matrix elements from left to right
            {
                matrix[n - 1 - roww, i] = counter++;
            }
            for (int i = n - 2 - roww; i >= roww; i--)  //assign matrix elements upwards
            {
                matrix[i,n - 1 - coll] = counter++;
            }
            for (int i = n - 2 - coll; i >= coll + 1; i--)   //assign matrix elements from right to left
            {
                matrix[roww, i] = counter++;
            }
            roww++;
            coll++;
        }

        for (int i = 0; i < n; i++)  //print the matrix
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0,3}", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}
