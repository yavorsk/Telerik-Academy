using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingHW;

namespace TestSchool
{
    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void TestConstructorShouldCreateCoursesList()
        {
            School mathSchool = new School();

            Assert.IsNotNull(mathSchool.Courses);
        }

        [TestMethod]
        public void TestAddCoursesShouldAddCoursesProperly()
        {
            School mathSchool = new School();
            Course math = new Course("math");

            mathSchool.AddCourse(math);

            Assert.IsTrue(mathSchool.Courses.Contains(math));
        }

        [TestMethod]
        public void TestRemoveCoursesShouldRemoveCoursesProperly()
        {
            School mathSchool = new School();
            Course math = new Course("math");

            mathSchool.AddCourse(math);
            mathSchool.RemoveCourse(math);

            Assert.IsFalse(mathSchool.Courses.Contains(math));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveCoursesShouldThrowExceptionIfSchoolDoesntContainCourse()
        {
            School mathSchool = new School();
            Course math = new Course("math");
            Course biology = new Course("biology");

            mathSchool.AddCourse(math);
            mathSchool.RemoveCourse(biology);
        }
    }
}
