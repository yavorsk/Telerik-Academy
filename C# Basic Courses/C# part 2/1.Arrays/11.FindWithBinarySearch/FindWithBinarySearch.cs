//Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm 
//(find it in Wikipedia).

using System;

class FindWithBinarySearch
{
    static void Main()
    {
        Console.Write("Enter value: ");
        int target = int.Parse(Console.ReadLine());
        int[] arr = new int[15] { -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        int startIndex = 0;
        int endIndex = arr.Length - 1;

        while (startIndex<=endIndex)
        {
            int middleIndex = (startIndex + endIndex) / 2;
            if (arr[middleIndex] == target)
            {
                Console.WriteLine("The index of the value in the array is {0}.", middleIndex);
                break;
            }
            else if (arr[middleIndex] > target)
            {
                endIndex = middleIndex-1;
            }
            else if (arr[middleIndex] < target)
            {
                startIndex = middleIndex+1;
            }            
        }
    }
}
