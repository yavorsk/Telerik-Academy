public class Character
{
    internal enum Sex
    {
        Male,
        Female
    }

    class Person
    {
        public Sex Sex { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public void PersonBuilder(int personAge)
    {
        Person newPerson = new Person();
        newPerson.Age = personAge;

        if (personAge % 2 == 0)
        {
            newPerson.Name = "Gosho";
            newPerson.Sex = Sex.Male;
        }
        else
        {
            newPerson.Name = "Gergana";
            newPerson.Sex = Sex.Female;
        }
    }
}
