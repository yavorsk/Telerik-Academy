using System;

class Test
{
    static void Main()
    {
        Point3D zero = Point3D.O;
        Point3D p1 = new Point3D () { X = 3, Y = 2, Z = 1 };

        Console.WriteLine(Distsnce.CalculateDistance(zero,p1));

        Path chainOfPoints = new Path();
        chainOfPoints.ListOfPoints.Add(zero);
        chainOfPoints.ListOfPoints.Add(p1);
        //chainOfPoints.ClearList();
        PathStorage.PathSave(chainOfPoints, "chain");

        Path loadedPath = PathStorage.PathLoad();
    }
}
