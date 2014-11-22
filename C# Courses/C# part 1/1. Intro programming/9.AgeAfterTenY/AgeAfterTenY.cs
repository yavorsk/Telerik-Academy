using System;

class AgeAfterTenY
{
    static void Main()
    {
        Console.Write("Please enter your current age: ");
        Int32 ageInDecade = Int32.Parse(Console.ReadLine()) + 10;
        Console.WriteLine("After ten years, you will be " + ageInDecade + " years old.");
    }
}