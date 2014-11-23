//Write a program, that reads from the console an array of N integers and an integer K, 
//sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 

using System;

class LargestLessThanK
{
    static void Main()
    {
        Console.Write("Enter the number of elements in the arra: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Element [{0}]: ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }
        //int[] arr = { 1, 6, 23, -2, -32, 90, 43, -15, 0, 13, 4 };

        Console.Write("Enter integer K: ");
        int k = int.Parse(Console.ReadLine());
        //int k = 82;

        Array.Sort(arr);

        Console.WriteLine(Array.BinarySearch(arr, k));
        if (arr[0]>k)
        {
            Console.WriteLine("There is no element that is less than k!");
        }
        else
        {
            if (Array.BinarySearch(arr, k) >= 0)
            {
                Console.WriteLine(arr[Array.BinarySearch(arr, k)]);
            }
            else
            {
                Console.WriteLine(arr[(~(Array.BinarySearch(arr, k)) - 1)]);
            }
        }
    }
}
