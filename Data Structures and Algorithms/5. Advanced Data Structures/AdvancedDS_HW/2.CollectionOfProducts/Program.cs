using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _2.CollectionOfProducts
{
    class Program
    {
        static void Main()
        {
            OrderedBag<Product> catalog = new OrderedBag<Product>();
            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (int i = 0; i < 500000; i++)
            {
                catalog.Add(new Product("product" + i, (decimal)i));
            }
            sw.Stop();
            Console.WriteLine("Added 500 000 products for {0}", sw.Elapsed);

            sw.Restart();
            for (int i = 0; i < 10000; i++)
            {
                var view = catalog.Range(new Product("", (decimal)(i + 1000)), true, new Product("", (decimal)(i + 10000)), true).Take(20);
            }
            sw.Stop();

            Console.WriteLine("Made 10 000 searches for {0}", sw.Elapsed);
        }
    }
}
