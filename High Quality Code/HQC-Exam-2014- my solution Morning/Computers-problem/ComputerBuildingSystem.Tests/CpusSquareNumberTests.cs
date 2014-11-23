using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComputersBuildingSystem;

namespace ComputerBuildingSystem.Tests
{
    [TestClass]
    public class CpusSquareNumberTests
    {
        [TestMethod]
        public void Cpu32BitSholdCalculateCorrectly()
        {
            Cpu processor = new Cpu(2, 32);

            string actual = processor.SquareNumber(25);
            string expected = "Square of 25 is 625.";

            Assert.AreEqual(actual, expected); 
        }

        [TestMethod]
        public void Cpu32BitSholdreturnErrorMessageIfParameterIsSmallerThanZero()
        {
            Cpu processor = new Cpu(2, 32);

            string actual = processor.SquareNumber(-1);
            string expected = "Number too low.";

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Cpu32BitSholdreturnErrorMessageIfParameterIsBiggerThanFiveHundred()
        {
            Cpu processor = new Cpu(2, 32);

            string actual = processor.SquareNumber(501);
            string expected = "Number too high.";

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Cpu64BitSholdCalculateCorrectly()
        {
            Cpu processor = new Cpu(2, 64);

            string actual = processor.SquareNumber(25);
            string expected = "Square of 25 is 625.";

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Cpu64BitSholdreturnErrorMessageIfParameterIsSmallerThanZero()
        {
            Cpu processor = new Cpu(2, 64);

            string actual = processor.SquareNumber(-1);
            string expected = "Number too low.";

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Cpu64BitSholdreturnErrorMessageIfParameterIsBiggerThanOneThousand()
        {
            Cpu processor = new Cpu(2, 64);

            string actual = processor.SquareNumber(1001);
            string expected = "Number too high.";

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Cpu128BitSholdCalculateCorrectly()
        {
            Cpu processor = new Cpu(2, 128);

            string actual = processor.SquareNumber(25);
            string expected = "Square of 25 is 625.";

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Cpu128BitSholdreturnErrorMessageIfParameterIsSmallerThanZero()
        {
            Cpu processor = new Cpu(2, 128);

            string actual = processor.SquareNumber(-1);
            string expected = "Number too low.";

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Cpu128BitSholdreturnErrorMessageIfParameterIsBiggerThanTwoThousand()
        {
            Cpu processor = new Cpu(2, 128);

            string actual = processor.SquareNumber(2001);
            string expected = "Number too high.";

            Assert.AreEqual(actual, expected);
        }
    }
}