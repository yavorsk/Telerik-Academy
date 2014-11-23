using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Class
{
    public string Identifier { get; private set; }
    public List<Student> Students { get; private set;  }
    public List<Teacher> Teachers { get; private set; }
    public List<string> Comments { get; private set; }

    public Class(string classname)
    {
        this.Identifier = classname;
        this.Students = new List<Student>();
        this.Teachers = new List<Teacher>();
        this.Comments = new List<string>();
    }
}
