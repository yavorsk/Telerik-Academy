using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.LinkedQueueDS
{
    class LinkedQueueY<T>
    {
        private LinkedList<T> queueList;

        public int Count { get; private set; }

        public LinkedQueueY()
        {
            this.queueList = new LinkedList<T>();
            this.Count = 0;
        }

        public void Enqueue(T value)
        {
            this.queueList.AddLast(value);
        }

        public T Dequeue()
        {
            if (this.queueList.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T dequeued = this.queueList.First.Value;
            this.queueList.RemoveFirst();

            return dequeued;
        }

        public T Peek()
        {
            if (this.queueList.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return this.queueList.First.Value;
        }

        public override string ToString()
        {
            return string.Join(", ", this.queueList);
        }
    }
}
