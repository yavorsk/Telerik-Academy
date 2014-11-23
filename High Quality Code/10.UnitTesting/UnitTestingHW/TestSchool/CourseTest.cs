using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingHW;


namespace TestSchool
{
    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void TestConstructorShouldAssignNameProperly()
        {
            string courseName = "Mathematics";

            Course mathCourse = new Course(courseName);

            Assert.AreEqual(mathCourse.Name, courseName);    
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorEmptyNameShouldThrowException()
        {
            string courseName = "";

            Course mathCourse = new Course(courseName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorNullNameShouldThrowException()
        {
            string courseName = null;

            Course mathCourse = new Course(courseName);
        }

        [TestMethod]
        public void TestConstructorShouldCreateStudentsList()
        {
            Course biologyCourse = new Course("biology");

            Assert.IsNotNull(biologyCourse.AttendingStudents);
        }

        [TestMethod]
        public void TestAddStudentShouldAddStudentProperly()
        {
            string courseName = "Mathematics";

            Course mathCourse = new Course(courseName);

            Student pesho = new Student("pesho", 12345);

            mathCourse.AddStudent(pesho);

            Assert.IsTrue(mathCourse.AttendingStudents.Contains(pesho));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddStudentShouldThrowExceptionIfStudentAllreadyAttending()
        {
            string courseName = "Mathematics";
            Course mathCourse = new Course(courseName);
            Student pesho = new Student("pesho", 12345);

            mathCourse.AddStudent(pesho);
            mathCourse.AddStudent(pesho);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAddStudentShouldThrowExceptionIfCourseFull()
        {
            string courseName = "Mathematics";
            Course mathCourse = new Course(courseName);

            mathCourse.AddStudent(new Student("pesho", 12344));
            mathCourse.AddStudent(new Student("gosho", 12343));
            mathCourse.AddStudent(new Student("kolio", 12342));
            mathCourse.AddStudent(new Student("asia", 12341));
            mathCourse.AddStudent(new Student("iana", 12340));
            mathCourse.AddStudent(new Student("iavor", 12346));
            mathCourse.AddStudent(new Student("ianush", 12347));
            mathCourse.AddStudent(new Student("samka", 12348));
            mathCourse.AddStudent(new Student("kala", 12349));
            mathCourse.AddStudent(new Student("nase", 12350));
            mathCourse.AddStudent(new Student("ice", 12351));
            mathCourse.AddStudent(new Student("tsanko", 12352));
            mathCourse.AddStudent(new Student("ivan", 12355));
            mathCourse.AddStudent(new Student("maria", 12353));
            mathCourse.AddStudent(new Student("pepa", 12354));
            mathCourse.AddStudent(new Student("maya", 12356));
            mathCourse.AddStudent(new Student("gogi", 12357));
            mathCourse.AddStudent(new Student("atila", 12358));
            mathCourse.AddStudent(new Student("sinan", 12359));
            mathCourse.AddStudent(new Student("denis", 12360));
            mathCourse.AddStudent(new Student("chakura", 12361));
            mathCourse.AddStudent(new Student("tsetso", 12362));
            mathCourse.AddStudent(new Student("jelez", 12363));
            mathCourse.AddStudent(new Student("dido", 12364));
            mathCourse.AddStudent(new Student("irena", 12365));
            mathCourse.AddStudent(new Student("emi", 12366));
            mathCourse.AddStudent(new Student("magdeto", 12367));
            mathCourse.AddStudent(new Student("sonia", 12368));
            mathCourse.AddStudent(new Student("zoza", 12369));
            mathCourse.AddStudent(new Student("roska", 12370));
        }

        [TestMethod]
        public void TestRemoveStudentShouldRemoveStudentProperly()
        {
            string courseName = "Mathematics";
            Course mathCourse = new Course(courseName);
            Student pesho = new Student("pesho", 12345);

            mathCourse.AddStudent(pesho);
            mathCourse.RemoveStudent(pesho);

            Assert.IsFalse(mathCourse.AttendingStudents.Contains(pesho));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemoveStudentShouldThrowExceptionIfCourseIsEmpty()
        {
            string courseName = "Mathematics";
            Course mathCourse = new Course(courseName);
            Student pesho = new Student("pesho", 12345);

            mathCourse.RemoveStudent(pesho);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveStudentShouldThrowExceptionIfStudentDoesNotAttendCourse()
        {
            string courseName = "Mathematics";
            Course mathCourse = new Course(courseName);

            Student pesho = new Student("pesho", 12345);
            mathCourse.AddStudent(pesho);
            Student gosho = new Student("gosho", 12222);
            mathCourse.RemoveStudent(gosho);
        }
    }
}
