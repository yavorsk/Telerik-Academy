using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingHW;

namespace TestSchool
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void ConstructorShouldAssignNameProperly()
        {
            string name = "pesho";
            int id = 12345;
            Student stud = new Student(name, id);
            Assert.AreEqual(stud.Name, name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorTestEmptyName()
        {
            string name = "";
            int id = 12345;
            Student stud = new Student(name, id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorTestNullName()
        {
            string name = null;
            int id = 12345;
            Student stud = new Student(name, id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorTestInvalidIDNumber()
        {
            string name = "pesho";
            int id = 9999;
            Student stud = new Student(name, id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorTestInvalidIDNumber2()
        {
            string name = "pesho";
            int id = 100000;
            Student stud = new Student(name, id);
        }

        [TestMethod]
        public void ConstructorShouldAssignIDNumberProperly()
        {
            string name = "pesho";
            int id = 12345;
            Student stud = new Student(name, id);
            Assert.AreEqual(stud.IdNumber, id);
        }
    }
}
