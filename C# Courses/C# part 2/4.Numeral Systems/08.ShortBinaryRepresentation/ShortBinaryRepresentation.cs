using System;

class ShortBinaryRepresentation
{

    private static string ConvertShortPositiveToBinary(short num)
    {
        string result = string.Empty;
        while (num > 0)
        {
            result = num % 2 + result;
            num = (short)(num / 2);
        }
        return result;
    }

    private static string ConvertShortNegativeToBinary(short num)
    {
        string positiveNum = string.Empty;
        string result = string.Empty;

        num = (short)(num * (-1) - 1);
        positiveNum = ConvertShortPositiveToBinary(num).PadLeft(16, '0');

        for (int i = 0; i < positiveNum.Length; i++)
        {
            if (positiveNum[i] == '0')
            {
                result += "1";
            }
            else
            {
                result += "0";
            }            
        }

        return result;
    }

    static void Main()
    {
        short num = -876;
        string binaryRepresentation = string.Empty;

        if (num >= 0)
        {
            binaryRepresentation = ConvertShortPositiveToBinary(num);
        }
        else
        {
            binaryRepresentation = ConvertShortNegativeToBinary(num);
        }

        Console.WriteLine(binaryRepresentation);
    }
}
