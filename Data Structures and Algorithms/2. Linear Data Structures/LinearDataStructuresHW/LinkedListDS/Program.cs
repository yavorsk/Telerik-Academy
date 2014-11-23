using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListDS
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListY<int> testList = new LinkedListY<int>();

            testList.AddFirst(1);
            testList.AddLast(2);
            testList.AddLast(3);
            testList.AddLast(4);
            testList.AddLast(5);
            testList.AddLast(6);

            PrintLinkedList(testList);

            testList.AddAfter(new LinkedListItem<int>(3), 44);
            testList.AddBefore(new LinkedListItem<int>(5), 44);

            testList.RemoveFirst();
            testList.RemoveLast();

            PrintLinkedList(testList);

        }

        static void PrintLinkedList(LinkedListY<int> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
