using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.PriorityQueueImpl
{
    class Program
    {
        static void Main()
        {
            var heap = new BinaryHeap<int>();

            heap.Add(5);
            heap.Add(22);
            heap.Add(4);
            heap.Add(6);
            heap.Add(3);
            heap.Add(15);
            heap.Add(12);
            heap.Add(33);
            heap.Add(14);

            Console.WriteLine(heap.Pop());
            Console.WriteLine(heap.Pop());
            Console.WriteLine(heap.Pop());
            Console.WriteLine(heap.Peek());
            Console.WriteLine(heap.Pop());
        }
    }
}
