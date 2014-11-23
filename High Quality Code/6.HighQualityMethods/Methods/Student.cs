using System;

namespace Methods
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomeTown { get; set; }
        public string Hobby { get; set; }
        public DateTime BirthDate { get; set; }

        public Student(string fname, string lname, string bDate)
        {
            this.FirstName = fname;
            this.LastName = lname;

            DateTime date;

            if (!DateTime.TryParse(bDate, out date))
            {
                throw new FormatException("Wrong date format!");
            }

            this.BirthDate = date;
        }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate = this.BirthDate;
            DateTime secondDate = other.BirthDate;

            return firstDate < secondDate;
        }
    }
}
