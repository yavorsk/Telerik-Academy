//Write a program that finds all prime numbers in the range [1...10 000 000]. Use the sieve of Eratosthenes algorithm (find it in Wikipedia).
using System;

class SieveOfErathostenes
{
    static void Main()
    {
        bool[] nums = new bool[10000001];

        for (int i = 2; i < Math.Sqrt(nums.Length); i++)
        {
            if (!nums[i])
            {
                for (int j = i*i; j < nums.Length; j=j+i)
                {
                    nums[j] = true;
                }                
            }
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (!nums[i])
            {
                Console.WriteLine(i);
            }
        }
    }
}
