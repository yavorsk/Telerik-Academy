//Write a program to convert hexadecimal numbers to binary numbers (directly).

using System;

class HexadecimalToBinary
{
    private static string ConvertHexadecimalToBinary(string numHex)
    {
        string numBin = string.Empty;
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

            numBin = (i == 0) ? Convert.ToString(hexDigit, 2) + numBin :
                                Convert.ToString(hexDigit, 2).PadLeft(4, '0') + numBin ;
        }

        return numBin;
    }

    static void Main()
    {
        string numHexadecimal = "14ACF";
        Console.WriteLine(ConvertHexadecimalToBinary(numHexadecimal));
    }
}
