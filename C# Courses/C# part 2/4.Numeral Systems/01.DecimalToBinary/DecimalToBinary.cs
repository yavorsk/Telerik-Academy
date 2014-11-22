//1.Write a program to convert decimal numbers to their binary representation.

using System;

class DecimalToBinary
{

    static string ConvertDecimalToBinary(int num)
    {
        string result = string.Empty;
        while (num > 0)
        {
            result = num % 2 + result;
            num = num / 2;            
        }
        return result;
    }
    static void Main()
    {
        int number = 523;
        Console.WriteLine(ConvertDecimalToBinary(number));
    }
}
