//2.Write a program to convert binary numbers to their decimal representation.

using System;

class BinaryToDecimal
{
    static int ConvertBinaryToDecimal(string binNum)
    {
        int result = 0;

        for (int i = binNum.Length - 1; i >= 0; i--)
        {
            if (binNum[i] == '1')
            {
                result += (int)Math.Pow(2,binNum.Length - i -1);
            }
        }
        return result;
    }

    static void Main()
    {
        string numBinary = "10011101101101";
        Console.WriteLine(ConvertBinaryToDecimal(numBinary));
    }
}
