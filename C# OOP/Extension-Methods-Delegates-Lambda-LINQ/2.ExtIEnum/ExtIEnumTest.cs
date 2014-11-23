using System;
using System.Collections.Generic;
using System.Linq;

class ExtIEnumTest
{
    static void Main()
    {
        List<double> arr = new List<double> () { 23.15, 3, 0, 0.5, -13.3};
        List<int> arr2 = new List<int>() { 2, 3, 6, 8 };

        Console.WriteLine(arr.Sum());
        Console.WriteLine(arr.Min());
        Console.WriteLine(arr.Max());
        Console.WriteLine(arr.Average());
        Console.WriteLine(arr2.Average());
    }
}
