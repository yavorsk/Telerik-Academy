using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class School
{
    public string SchoolName { get; private set; }
    public List<Class> Classes { get; set; }

    public School(string name)
    {
        this.SchoolName = name;
        Classes = new List<Class>();
    }
}
