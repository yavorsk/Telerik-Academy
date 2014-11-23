using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace LargeCompany
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderedMultiDictionary<decimal, Article> catalog = new OrderedMultiDictionary<decimal, Article>(false);

            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (int i = 0; i < 5000000; i++)
            {
                var article = new Article(i, "vendor " + i, "title " + i, (decimal)i);

                catalog.Add(article.Price, article);
            }
            sw.Stop();

            Console.WriteLine(sw.Elapsed);

            decimal lowerBound = 10000m;
            decimal higherBound = 100000m;

            sw.Restart();
            catalog.Range(lowerBound, true, higherBound, true);
            sw.Stop();

            Console.WriteLine(sw.Elapsed);
        }
    }
}
