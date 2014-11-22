//4.Write a method that counts how many times given number appears in given array. 
//Write a test program to check if the method is working correctly.
using System;

public class FrequencyOfAppearance
{
    public static int NumOfAppearance(int n, int[] arr)
    {
        int counter = 0;
        foreach (var number in arr)
        {
            if (n == number)
            {
                counter++;
            }
        }
        return counter;
    }
    static void Main()
    {
        Console.Write("Enter length of the array: ");
        int arrLength = int.Parse(Console.ReadLine());
        int[] array = new int[arrLength];
        for (int i = 0; i < arrLength; i++)
        {
            Console.Write("Enter element {0}: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        Console.Write("Enter number to check its appearrance in the array: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("The number {0} appears {1} times in the array.", number, NumOfAppearance(number, array));
    }
}
