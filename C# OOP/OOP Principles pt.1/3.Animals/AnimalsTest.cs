using System;
using System.Collections.Generic;

// 3.Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods. 
// Dogs, frogs and cats are Animals. All animals can produce sound (specified by the ISound interface). 
// Kittens and tomcats are cats. All animals are described by age, name and sex. 
// Kittens can be only female and tomcats can be only male. Each animal produces a specific sound. 
// Create arrays of different kinds of animals and calculate the average age of each kind of animal using a static method (you may use LINQ).

class AnimalsTest
{
    static void Main()
    {
        List<Animal> animals = new List<Animal>
        {
            new Dog(6, "Lassie", "female"),
            new Frog(9, "Kolio", "male"),
            new Kitten(2, "Penka"),
            new Tomcat(10, "Nikodim"),
            new Frog(7.5, "Kermit", "male"),
            new Dog(12, "Kudjo", "male"),
            new Kitten(3.4, "Bianka")
        };

        foreach (var animal in animals)
        {
            animal.MakeSound();
        }

        Console.WriteLine();

        Animal.AverageAge(animals);
    }
}
