using System;

class Test
{
    static void Main()
    {
        BitArray64 number = new BitArray64(88888);

        Console.WriteLine(number[9]);
        Console.WriteLine(number[46]);

        foreach (var bit in number)
        {
            Console.Write(bit + " ");
        }
    }
}
