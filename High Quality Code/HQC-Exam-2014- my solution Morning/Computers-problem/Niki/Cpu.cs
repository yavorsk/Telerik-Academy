namespace ComputersBuildingSystem
{
    using System;

    public class Cpu
    {
        private const string NumberTooLowMessage = "Number too low.";
        private const string NumberTooHighMessage = "Number too high.";

        private readonly Random random = new Random();

        public Cpu(byte numberOfCores, byte numberOfBits)
        {
            this.CpuBits = numberOfBits;
            this.NumberOfCores = numberOfCores;
        }

        public byte CpuBits { get; private set; }

        public byte NumberOfCores { get; private set; }

        public string SquareNumber(int number)
        {
            if (this.CpuBits == 32)
            {
                return this.SquareNumber32(number);
            }
            else if (this.CpuBits == 64)
            {
                return this.SquareNumber64(number);
            }
            else if (this.CpuBits == 128)
            {
                return this.SquareNumber128(number);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public int GetRandomNumber(int a, int b)
        {
            int randomNumber = this.random.Next(a, b);

            // bottle neck this can lead to too many itereations
            // do
            // {
            //     randomNumber = Random.Next(0, 1000);
            // }
            // while (!(randomNumber >= a && randomNumber <= b));
            return randomNumber;
        }

        private string SquareNumber32(int number)
        {
            if (number < 0)
            {
                return NumberTooLowMessage;
            }
            else if (number > 500)
            {
                return NumberTooHighMessage;
            }
            else
            {
                int result = number * number;

                // bottleneck and bug:
                // for (int i = 0; i < number; i++)
                // {
                //     value += number;
                // }
                return string.Format("Square of {0} is {1}.", number, result);
            }
        }

        private string SquareNumber64(int number)
        {
            if (number < 0)
            {
                return NumberTooLowMessage;
            }
            else if (number > 1000)
            {
                return NumberTooHighMessage;
            }
            else
            {
                int result = number * number;

                // bottleneck and bug:
                // for (int i = 0; i < number; i++)
                // {
                //     value += number;
                // }
                return string.Format("Square of {0} is {1}.", number, result);
            }
        }

        private string SquareNumber128(int number)
        {
            if (number < 0)
            {
                return NumberTooLowMessage;
            }
            else if (number > 2000)
            {
                return NumberTooHighMessage;
            }
            else
            {
                int result = number * number;

                // bottleneck and bug:
                // for (int i = 0; i < number; i++)
                // {
                //     value += number;
                // }
                return string.Format("Square of {0} is {1}.", number, result);
            }
        }
    }
}
