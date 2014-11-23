using System;
using System.IO;

// 4. Create a class Path to hold a sequence of points in the 3D space. 
// Create a static class PathStorage with static methods to save and load paths from a text file. Use a file format of your choice.

static class PathStorage
{
    public static void PathSave(Path listOfPoints, string fileName)
    {
        using (StreamWriter saveFile = new StreamWriter(string.Format(@"..\..\{0}.txt", fileName)))
        {
            foreach (var point in listOfPoints.ListOfPoints)
            {
                saveFile.WriteLine(point.ToString());
            }
        }
    }

    public static Path PathLoad()
    {
        string sourceFile = @"..\..\source.txt";
        Path resultPath = new Path(); 

        using (StreamReader readSource = new StreamReader(sourceFile))
        {
            string line = readSource.ReadLine();
            while (line != null)
            {
                string[] coords = line.Split(new char[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

                Point3D pointEntry = new Point3D() { X = double.Parse(coords[0]), Y = double.Parse(coords[1]), Z = double.Parse(coords[2]) };
                resultPath.AddPoint(pointEntry);

                line = readSource.ReadLine();
            }
        }

        return resultPath;
    }
}
