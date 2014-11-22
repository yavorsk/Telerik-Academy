using System;

class Program
{
    static void Main()
    {
        string input = "1, 3, -6, 7, 4 ,1, 12"; //Console.ReadLine();

        char[] cDividers = { ',', ' ' };
        string[] segments = input.Split(cDividers,StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < segments.Length; i++)
        {
            Console.WriteLine(segments[i]);
        }
        int[] valley = new int[segments.Length];
        //int m = int.Parse(Console.ReadLine());


        for (int i = 0; i < segments.Length; i++)
        {
            if (segments[i].Length > 0)
            {
                valley[i] = int.Parse(segments[i]);
            }
        }

        for (int i = 0; i < valley.Length; i++)
        {
            Console.WriteLine(valley[i]);
        }
    }
}
