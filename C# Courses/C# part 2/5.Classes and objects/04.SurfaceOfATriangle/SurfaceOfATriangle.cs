//4. Write methods that calculate the surface of a triangle by given:
//Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.

using System;

class SurfaceOfATriangle
{
    static double CalculateSurfaceOfTriangle(double sideA, double altitude)
    { 
        double area = sideA * altitude / 2;
        return area;
    }

    static double CalculateSurfaceOfTriangle(double sideA, double sideB, double sideC)
    {
        double p = (sideA + sideB + sideC) / 2;
        double area = Math.Sqrt(p*(p - sideA)*(p-sideB)*(p-sideC));
        return area;
    }

    static double CalculateSurfaceOfTriangle(double sideA, double sideB, float angle)
    {
        double angleInRads = angle * Math.PI / 180;
        double area = (sideA * sideB * Math.Sin(angleInRads)) / 2;
        return area;
    }

    static void Main()
    {
        double sideA = 88.6618;
        double sideB = 90.5386;
        double sideC = 51.113;
        float angleAB = 33.1238f;
        double altitudeToA = 49.4748;

        Console.WriteLine(CalculateSurfaceOfTriangle(sideA,altitudeToA));
        Console.WriteLine(CalculateSurfaceOfTriangle(sideA,sideB,sideC));
        Console.WriteLine(CalculateSurfaceOfTriangle(sideA,sideB,angleAB));
    }
}
