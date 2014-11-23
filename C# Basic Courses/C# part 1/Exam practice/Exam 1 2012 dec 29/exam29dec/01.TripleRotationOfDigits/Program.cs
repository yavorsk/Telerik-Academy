using System;


class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        int numLength = new int();
        string lastdigit;

        for (int i = 0; i < 3; i++)
        {
            numLength = input.Length;
            lastdigit = input.Substring(numLength - 1, 1);
            input = input.Remove(numLength - 1, 1);
            if (lastdigit != "0")
            {
                input = input.Insert(0, lastdigit);                    
            }       
        }
        Console.WriteLine(input);         
    }
}
