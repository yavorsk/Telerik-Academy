using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingHW
{
    public class Student
    {
        private string name;
        private int idNumber;

        public Student(string name, int idNumber) 
        {
            this.Name = name;
            this.IdNumber = idNumber;
        }

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
                    throw new ArgumentException("Student name can not be null or empty!");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public int IdNumber
        {
            get 
            {
                return this.idNumber; 
            }
            set
            {
                if (value < 10000)
                {
                    throw new ArgumentOutOfRangeException("Student ID number should be bigger than 10000!");
                }
                else if (99999 < value)
                {
                    throw new ArgumentOutOfRangeException("Student ID number should be smaller than 99999!");                    
                }
                else
                {
                    this.idNumber = value;
                }
            }
        }
    }
}
