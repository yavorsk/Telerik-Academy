using System;

class Program
{
    static void Main()
    {
        long first = long.Parse(Console.ReadLine());
        long second = long.Parse(Console.ReadLine());
        long third = long.Parse(Console.ReadLine());
        int l = int.Parse(Console.ReadLine());
        int sum = 0;
        int counter = 0;

        for (int i = 1; i <= l; i++)
        {
            sum = sum + i;
        }

        long[] sequence = new long[sum];
        sequence[0] = first;
        sequence[1] = second;
        sequence[2] = third;
        for (int i = 3; i < sequence.Length; i++)
        {
            sequence[i] = sequence[i-1] + sequence[i-2] + sequence[i-3];
        }

        for (int i = 0; i < l; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (j==i)
                {
                    Console.Write(sequence[counter]);
                    counter++;                    
                }
                else
                {
                    Console.Write(sequence[counter] + " ");
                    counter++;                    
                }
            }
            Console.WriteLine();
        }
    }
}
