using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Animal : ISound
{
    public double Age { get; protected set; }
    public string Name { get; protected set; }
    public string Sex { get; protected set; }

    public Animal(double age, string name, string sex)
    {
        this.Age = age;
        this.Name = name;
        this.Sex = sex;
    }

    public abstract void MakeSound();

    public static void AverageAge(List<Animal> animalArr)
    {
        double averageFrogAge = 
            (from animal in animalArr
            where animal.GetType() == typeof(Frog)
            select animal.Age).Average();

        double averageDogAge =
            (from animal in animalArr
             where animal.GetType() == typeof(Dog)
             select animal.Age).Average();

        double averageKittenAge =
            (from animal in animalArr
             where animal.GetType() == typeof(Kitten)
             select animal.Age).Average();

        double averageTomcatAge =
            (from animal in animalArr
             where animal.GetType() == typeof(Tomcat)
             select animal.Age).Average();

        Console.WriteLine("Average frog age: {0}", averageFrogAge);
        Console.WriteLine("Average dog age: {0}", averageDogAge);
        Console.WriteLine("Average kitten age: {0}", averageKittenAge);
        Console.WriteLine("Average tomcat age: {0}", averageTomcatAge);
    }
}
