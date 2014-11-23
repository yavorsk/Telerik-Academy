using System;

class Dog : Animal
{
    public Dog(double age, string name, string sex)
        : base(age, name, sex)
    { 
    }

    public override void MakeSound()
    {
        Console.WriteLine("Bau-Bau");
    }
}