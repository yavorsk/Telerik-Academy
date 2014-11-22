//4.Write a program to convert hexadecimal numbers to their decimal representation.

using System;

class HexadecimalToDecimal
{
    private static int ConvertHexadecimalToDecimal(string numHex)
    {
        int result = 0;
        int hexDigit = 0;

        for (int i = numHex.Length - 1; i >= 0; i--)
        {
            switch (numHex[i])
            {
                case 'A': hexDigit = 10; break;
                case 'B': hexDigit = 11; break;
                case 'C': hexDigit = 12; break;
                case 'D': hexDigit = 13; break;
                case 'E': hexDigit = 14; break;
                case 'F': hexDigit = 15; break;
                default: hexDigit = int.Parse(numHex[i].ToString()); break;
            }
            result += hexDigit * ((int)Math.Pow(16, numHex.Length - i - 1));
        }

        return result;
    }

    static void Main()
    {
        string numHexadecimal = "1234ACF";
        Console.WriteLine(ConvertHexadecimalToDecimal(numHexadecimal));
    }

}
