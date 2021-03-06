﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using _4.LongestSubseqOfEqual;

namespace _04.LongestSubSOfEqualTest
{
    [TestClass]
    public class LongestSubSOfEqualTest
    {
        [TestMethod]
        public void ShouldFindSubsequenceCorrectly()
        {
            List<int> sequence = new List<int>() { 1, 1, 3, 6, 7, 7, 7, 4, 3 };

            List<int> result = LongestSubseqOfEqual.LongestSeqOfEqualElements(sequence);
            List<int> expected = new List<int>() { 7, 7, 7 };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NoSeqWithRepeatingElementsShouldReturnFirst()
        {
            List<int> sequence = new List<int>() { 1, 2, 3, 6, 7, 8, 7, 4, 3 };

            List<int> result = LongestSubseqOfEqual.LongestSeqOfEqualElements(sequence);
            List<int> expected = new List<int>() { 1 };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SequenceWithOneElement()
        {
            List<int> sequence = new List<int>() { 1 };

            List<int> result = LongestSubseqOfEqual.LongestSeqOfEqualElements(sequence);
            List<int> expected = new List<int>() { 1 };

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
