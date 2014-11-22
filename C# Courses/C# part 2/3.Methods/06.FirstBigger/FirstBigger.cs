//Write a method that returns the index of the first element in array that is bigger than its neighbors, 
//or -1, if there’s no such element. Use the method from the previous exercise.
using System;

class FirstBigger
{
    static bool BiggerThan(int index, int[] arr)
    {
        bool result = false;
        if (index == 0 || index == arr.Length - 1)
        {
            result = false;
        }
        else
        {
            if (arr[index] > arr[index - 1] && arr[index] > arr[index + 1])
            {
                result = true;
            }
            else
            {
                result = false;
            }
        }
        return result;
    }

    static int FirstBiggerThan(int[] arr)
    {
        int result = 0;

        for (int i = 1; i < arr.Length-1; i++)
        {
            if (BiggerThan(i, arr))
            {
                result = i;
                break;
            }
            else
            {
                result = -1;
            }
        }
        return result;
    }

    static void Main()
    {
        int[] inputArr = { 1, 2, 3, 6, 5, 12, -5, 6, 2, 1 };

        Console.WriteLine(FirstBiggerThan(inputArr));
    }
}
