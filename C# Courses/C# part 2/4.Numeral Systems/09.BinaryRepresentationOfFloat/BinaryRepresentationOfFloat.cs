// 9* Write a program that shows the internal binary representation of given 32-bit signed floating-point number in 
// IEEE 754 format (the C# type float). Example: -27,25  sign = 1, exponent = 10000011, 
// mantissa = 10110100000000000000000.

using System;
// http://en.wikipedia.org/wiki/Single-precision_floating-point_format helped me a lot for this task
class BinaryRepresentationOfFloat
{
    static string ConvertDecimalToBinary(int num)
    {
        string result = "";
        if (num==0)
        {
            return "0";
        }
        else
        {
            while (num > 0)
            {
                result = num % 2 + result;
                num = num / 2;
            }
            return result.PadLeft(8, '0');
        }
    }

    private static string GetBinaryFractionalPart(float fractional)
    {
        int intPart;
        string result = string.Empty;

        while (true)
        {
            intPart = (int)(fractional * 2f);
            fractional = (fractional * 2f) - (int)(fractional * 2f);
            result += intPart.ToString();
            if (fractional == 0f)
            {
                break;
            }
        }

        return result;
    }

    private static string ConvertNegativeDecimalToBinary(int num)
    {
        string positiveNum = string.Empty;
        string result = string.Empty;

        num = (num * (-1) - 1);
        positiveNum = ConvertDecimalToBinary(num).PadLeft(8, '0');

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
        //float num = 0.15625f;
        float num = -27.25f;
        //float num = 12.375;

        string sign = num > 0 ? "0" : "1";

        string integerPart = ConvertDecimalToBinary((int)Math.Abs(num));

        float fractional = Math.Abs(num) - (int)Math.Abs(num);
        string fractionalPart = GetBinaryFractionalPart(fractional);

        string exponentPart = string.Empty;
        if (integerPart != "0")
        {
            int exponent = integerPart.Length - 1 + 127;
            exponentPart = ConvertDecimalToBinary(exponent);         
        }
        else
        {
            int exponent = 127 - (fractionalPart.IndexOf("1") + 1);
            exponentPart = ConvertDecimalToBinary(exponent);
            fractionalPart = fractionalPart.Substring(fractionalPart.IndexOf("1")+1);
        }

        string mantissa = (integerPart.Substring(1, integerPart.Length - 1) + fractionalPart).PadRight(23, '0');

        string binaryRepresentation = sign + exponentPart + mantissa;

        Console.WriteLine("sign: {0}", sign);
        Console.WriteLine("exponent part: {0}", exponentPart);
        Console.WriteLine("mantissa: {0}", mantissa);
        Console.WriteLine(binaryRepresentation);
    }
}
