//Write a program to convert binary numbers to hexadecimal numbers (directly).

using System;

class BinaryToHexadecimal
{

    static string ConvertBinaryToHexadecimal(string numBin)
    {
        numBin = numBin.PadLeft(((numBin.Length / 4 + 1) * 4), '0'); // adds leading zeros, so that the length of the strings divides by 4 without a remainder
        string numHex = string.Empty;
        string digitHex = string.Empty;

        for (int i = 0; i < numBin.Length; i+=4)
        {
            switch (numBin.Substring(i,4))
            {
                case "0000" : digitHex = "0"; break;
                case "0001" : digitHex = "1"; break;
                case "0010" : digitHex = "2"; break;
                case "0011" : digitHex = "3"; break;
                case "0100" : digitHex = "4"; break;
                case "0101" : digitHex = "5"; break;
                case "0110" : digitHex = "6"; break;
                case "0111" : digitHex = "7"; break;
                case "1000" : digitHex = "8"; break;
                case "1001" : digitHex = "9"; break;
                case "1010" : digitHex = "A"; break;
                case "1011" : digitHex = "B"; break;
                case "1100" : digitHex = "C"; break;
                case "1101" : digitHex = "D"; break;
                case "1110" : digitHex = "E"; break;
                case "1111": digitHex = "F"; break;
            }

            numHex = numHex + digitHex;
        }

        return numHex;
    }

    static void Main()
    {
        string numBinary = "10011101101101";
        Console.WriteLine(ConvertBinaryToHexadecimal(numBinary));
    }
}
