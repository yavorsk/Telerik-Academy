using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.HashTableImplement
{
    class Program
    {
        static void Main()
        {
            HashTable<string, int> testTable = new HashTable<string, int>();

            for (int i = 0; i < 12; i++)
            {
                string key = "Pesho" + i;
                testTable.Add(key, i);
            }

            Console.WriteLine(testTable.Count);
            Console.WriteLine(testTable.Capacity);

            testTable.Add("Gosho", 26);
            testTable.Add("Ivan", 66);

            Console.WriteLine(testTable.Capacity);

            PrintTable(testTable);

            testTable.Clear();

            testTable.Add("Plamka", 2);
            PrintTable(testTable);
        }

        static void PrintTable(HashTable<string, int> table)
        {
            foreach (var pair in table)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }
    }
}
