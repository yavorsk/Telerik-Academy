using System;

class QuadraticEquation
{
    static void Main()
    {
        Console.Write("Please enter quadratic coefficient a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Please enter linear coefficient b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Please enter constant term c: ");
        double c = double.Parse(Console.ReadLine());
        double determinant = b * b - 4 * a * c;
        if (determinant < 0)
        {
            Console.WriteLine("The equation has no real roots.");
        }
        else
        {
            if (determinant == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine("The root of the equation is x={0}.", x);
            }
            else
            {
                double x1 = (-b + Math.Sqrt(determinant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(determinant)) / (2 * a);
                Console.WriteLine("The roots of the equation are x1={0} and x2={1}.", x1, x2);
            }
        }
    }
}
