using System;
using System.Text;

// 1. Define a class Student, which contains data about a student – 
// first, middle and last name, SSN, permanent address, mobile phone, e-mail, course, specialty, university, faculty. 
// Use an enumeration for the specialties, universities and faculties. 
// Override the standard methods, inherited by  System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.
// 2. Add implementations of the ICloneable interface. The Clone() method should deeply copy all object's fields into
// a new object of type Student.
// 3. Implement the  IComparable<Student> interface to compare students by names (as first criteria, in lexicographic order) 
// and by social security number (as second criteria, in increasing order).

public class Studentt : ICloneable, IComparable<Studentt>
{
    private string firstName;
    private string middleName;
    private string lastName;
    private int ssn;
    private string address;
    private long? mobilePhone;
    private string email;
    private int course;
    private University university;
    private Specialty specialty;
    private Faculty faculty;

    #region properties

    public string FirstName
    {
        get
        {
            return firstName;
        }
        private set
        {
            firstName = value;
        }
    }

    public Specialty Specialty
    {
        get { return specialty; }
        set { specialty = value; }
    }
  
    public University University
    {
        get { return university; }
        set { university = value; }
    }
  
    public int Course
    {
        get { return course; }
        set { course = value; }
    }
  
    public string Email
    {
        get { return email; }
        set { email = value; }
    }
  
    public long? MobilePhone
    {
        get { return mobilePhone; }
        set { mobilePhone = value; }
    }
  
    public string Address
    {
        get { return address; }
        set { address = value; }
    }
  
    public int SSN
    {
        get { return ssn; }
        private set { ssn = value; }
    }
  
    public string LastName
    {
        get { return lastName; }
        private set { lastName = value; }
    }
  
    public string MiddleName
    {
        get { return middleName; }
        private set { middleName = value; }
    }
  
    public Faculty Faculty
    {
        get
        {
            return faculty;
        }
        set
        {
            faculty = value;
        }
    }

    #endregion

    #region constructors

    public Studentt(string firstName, string middleName, string lastName, int ssn, string address, long? mobilePhone,
        string email, int course, University university, Specialty specialty, Faculty faculty)
    {
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.LastName = lastName;
        this.SSN = ssn;
        this.Address = address;
        this.MobilePhone = mobilePhone;
        this.Email = email;
        this.Course = course;
        this.University = university;
        this.Specialty = specialty;
        this.Faculty = faculty;
    }
  
    public Studentt(string firstName, string middleName, string lastName, int ssn, string address,
        int course, University university, Specialty specialty, Faculty faculty) 
        : this(firstName, middleName, lastName, ssn, address, null, null, course, university, specialty, faculty)
    {
    }

    #endregion

    public override bool Equals(object param)
    {
        Studentt student = param as Studentt;

        if (student == null)
            return false;

        if (!Object.Equals(this.FirstName, student.firstName))
            return false;

        if (!Object.Equals(this.MiddleName, student.MiddleName))
            return false;

        if (!Object.Equals(this.LastName, student.LastName))
            return false;

        if (this.SSN != student.SSN)
            return false;

        return true;
    }

    public override int GetHashCode()
    {
        return this.FirstName.GetHashCode() ^ this.MiddleName.GetHashCode() ^ this.LastName.GetHashCode() ^ this.SSN.GetHashCode();
    }

    public static bool operator ==(Studentt stud1, Studentt stud2)
    {
        return Studentt.Equals(stud1, stud2);
    }

    public static bool operator !=(Studentt stud1, Studentt stud2)
    {
        return !Studentt.Equals(stud1, stud2);
    }

    public override string ToString()
    {
        StringBuilder studentInfo = new StringBuilder();
        studentInfo.AppendFormat("Name: {0} {1} {2}\n", this.FirstName, this.MiddleName, this.LastName);
        studentInfo.AppendLine(this.SSN.ToString());
        studentInfo.AppendLine(this.Address.ToString());
        studentInfo.AppendLine(this.MobilePhone.ToString());
        studentInfo.AppendLine(this.Email.ToString());
        studentInfo.AppendLine(this.Course.ToString());
        studentInfo.AppendLine(this.University.ToString());
        studentInfo.AppendLine(this.Specialty.ToString());
        studentInfo.AppendLine(this.Faculty.ToString());

        return studentInfo.ToString();
    }

    public object Clone()
    {
        Studentt copiedStudent = new Studentt(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.Address, this.MobilePhone, this.Email, this.Course, this.University, this.Specialty, this.Faculty);
        return copiedStudent;
    }

    public int CompareTo(Studentt other)
    {
        if (this.FirstName!=other.FirstName)
        {
            return this.FirstName.CompareTo(other.FirstName);
        }
        if (this.MiddleName!=other.MiddleName)
        {
            return this.MiddleName.CompareTo(other.MiddleName);
        }
        if (this.LastName!=other.LastName)
        {
            return this.LastName.CompareTo(other.LastName);
        }
        if (this.SSN != other.SSN)
        {
            return this.SSN-other.SSN;
        }

        return 0;
    }
}
