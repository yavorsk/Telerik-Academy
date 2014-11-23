//5.Write a method that checks if the element at given position in given array of integers 
//is bigger than its two neighbors (when such exist).

using System;

class BiggerThanNeighbours
{
    static bool BiggerThan(int index, int[] arr)
    {
        bool result = false;
        if (index==0 || index==arr.Length-1)
        {
            result = false;
        }
        else
        {
            if (arr[index] > arr[index-1] && arr[index] > arr[index+1])
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
    static void Main()
    {
        int[] inputArr = { 1, 2, 3, 6, 5, 12, -5, 6, 2, 1 };
        Console.Write("Enter the index of element to be checked: ");
        int ind = int.Parse(Console.ReadLine());

        Console.WriteLine(BiggerThan(ind, inputArr));
    }
}
