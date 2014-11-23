using System;

namespace Methods
{
    class Methods
    {
        static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Length of the sides of the triangle shold be positive numbers!");
            }
            if (!((a + b > c) && (a + c > b) && (b + c > a)))
            {
                throw new ArgumentException("The given side lengths can not form a triangle!");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentOutOfRangeException("The number should be non-negative and lesser than 10!");
            }
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("The input array is null!");
            }
            if (elements.Length == 0)
            {
                throw new ArgumentException("The input array is empty!");
            }

            int maxElement = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }
            return maxElement;
        }

        static void PrintAsNumber(object number, string format) // format should be enumeration; or split the method into three smaller methods;
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
            else
            {
                throw new ArgumentException("Invalid format!");
            }
        }

        static bool IsHorizontal(double y1, double y2)
        {
            bool isHorizontal = y1 == y2;

            return isHorizontal;
        }

        static bool IsVertical(double x1, double x2)
        {
            bool isVertical = x1 == x2;

            return isVertical;
        }

        static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            if (x1 == x2 && y1 == y2)
            {
                throw new ArgumentException("The two points coincide!");
            }

            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            return distance;
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(NumberToDigit(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + IsHorizontal(3,3));
            Console.WriteLine("Vertical? " + IsVertical(-1,2.5));

            //------
            Student peter = new Student("Peter", "Ivanov", "17.03.1992");
            peter.HomeTown = "Sofia";

            Student stella = new Student("Stella", "Markova", "03.11.1993");
            stella.HomeTown = "Vidin";
            stella.Hobby = "gamer";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
