using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceCountStrings.Library
{
    public class StringCountService : IStringCountService
    {
        public int CountSubstringsInString(string text, string substring)
        {
            int counter = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text.IndexOf(substring, i) != -1)
                {
                    counter++;
                    int index = text.IndexOf(substring, i);
                    i = index + substring.Length;
                }
            }

            return counter;
        }
    }
}
