// 4. Create a class Person with two fields – name and age. Age can be left unspecified (may contain null value. 
// Override ToString() to display the information of a person and if age is not specified – to say so. 
// Write a program to test this functionality.

class Person
{
    public string Name { get; private set; }
    public int? Age { get; private set; }

    public Person(string name, int? age = null)
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        string result = string.Format("Name: {0}\nAge: {1}", this.Name, this.Age!=null ? this.Age.ToString() : "age not specified");
        return result;
    }
}
