using System;

class FibonacciSequence
{
    static void Main()
    {
        decimal fiMember = 1m;
        decimal fiPrevMember = 0m;
        Console.WriteLine(fiPrevMember);
        Console.WriteLine(fiMember);
        for (int i = 0; i < 98; i++)
        {
            fiMember = fiMember + fiPrevMember;
            Console.WriteLine(fiMember);
            fiPrevMember = fiMember - fiPrevMember;
        }
    }
}
