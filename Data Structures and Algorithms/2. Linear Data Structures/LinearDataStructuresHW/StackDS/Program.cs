using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDS
{
    // Implement the ADT stack as auto-resizable array. 
    // Resize the capacity on demand (when no space is available to add / insert a new element).

    class Program
    {
        static void Main()
        {
            StackY<int> testStack = new StackY<int>();

            testStack.Push(15);
            testStack.Push(2);
            testStack.Push(3);
            testStack.Push(4);
            testStack.Push(15);
            testStack.Push(364);
            testStack.Push(3);
            testStack.Push(54);
            testStack.Push(13);

            Console.WriteLine(testStack.Peek());
            Console.WriteLine(testStack.Pop());
            Console.WriteLine(testStack.Peek());

            Console.WriteLine(testStack.Contains(364));
            Console.WriteLine(testStack.Contains(365));
        }
    }
}
