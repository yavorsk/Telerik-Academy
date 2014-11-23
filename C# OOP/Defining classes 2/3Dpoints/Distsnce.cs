using System;

// 3. Write a static class with a static method to calculate the distance between two points in the 3D space.

static class Distsnce
{
    public static double CalculateDistance(Point3D point1, Point3D point2)
    {
        double hypoXY = Math.Sqrt(Math.Pow(Math.Abs(point1.X - point2.X), 2) + Math.Pow(Math.Abs(point1.Y - point2.Y), 2));
        double distance = Math.Sqrt(Math.Pow(Math.Abs(point1.Z - point2.Z), 2) + Math.Pow(hypoXY, 2));
        return distance;
    }
}
