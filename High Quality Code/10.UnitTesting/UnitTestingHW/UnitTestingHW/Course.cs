using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingHW
{
    public class Course
    {
        private const int maxNumberOfStudents = 29;
        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.AttendingStudents = new List<Student>();
        }

        public List<Student> AttendingStudents { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Course name can not be null or empty!");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public void AddStudent(Student newStudent)
        {
            if (this.AttendingStudents.Count == maxNumberOfStudents)
            {
                throw new ArgumentOutOfRangeException("This course is full, no more students can be added!");
            }
            else if (StudentIsInCourse(newStudent))
            {
                throw new ArgumentException("This student is allready attending the course!");
            }
            else
            {
                this.AttendingStudents.Add(newStudent);
            }
        }

        public void RemoveStudent(Student student)
        {
            if (this.AttendingStudents.Count == 0)
            {
                throw new ArgumentOutOfRangeException("This course is empty!");
            }
            else if (!StudentIsInCourse(student))
            {
                throw new ArgumentException("This student does not attend the course!");
            }
            else
            {
                this.AttendingStudents.Remove(student);
            }
        }

        private bool StudentIsInCourse(Student newStudent)
        {
            bool studentIsInCourse = false;

            for (int i = 0; i < this.AttendingStudents.Count; i++)
            {
                if (this.AttendingStudents[i].IdNumber == newStudent.IdNumber)
                {
                    studentIsInCourse = true;
                }
            }

            return studentIsInCourse;
        }
    }
}
