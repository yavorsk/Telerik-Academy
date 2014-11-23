using System;

class OddOrEven
{
    static void Main()
    {
        Console.Write("Please enter a int number: ");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine(num % 2 == 0 ? "The number is even." : "The number is odd.");
    }
}
