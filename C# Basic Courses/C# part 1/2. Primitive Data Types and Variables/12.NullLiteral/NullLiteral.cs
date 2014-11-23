using System;

class NullLiteral
{
    static void Main()
    {
        int? intVar = null;
        double? doubleVar = null;
        Console.WriteLine("intVar= {0}", intVar);
        Console.WriteLine("doubleVar= {0}", doubleVar);
        intVar += 7;
        doubleVar += 7;
        Console.WriteLine("intVar= {0}", intVar);
        Console.WriteLine("doubleVar= {0}", doubleVar);
    }
}
