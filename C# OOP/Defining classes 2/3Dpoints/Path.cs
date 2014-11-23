using System;
using System.Collections.Generic;

public class Path
{
    private List<Point3D> listOfPoints = new List<Point3D>();

    public List<Point3D> ListOfPoints
    {
        get { return this.listOfPoints; }
        set { this.listOfPoints = value; }
    }

    public void AddPoint(Point3D point)
    {
        this.listOfPoints.Add(point);
    }

    public void RemovePoint(int index)
    {
        this.listOfPoints.RemoveAt(index);
    }

    public void ClearList()
    {
        this.listOfPoints.Clear();
    }
}