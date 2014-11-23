using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Discipline
{
    public string Name { get; set; }
    public int Lectures { get; set; }
    public int Exercises { get; set; }
    public List<string> Comments { get; private set; }

    public Discipline(string name, int lectures, int exercises)
    {
        this.Name = name;
        this.Lectures = lectures;
        this.Exercises = exercises;
        this.Comments = new List<string>();
    }
}
