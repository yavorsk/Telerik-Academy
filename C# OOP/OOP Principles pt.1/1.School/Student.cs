using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Student : Person
{
    public int ClassNumber { get; set; }
    public List<string> Comments { get; private set; }

    public Student(string name, int classNumber) 
        : base(name)
    {
        this.ClassNumber = classNumber;
        this.Comments = new List<string>();
    }
}
