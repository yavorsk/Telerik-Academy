using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1._9GAGNum
{
    class Program
    {
        static int baseS = 9; //  2<= baseD <= 16
        static int baseD = 10; //  2<= baseD <= 16

        private static ulong ConvertBaseSTodecimal(string numBaseS)
        {
            ulong result = 0;
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
                result += (ulong)baseSDigit * ((ulong)Math.Pow(baseS, numBaseS.Length - i - 1));
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
            string nineGagNum = Console.ReadLine();

            StringBuilder nineGag = new StringBuilder();
            nineGag.Append(nineGagNum);

            nineGag.Replace("!!**!-", 8.ToString());
            nineGag.Replace("&*!", 7.ToString());
            nineGag.Replace("*!!!", 6.ToString());
            nineGag.Replace("!-", 5.ToString());
            nineGag.Replace("&-", 4.ToString());
            nineGag.Replace("&&", 3.ToString());
            nineGag.Replace("!!!", 2.ToString());
            nineGag.Replace("**", 1.ToString());
            nineGag.Replace("-!", 0.ToString());


            //Console.WriteLine(nineGag.ToString());

            string numBaseS = nineGag.ToString();
            ulong numDeci = ConvertBaseSTodecimal(numBaseS);
            //string numBaseD = ConvertDecimalToBaseD(numDeci);

            Console.WriteLine(numDeci);
        }
    }
}
