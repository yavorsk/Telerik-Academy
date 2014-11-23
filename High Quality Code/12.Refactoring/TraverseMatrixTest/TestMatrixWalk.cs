using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TraverseMatrixTest
{
    [TestClass]
    public class TestMatrixWalk
    {
        [TestMethod]
        public void TestGenerateMatrixSize4()
        {
            int sizeOfMatrix = 4;
            int[,] expected = 
            {
                { 1, 10, 11, 12},
                { 9, 2, 15, 13},
                { 8, 16, 3, 14},
                { 7,  6, 5,  4}
            };
            int[,] actual = TraverseMatrix.GenerateMatrix(sizeOfMatrix);

            Assert.IsTrue(AreEqualMatrices(actual, expected));
        }

        [TestMethod]
        public void TestGenerateMatrixSize9()
        {
            int sizeOfMatrix = 9;
            int[,] expected = 
            {
                { 1, 25, 26, 27, 28, 29, 30, 31, 32},
                { 24, 2, 45, 46, 47, 48, 49, 50, 33},
                { 23, 61, 3, 44, 57, 58, 59, 51, 34},
                { 22, 75, 62, 4, 43, 56, 60, 52, 35},
                { 21, 74, 76, 63, 5, 42, 55, 53, 36},
                { 20, 73, 81, 77, 64, 6, 41, 54, 37},
                { 19, 72, 80, 79, 78, 65, 7, 40, 38},
                { 18, 71, 70, 69, 68, 67, 66, 8, 39},
                { 17, 16, 15, 14, 13, 12, 11, 10, 9}
            };
            int[,] actual = TraverseMatrix.GenerateMatrix(sizeOfMatrix);

            Assert.IsTrue(AreEqualMatrices(actual, expected));
        }

        [TestMethod]
        public void TestGenerateMatrixSize2()
        {
            int sizeOfMatrix = 2;
            int[,] expected = 
            {
                { 1, 4},             
                { 3, 2}
            };
            int[,] actual = TraverseMatrix.GenerateMatrix(sizeOfMatrix);

            Assert.IsTrue(AreEqualMatrices(actual, expected));
        }

        private bool AreEqualMatrices(int[,] firstArr, int[,] secondArr)
        {
            for (int i = 0; i < firstArr.GetLength(0); i++)
            {
                for (int j = 0; j < firstArr.GetLength(1); j++)
                {
                    if (firstArr[i,j] != secondArr[i,j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
