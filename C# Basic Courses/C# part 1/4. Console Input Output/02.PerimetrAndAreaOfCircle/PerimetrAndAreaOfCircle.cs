using System;

class PerimetrAndAreaOfCircle
{
    static void Main()
    {
        Console.WriteLine("Enter the radius of the circle: ");
        double r = double.Parse(Console.ReadLine());
        double perimeter = 2 * Math.PI * r;
        double area = Math.PI * r * r;
        Console.WriteLine("The perimeter of the circle is {0}.", perimeter);
        Console.WriteLine("The area of the circle is {0}.", area);
    }
}

