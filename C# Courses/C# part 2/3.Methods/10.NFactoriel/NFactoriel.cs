//Write a program to calculate n! for each n in the range [1..100]. 
//Hint: Implement first a method that multiplies a number represented as array of digits by given integer number. 

using System;
using System.Collections.Generic;

class NFactoriel
{
    static List<int> MultiplyNumByDigit(List<int> num, int multiplier)
    {
        List<int> result = new List<int>();
        int addTens = 0;

        for (int i = 0; i < num.Count; i++)
        {
            int digitBydigit = num[i] * multiplier + addTens;
            result.Add(digitBydigit%10);
            addTens = digitBydigit / 10;
        }
        if (addTens!=0)
        {
            result.Add(addTens);
        }
        return result;
    }

    static List<int> AddNums(List<int> num1, List<int> num2)
    {
        List<int> result = new List<int>();
        int addTen = 0;
        if (num2.Count > num1.Count)
        {
            return AddNums(num2, num1);
        }

        for (int i = 0; i < num2.Count; i++)
        {
            int digitSum = num1[i] + num2[i]+addTen;
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

        if (num1.Count == num2.Count)
        {
            result.Add(addTen);
            return result;
        }
        else
        {
            for (int i = num2.Count; i < num1.Count; i++)
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
            if (addTen != 0)
            {
                result.Add(addTen);
            }
            return result;
        }
    }

    static List<int> MultiplyNums(List<int> num1, List<int> num2)
    {
        List<int> result = new List<int>();

        if (num2.Count > num1.Count)
        {
            return MultiplyNums(num2,num1);
        }

        for (int i = 0; i < num2.Count; i++)
        {
            List<int> numByDigitResult = MultiplyNumByDigit(num1, num2[i]);
            for (int j = 0; j < i; j++)
            {
                numByDigitResult.Insert(0,0);
            }
            result = AddNums(result,numByDigitResult);
        }
        return result;
    }

    static void PrintArray(List<int> arr)
    {
        arr.Reverse();
        for (int i = 0; i < arr.Count; i++)
        {
            Console.Write(arr[i]);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        int n = 21;
        List<int> factorial = new List<int> { 1 };
        //List<int> inputArr1 = new List<int> { 0, 0, 8, 6, 1, 9, 9, 3 };
        //List<int> inputArr2 = new List<int> { 2, 1 };
        //List<int> input = new List<int> { 5, 6, 8, 4, 5 };
        //int multipl = 5;
        //PrintArray(MultiplyNumByDigit(input, multipl));
        //PrintArray(MultiplyNums(inputArr1, inputArr2));

        for (int i = 2; i <= n; i++)
        {
            List<int> multiplier = new List<int>();
            for (int j = 0; j < i.ToString().Length; j++)
            {
                multiplier.Add((int)((i / Math.Pow(10, j)) % 10));
            }
            factorial = MultiplyNums(factorial, multiplier);
        }

        PrintArray(factorial);
    }
}
