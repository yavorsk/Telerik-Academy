//Write a method that adds two positive integer numbers represented as arrays of digits 
//(each array element arr[i] contains a digit; the last digit is kept in arr[0]). 
//Each of the numbers that will be added could have up to 10 000 digits.

using System;
using System.Collections.Generic;

class AddNumbers
{
    static List<int> AddNums(int[] num1, int[] num2)
    {
        List<int> result = new List<int>();
        int addTen = 0;
        if (num2.Length > num1.Length)
        {
            return AddNums(num2, num1);
        }

        for (int i = 0; i < num2.Length; i++)
        {
            int digitSum = num1[i] + num2[i] + addTen;
            if (digitSum < 10)
            {
                result.Add(digitSum);
                addTen = 0;
            }
            else
            {
                result.Add(digitSum % 10);
                addTen = 1;
            }
        }

        if (num1.Length == num2.Length)
        {
            result.Add(addTen);
            return result;
        }
        else
        {
            for (int i = num2.Length; i < num1.Length; i++)
            {
                if (num1[i] + addTen < 10)
                {
                    result.Add(num1[i] + addTen);
                    addTen = 0;                    
                }
                else
                {
                    result.Add(0);
                    addTen = 1;
                }
            }
            if (addTen!=0)
            {
                result.Add(addTen);
            }
            return result;
        }

    }

    static void PrintArray(List<int> arr)
    {
        arr.Reverse();
        for (int i = 0; i < arr.Count; i++)
        {
            Console.Write((i == arr.Count - 1) ? arr[i] + "": (arr[i] + " "));
        }
        Console.WriteLine();
    }

    static void Main()
    {
        //int[] inputArr1 = { 1, 2, 3, 6, 5, 2, 0, 6, 1, 3 };
        //int[] inputArr2 = { 8, 2, 5, 7, 1, 0, 7, 4, 5, 6, 8, 4, 4, 5, 4, 3, 2, 6, 8, 1, 2, 8 };
        int[] inputArr1 = { 9, 9, 9};
        int[] inputArr2 = { 1, 1 };

        PrintArray(AddNums(inputArr1, inputArr2));
    }
}
