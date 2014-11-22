using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1.DurankulakNums
{
    class Program
    {
        static void Main()
        {
            string durankulakNum = Console.ReadLine();

            List<string> dkDigits = new List<string>();

            for (int i = 0; i < durankulakNum.Length; i++)
            {
                if (char.IsLower(durankulakNum[i]))
                {
                    string digit = durankulakNum[i].ToString() + durankulakNum[i + 1].ToString();
                    dkDigits.Add(digit);
                    i++;
                }
                else
                {
                    dkDigits.Add(durankulakNum[i].ToString());
                }
            }

            long result = 0;

            for (int i = dkDigits.Count - 1; i >= 0; i--)
            {
                result += getDkDigit(dkDigits[i]) * ((long)Math.Pow(168, dkDigits.Count - i - 1));
            }

            Console.WriteLine(result);
        }

        private static int getDkDigit(string dk)
        {
            int result = 0;

            if (dk.Length == 2)
            {
                result = ((int)dk[0] - 96) * 26 + ((int)dk[1] - 65);
            }

            else if (dk.Length == 1)
            {
                result = (int)dk[0] - 65;
            }

            return result;
        }
    }
}
