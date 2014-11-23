using System;

class Circle : Shape
{
    public Circle(double radius)
        : base(radius * 2, radius * 2)
    { 
    }

    public override double CalculateArea()
    {
        return (this.Width / 2) * (this.Width / 2) * Math.PI;
    }
}
