using System;

    class PrimeNumberCheck
    {
        static void Main()
        {
            Console.Write("Please enter a random positive integer number less than 100: ");
            int num = int.Parse(Console.ReadLine());
            bool isPrime = false;
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    isPrime = false;
                    break;
                }
                else
                {
                    isPrime = true;
                }
            }
            Console.WriteLine(isPrime == true || num == 1 || num == 2 ? "The number is prime." : "The number is not prime.");
        }
    }
