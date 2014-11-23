using System;

class Program
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        int e = int.Parse(Console.ReadLine());

        int[] arr = new int[5] { a, b, c, d, e };
        Array.Sort(arr);
        int divCount = 0;
        int num = 0;

        for (int i = arr[2]; i <= arr[4] * arr[3] * arr[2]; i++)
        {
            for (int j = 0; j < arr.Length; j++)
            {
                if (i % arr[j] == 0)
                {
                    divCount++;
                }
            }
            if (divCount > 2)
            {
                num = i;
                break;
            }
            else
            {
                divCount = 0;
            }
        }
        Console.WriteLine(num);
    }
}
