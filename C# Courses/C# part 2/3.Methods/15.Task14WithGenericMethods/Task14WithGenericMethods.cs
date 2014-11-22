//*15. Modify your last program and try to make it work for any number type, not just 
// integer (e.g. decimal, float, byte, etc.). Use generic method (read in Internet about generic methods in C#).
using System;
using System.Collections.Generic;

class Task14WithGenericMethods
{
    static void Main()
    {
        dynamic min = Min(3, 20, -2, 0, 15);
        dynamic max = Max(3.13, 56, 9, 48.123, -12, 0, 22);
        dynamic average = Average(3, 5, 9, 11);
        dynamic sum = Sum(2, 3, 8.1, 0, -1, 9);
        dynamic product = Product(2, 3, 4);

        Console.WriteLine("Min: {0}", min);
        Console.WriteLine("Max: {0}", max);
        Console.WriteLine("Average: {0}", average);
        Console.WriteLine("Sum: {0}", sum);
        Console.WriteLine("Product: {0}", product);
    }

    static T Product<T>(params T[] inputNsms)
    {
        dynamic product = 1;
        foreach (var number in inputNsms)
        {
            product *= number;
        }
        return product;
    }

    static T Sum<T>(params T[] inputNums)
    {
        dynamic sum = 0;
        foreach (var number in inputNums)
        {
            sum += number;
        }
        return sum;
    }

    static T Average<T>(params T[] inputNums)
    {
        dynamic sum = 0;
        foreach (var number in inputNums)
        {
            sum += number;
        }
        dynamic average = sum / inputNums.Length;
        return average;
    }

    static T Max<T>(params T[] inputNums)
    {
        dynamic biggest = inputNums[0];
        foreach (var number in inputNums)
        {
            biggest = Math.Max(biggest, number);
        }
        return biggest;
    }

    static T Min<T>(params T[] inputNums)
    {
        dynamic smallest = inputNums[0];
        foreach (var number in inputNums)
        {
            smallest = Math.Min(smallest, number);
        }
        return smallest;
    }
}
