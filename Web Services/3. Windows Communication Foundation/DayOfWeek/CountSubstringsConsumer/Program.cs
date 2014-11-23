using CountSubstringsConsumer.CountSubstringServiceRefference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSubstringsConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            StringCountServiceClient client = new StringCountServiceClient();

            var text = "abra cadabra";
            var substring = "bra";

            var numOfOccurances = client.CountSubstringsInString(text, substring);

            Console.WriteLine(numOfOccurances);
        }
    }
}
