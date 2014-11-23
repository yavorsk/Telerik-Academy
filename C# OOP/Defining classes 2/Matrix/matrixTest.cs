using System;

class MatrixTest
{
    static void Main()
    {
        Matrix<int> arr1 = new Matrix<int>(3, 2);
        arr1[0, 0] = 1;
        arr1[0, 1] = 3;
        arr1[1, 0] = 0;
        arr1[1, 1] = -2;
        arr1[2, 0] = 4;
        arr1[2, 1] = 1;
        
        Matrix<int> arr2 = new Matrix<int>(2, 2);
        arr2[0, 0] = 7;
        arr2[0, 1] = 9;
        arr2[1, 0] = 5;
        arr2[1, 1] = 2;

        Matrix<int> result = arr1 * arr2;

        Console.WriteLine(result.ToString());
    }
}
