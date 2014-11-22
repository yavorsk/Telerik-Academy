using System;
using System.Globalization;
using System.Threading;

class Program
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture =CultureInfo.InvariantCulture;

        int n1 = int.Parse(Console.ReadLine());
        int n2 = int.Parse(Console.ReadLine());
        int n3 = int.Parse(Console.ReadLine());
        int n4 = int.Parse(Console.ReadLine());
        int n5 = int.Parse(Console.ReadLine());
        decimal a = decimal.Parse(Console.ReadLine());
        decimal p = decimal.Parse(Console.ReadLine());

        decimal cashInTrays = n1 * 0.05m + n2 * 0.10m + n3 * 0.20m + n4 * 0.5m + n5 * 1.00m;

        if (a >= p && a-p<= cashInTrays)
        {
            decimal change = a - p;
            decimal num = cashInTrays - change;
            Console.WriteLine("Yes {0}", num);
        }
        if (a<p)
        {
            decimal num = p - a;
            Console.WriteLine("More {0}", num);
        }
        if (a >= p && a-p > cashInTrays)
        {
            decimal num = a - p - cashInTrays;
            Console.WriteLine("No {0}", num);            
        }
    }
}
