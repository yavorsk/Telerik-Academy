using System;
using System.Linq;

// 6. Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
// Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

class AllDivBy7and3
{
    static void Main()
    {
        int[] sampleArray = { 4, 9, 7, 21, 3, 63, 147, -22, -21, 89 };

        // with lambda expression:
        var divisibleBy3and7 = sampleArray.Where(num => num % 3 == 0 && num % 7 == 0);
        Console.WriteLine("Numbers divisible by 3 and 7:");
        foreach (var num in divisibleBy3and7)
        {
            Console.WriteLine(num);
        }

        Console.WriteLine();

        // with Linq:
        var divisibleBy3and7Linq =
            from num in sampleArray
            where num % 3 == 0 && num % 7 == 0
            select num;
        Console.WriteLine("Numbers divisible by 3 and 7:");
        foreach (var num in divisibleBy3and7Linq)
        {
            Console.WriteLine(num);
        }
    }
}
