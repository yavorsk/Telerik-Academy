using System;

class TrapezoidArea
{
    static void Main(string[] args)
    {
        Console.Write("Please enter trapezoid's a side: ");
        double recSideA = double.Parse(Console.ReadLine());
        Console.Write("Please enter trapezoid's b side: ");
        double recSideB = double.Parse(Console.ReadLine());
        Console.Write("Please enter trapezoid's height h: ");
        double recHeight = double.Parse(Console.ReadLine());
        double trapArea = (recSideB + recSideA) * recHeight /2;
        Console.WriteLine("Trapezoid's Area is {0}.", trapArea);
    }
}
