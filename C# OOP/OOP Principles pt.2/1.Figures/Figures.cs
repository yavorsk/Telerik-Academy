using System;
using System.Collections.Generic;

// 1. Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height. 
// Define two new classes Triangle and Rectangle that implement the virtual method and return 
// the surface of the figure (height*width for rectangle and height*width/2 for triangle). 
// Define class Circle and suitable constructor so that at initialization height must be kept equal to width and 
// implement the CalculateSurface() method. Write a program that tests the behavior of  the CalculateSurface() method for 
// different shapes (Circle, Rectangle, Triangle) stored in an array.

class Figures
{
    static void Main()
    {
        List<Shape> figures = new List<Shape>() 
        {
            new Rectangle(2.5, 2),
            new Triangle(2.5, 2),
            new Circle(1.5)
        };

        foreach (var figure in figures)
        {
            Console.WriteLine(figure.CalculateArea());
        }
    }
}
