using System;

class PointWithinCircle
{
    static void Main()
    {
        Console.Write("Please enter the X coodrinate of the point: ");
        float xCoord = float.Parse(Console.ReadLine());
        Console.Write("Please enter the Y coodrinate of the point: ");
        float yCoord = float.Parse(Console.ReadLine());
        Console.WriteLine(Math.Sqrt(xCoord * xCoord + yCoord * yCoord) <= 5 ? "The point is within the circle." 
                                                                            : "The point is out of the circle.");
    }
}
