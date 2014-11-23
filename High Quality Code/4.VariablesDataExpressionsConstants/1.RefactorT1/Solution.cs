using System;

class Solution
{
    public class Size
    {
        public Size(double width, double heigth)
        {
            this.Width = width;
            this.Heigth = heigth;
        }

        public double Width { get; set; }

        public double Heigth { get; set; }
    }

    public static Size GetRotatedSize(Size sizeOfFigure, double angleOfRotation)
    {
        double projectedWidthForWitdth = Math.Abs(Math.Cos(angleOfRotation)) * sizeOfFigure.Width;
        double projectedHeigthForWidth = Math.Abs(Math.Sin(angleOfRotation)) * sizeOfFigure.Heigth;
        double widthOfRotated = projectedWidthForWitdth + projectedHeigthForWidth;

        double projectedWidthForHeigth = Math.Abs(Math.Sin(angleOfRotation)) * sizeOfFigure.Width;
        double projectedHeigthForHeigth = Math.Abs(Math.Cos(angleOfRotation)) * sizeOfFigure.Heigth;
        double heigthOfRotated = projectedWidthForHeigth + projectedHeigthForHeigth;

        Size sizeOfRotated = new Size(widthOfRotated, heigthOfRotated);

        return sizeOfRotated;
    }
}
