using System;

public abstract class Cat : Animal
{
    public Cat(double age, string name, string sex) 
        : base (age,name,sex)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Myauu");
    }
}
