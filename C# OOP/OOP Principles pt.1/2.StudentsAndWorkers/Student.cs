class Student : Human
{
    public int Grade { get; set; }

    public Student(string firstName, string secondName, int grade)
        : base(firstName, secondName)
    {
        this.Grade = grade;
    }
}
