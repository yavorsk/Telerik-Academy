using System;

class PBitCheck
{
    static void Main()
    {
        Console.Write("Please enter random int number: ");
        int v = int.Parse(Console.ReadLine());
        Console.Write("Please enter bit position to be checked: ");
        byte p = byte.Parse(Console.ReadLine());

        bool check = ((v >> p) & 1) == 1;
        Console.Write("Is the {0} bit from right to left of {1} 1? ", p, v);
        Console.WriteLine(check);
    }
}
