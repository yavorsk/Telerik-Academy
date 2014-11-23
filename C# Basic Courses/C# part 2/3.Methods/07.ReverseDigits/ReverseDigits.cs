//Write a method that reverses the digits of given decimal number. Example: 256  652
using System;

class ReverseDigits
{
    static decimal ReverseDigitss(decimal num)
    {
        string str = num.ToString();
        char[] charNum = str.ToCharArray();
        Array.Reverse(charNum);
        str = "";
        for (int i = 0; i < charNum.Length; i++)
        {
            str += charNum[i];
        }
        num = decimal.Parse(str);
        return num;
    }

    static void Main()
    {
        decimal input = -123456789.1234578M;
        Console.WriteLine(input);
        Console.WriteLine(ReverseDigitss(input));
    }
}
