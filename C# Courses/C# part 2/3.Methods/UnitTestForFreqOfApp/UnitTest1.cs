using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForFreqOfApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] testArray = { 1, 2, 3, 4, 3 };
            int result = FrequencyOfAppearance.NumOfAppearance(3, testArray);
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            int[] testArray = { 1, 2, 3, 4, 3, 0, 0, 0, 0, 0 };
            int result = FrequencyOfAppearance.NumOfAppearance(0, testArray);
            Assert.AreEqual(5, result);
        }
        [TestMethod]
        public void TestMethod3()
        {
            int[] testArray = { 1, 2, 3, 4, 3, 1, 5, 12, 4, 1, 23, 1, 65, 12,  };
            int result = FrequencyOfAppearance.NumOfAppearance(1, testArray);
            Assert.AreEqual(4, result);
        }
    }
}
