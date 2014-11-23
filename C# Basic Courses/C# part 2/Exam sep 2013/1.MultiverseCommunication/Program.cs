using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.MultiverseCommunication
{
    class Program
    {
        static void Main()
        {
            string inputMessage = Console.ReadLine();

            string[] digits = new string[] { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA"};

            StringBuilder message = new StringBuilder(inputMessage);

            long result = 0;

            while (message.Length > 0)
            {
                for (int i = 0; i < digits.Length; i++)
                {
                    if (message.ToString().StartsWith(digits[i]))
                    {
                        result = result * 13 + i;
                        message.Remove(0, 3);
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
