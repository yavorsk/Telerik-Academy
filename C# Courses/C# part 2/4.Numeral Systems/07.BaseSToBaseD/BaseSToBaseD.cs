// 7. Write a program to convert from any numeral system of given base s to any other 
// numeral system of base d (2 ≤ s, d ≤  16).

using System;

class BaseSToBaseD
{
    static int baseS = 8; //  2<= baseD <= 16
    static int baseD = 16; //  2<= baseD <= 16

    private static int ConvertBaseSTodecimal(string numBaseS)
    {
        int result = 0;
        int baseSDigit = 0;

        for (int i = numBaseS.Length - 1; i >= 0; i--)
        {
            switch (numBaseS[i])
            {
                case 'A': baseSDigit = 10; break;
                case 'B': baseSDigit = 11; break;
                case 'C': baseSDigit = 12; break;
                case 'D': baseSDigit = 13; break;
                case 'E': baseSDigit = 14; break;
                case 'F': baseSDigit = 15; break;
                default: baseSDigit = int.Parse(numBaseS[i].ToString()); break;
            }
            result += baseSDigit * ((int)Math.Pow(baseS, numBaseS.Length - i - 1));
        }

        return result;   
    }

    private static string ConvertDecimalToBaseD(int numDeci)
    {
        string result = string.Empty;
        string baseDDigit = string.Empty;

        while (numDeci > 0)
        {
            switch (numDeci % baseD)
            {
                case 10: baseDDigit = "A"; break;
                case 11: baseDDigit = "B"; break;
                case 12: baseDDigit = "C"; break;
                case 13: baseDDigit = "D"; break;
                case 14: baseDDigit = "E"; break;
                case 15: baseDDigit = "F"; break;
                default: baseDDigit = (numDeci % baseD).ToString(); break;
            }
            result = baseDDigit + result;
            numDeci = numDeci / baseD;
        }

        return result;   
    }

    static void Main()
    {
        string numBaseS = "167013";
        int numDeci = ConvertBaseSTodecimal(numBaseS);
        string numBaseD = ConvertDecimalToBaseD(numDeci);

        Console.WriteLine(numBaseD);
    }
}
