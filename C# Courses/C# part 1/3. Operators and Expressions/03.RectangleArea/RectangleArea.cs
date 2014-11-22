using System;

class RectangleArea
{
    static void Main()
    {
        Console.Write("Please enter rectangle's width: ");
        double recWidth = double.Parse(Console.ReadLine());
        Console.Write("Please enter rectangle's heigth: ");
        double recHeigth = double.Parse(Console.ReadLine());
        double recArea = recHeigth * recWidth;
        Console.WriteLine("Rectangle's Area is {0}.", recArea);
    }
}