using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Teacher: Person
{
    public List<Discipline> TeacharsDisciplines { get; set; }
    public List<string> Comments { get; private set; }

    public Teacher(string name)
        : base(name)
    {
        this.TeacharsDisciplines = new List<Discipline>();
        this.Comments = new List<string>();
    }
}
