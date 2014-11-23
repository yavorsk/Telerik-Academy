using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.LongestSubseqOfEqual
{
    // Write a method that finds the longest subsequence of equal numbers in given List<int> 
    // and returns the result as new List<int>. 
    // Write a program to test whether the method works correctly.

    public class LongestSubseqOfEqual
    {
        public static List<int> LongestSeqOfEqualElements(List<int> inputList)
        {
            int longestSequenceLength = 1;
            int longestSequenceElement = inputList[0];
            int currentSeqLengeth = 1;
            List<int> longestSequence = new List<int>();

            for (int i = 0; i < inputList.Count() - 1; i++)
            {
                if (inputList[i] == inputList[i + 1])
                {
                    currentSeqLengeth++;

                    if (currentSeqLengeth > longestSequenceLength)
                    {
                        longestSequenceLength = currentSeqLengeth;
                        longestSequenceElement = inputList[i];
                    }
                }
                else
                {
                    currentSeqLengeth = 1;
                }
            }

            for (int i = 0; i < longestSequenceLength; i++)
            {
                longestSequence.Add(longestSequenceElement);
            }

            return longestSequence;
        }
    }
}
