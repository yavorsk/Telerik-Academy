//14.Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. 
// Use variable number of arguments.

using System;

class SetOfInts
{
    static void Main()
    {
        int min = Min(3,20,-2,0,15);
        int max = Max(3, 56, 9, 48, -12, 0, 22);
        double average = Average(3, 5, 9, 11);
        int sum = Sum(2, 3, 8, 0, -1, 9);
        int product = Product(2, 3, 4);

        Console.WriteLine("Min: {0}", min);
        Console.WriteLine("Max: {0}", max);
        Console.WriteLine("Average: {0}", average);
        Console.WriteLine("Sum: {0}", sum);
        Console.WriteLine("Product: {0}", product);
    }

    private static int Product(params int[] inputNsms)
    {
        int product = 1;
        foreach (var number in inputNsms)
        {
            product *= number;
        }
        return product;
    }

    private static int Sum(params int[] inputNums)
    {
        int sum = 0;
        foreach (var number in inputNums)
        {
            sum += number;
        }
        return sum;
    }

    private static double Average(params int[] inputNums)
    {
        int sum = 0;
        foreach (var number in inputNums)
        {
            sum += number;
        }
        double average = sum / inputNums.Length;
        return average;
    }

    static int Max(params int[] inputNums)
    {
        int biggest = inputNums[0];
        foreach (var number in inputNums)
        {
            biggest = Math.Max(biggest,number);
        }
        return biggest;
    }

    static int Min(params int[] inputNums)
    {
        int smallest = inputNums[0];
        foreach (var number in inputNums)
        {
            smallest = Math.Min(smallest, number);
        }
        return smallest;
    }
}
