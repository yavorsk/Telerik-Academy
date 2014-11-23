//3.Write a program to convert decimal numbers to their hexadecimal representation.

using System;

class DecimalToHexadecimal
{
    private static string ConvertDecimalToHexadecimal(int num)
    {
        string result = string.Empty;
        string hexDigit = string.Empty;

        while (num > 0)
        {
            switch (num%16)
            {
                case 10: hexDigit = "A"; break;
                case 11: hexDigit = "B"; break;
                case 12: hexDigit = "C"; break;
                case 13: hexDigit = "D"; break;
                case 14: hexDigit = "E"; break;
                case 15: hexDigit = "F"; break;
                default: hexDigit = (num % 16).ToString(); break;
            }
            result = hexDigit + result;
            num = num / 16;
        }

        return result;        
    }

    static void Main()
    {
        int number = 52396;
        Console.WriteLine(ConvertDecimalToHexadecimal(number));
    }
}
