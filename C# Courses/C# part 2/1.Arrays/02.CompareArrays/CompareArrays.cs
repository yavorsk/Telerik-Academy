//Write a program that reads two arrays from the console and compares them element by element.
using System;

class CompareArrays
{
    static void Main()
    {
        int sizeArr1 = int.Parse(Console.ReadLine());
        int sizeArr2 = int.Parse(Console.ReadLine());
        bool areEqual = false;
        int[] arr1 = new int[sizeArr1];
        int[] arr2 = new int[sizeArr2];

        for (int i = 0; i < sizeArr1; i++)
        {
            Console.Write ("arr1[{0}]: ", i);
            arr1[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < sizeArr2; i++)
        {
            Console.Write("arr2[{0}]: ", i);
            arr2[i] = int.Parse(Console.ReadLine());
        }

        if (sizeArr1 == sizeArr2)
        {
            for (int i = 0; i < sizeArr1; i++)
            {
                if (arr1[i] == arr2[i])
                {
                    areEqual = true;
                }
                else
                {
                    areEqual = false;
                    break;
                }
            }            
        }
        else
        {
            areEqual = false;
        }
        Console.WriteLine("Arrays are equal ---> {0}", areEqual);
    }
}
