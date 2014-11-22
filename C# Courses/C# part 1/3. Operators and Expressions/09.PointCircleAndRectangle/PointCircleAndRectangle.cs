using System;

class PointCircleAndRectangle
{
    static void Main()
    {
        Console.Write("Please enter the X coodrinate of the point: ");
        float xCoord = float.Parse(Console.ReadLine());
        Console.Write("Please enter the Y coodrinate of the point: ");
        float yCoord = float.Parse(Console.ReadLine());
        // withinCircle returns true if the point is within the circle:
        bool withinCircle = Math.Sqrt((xCoord - 1) * (xCoord - 1) + (yCoord - 1) * (yCoord - 1)) <= 3;
        // outOfRect returns true if the point is out of the rectangle:
        bool outOfRect = !((xCoord >= -1 && xCoord <= 5) && (yCoord >= -1 && yCoord <= 1));
        Console.WriteLine(withinCircle && outOfRect ? "The point is within the circle and out of the rectangle."
                                                    : "The point is NOT within the circle and out of the rectangle.");
    }
}
