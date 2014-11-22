using System;

class ExchangeValues
{
    static void Main()
    {
        int a = 5;
        int b = 10;
        Console.WriteLine("The value of a is {0}; the value of a is {1}.", a, b);
        a = a + b;
        b = a - b;
        a = a - b;
        Console.WriteLine("The value of a is {0}; the value of a is {1}.", a, b);
    }
}
