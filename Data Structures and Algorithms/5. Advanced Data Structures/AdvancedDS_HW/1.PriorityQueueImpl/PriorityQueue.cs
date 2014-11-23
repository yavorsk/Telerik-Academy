using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.PriorityQueueImpl
{
    public class PriorityQueue<T> where T : IComparable
    {
        BinaryHeap<T> container;

        public PriorityQueue()
        {
            this.container = new BinaryHeap<T>();
        }

        public void Enqueue(T value)
        {
            this.container.Add(value);
        }

        public T Dequeue()
        {
            return this.container.Pop();
        }

        public T Peek()
        {
            return this.container.Peek();
        }
    }
}
