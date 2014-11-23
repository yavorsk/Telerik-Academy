using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.LinkedQueueDS
{
    class Program
    {
        static void Main()
        {
            LinkedQueueY<int> testQueue = new LinkedQueueY<int>();

            testQueue.Enqueue(5);
            testQueue.Enqueue(10);
            testQueue.Enqueue(8);
            testQueue.Enqueue(2);
            testQueue.Enqueue(15);

            Console.WriteLine(testQueue.ToString());

            Console.WriteLine(testQueue.Peek());
            Console.WriteLine(testQueue.Dequeue());
            Console.WriteLine(testQueue.Peek());

            testQueue.Enqueue(16);
            Console.WriteLine(testQueue.ToString());
        }
    }
}
