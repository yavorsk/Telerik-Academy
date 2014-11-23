using System;

class ModifyNumWithBit
{
    static void Main()
    {
        Console.Write("Please enter random int number: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Please enter bit value (0 or 1): ");
        int v = int.Parse(Console.ReadLine());
        Console.Write("Please enter bit position to be modified: ");
        byte p = byte.Parse(Console.ReadLine());
        if (v == 1)   
        {
            v <<= p;
            n = n | v;
            Console.WriteLine("Modified number: {0}", n);
        }
        else
        {
            v = ~(1 << p);
            n = n & v;
            Console.WriteLine("Modified number: {0}", n);
        }
    }
}
