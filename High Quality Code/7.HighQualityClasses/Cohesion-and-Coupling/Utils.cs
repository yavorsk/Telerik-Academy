using System;

namespace CohesionAndCoupling
{
    static class FileUtils
    {
        public static string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return string.Empty;
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            string fileNameWithoutExtension = fileName.Substring(0, indexOfLastDot);
            return fileNameWithoutExtension;
        }
    }

    static class GeometryUtils2D
    {
        private static double width;
        private static double heigth;

        public static double Width 
        {
            get { return width; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Width should be non-negative!");
                }

                width = value;
            }
        }

        public static double Heigth
        {
            get { return heigth; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Heigth should be non-negative!");
                }

                heigth = value;
            }
        }

        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static double CalcDiagonalXY()
        {
            double distance = CalcDistance2D(0, 0, Width, Heigth);
            return distance;
        }
    }

    static class GeometryUtils3D
    {
        private static double width;
        private static double heigth;
        private static double depth;

        public static double Width
        {
            get { return width; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Width should be non-negative!");
                }

                width = value;
            }
        }

        public static double Heigth
        {
            get { return heigth; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Heigth should be non-negative!");
                }

                heigth = value;
            }
        }

        public static double Depth
        {
            get { return depth; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Depth should be non-negative!");
                }

                depth = value;
            }
        }

        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            return distance;
        }

        public static double CalcVolume()
        {
            double volume = Width * Heigth * Depth;
            return volume;
        }

        public static double CalcDiagonalXZ()
        {
            double distance = CalcDistance3D(0, 0, 0, Width, 0, Depth);
            return distance;
        }

        public static double CalcDiagonalXY()
        {
            double distance = CalcDistance3D(0, 0, 0, Width, Heigth, 0);
            return distance;
        }

        public static double CalcDiagonalYZ()
        {
            double distance = CalcDistance3D(0, 0, 0, 0, Heigth, Depth);
            return distance;
        }

        public static double CalcDiagonalXYZ()
        {
            double distance = CalcDistance3D(0, 0, 0, Width, Heigth, Depth);
            return distance;
        }
    }
}