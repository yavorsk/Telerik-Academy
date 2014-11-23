using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingHW
{
    public class School
    {
        public School()
        {
            this.Courses = new List<Course>();
        }

        public List<Course> Courses { get; set; }

        public void AddCourse(Course course)
        {
            this.Courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            if (this.Courses.Contains(course))
            {
                this.Courses.Remove(course);
            }
            else
            {
                throw new ArgumentException("The specified course is not in the school's list of courses!");
            }
        }
    }
}
