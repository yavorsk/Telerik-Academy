using System;

public struct Point3D
{
    // 1. Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. 
    // Implement the ToString() to enable printing a 3D point.
    // 2. Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}. 
    // Add a static property to return the point O.

    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    private static readonly Point3D o = new Point3D { X = 0, Y = 0, Z = 0 };

    public static Point3D O
    { 
        get { return o;}
    }

    public override string ToString()
    {
        string pointToString = string.Format("Point coordinates:X = {0}, Y = {1}, Z = {2};", this.X, this.Y, this.Z);
        return pointToString;
    }
}