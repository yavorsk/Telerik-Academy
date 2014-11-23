using System;

class Frog : Animal
{
    public Frog(double age, string name, string sex) : base(age, name, sex)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Kva-Kva");
    }
}
