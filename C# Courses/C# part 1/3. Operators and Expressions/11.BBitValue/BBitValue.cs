using System;

class BBitValue
{
    static void Main()
    {
        Console.Write("Please enter random int number: ");
        int i = int.Parse(Console.ReadLine());
        Console.Write("Please enter bit position to be evaluated: ");
        byte b = byte.Parse(Console.ReadLine());
        byte value = ((i >> b) & 1) == 1 ? (byte) 1 : (byte) 0;
        Console.WriteLine("The value of the {0} bit from right to left of {1} is {2}.", b, i, value);
    }
}
