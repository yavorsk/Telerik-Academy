using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.PriorityQueueImpl
{
    public class BinaryHeap<T> where T : IComparable
    {
        private List<T> container;

        public BinaryHeap()
        {
            this.container = new List<T>();
        }

        public int Count
        {
            get
            {
                return this.container.Count;
            }
        }

        public void Add(T value)
        {
            this.container.Add(value);

            int index = this.container.Count - 1;
            T addedValue = this.container[index];
            int parentIndex = (index - 1) / 2;

            while (index > 0 && addedValue.CompareTo(this.container[parentIndex]) > 0)
            {
                this.container[index] = this.container[parentIndex];
                index = parentIndex;
                parentIndex = (parentIndex - 1) / 2;
            }

            this.container[index] = addedValue;
        }

        public T Pop()
        {
            int index = 0;
            var valueToPop = this.container[index];
            this.container[index] = this.container[this.container.Count - 1];
            this.container.RemoveAt(this.container.Count - 1);
            T movingValue = this.container[index];

            int currentIndex = 0, leftIndex = 0, rightIndex = 0;

            while (index < this.container.Count / 2)
            {
                leftIndex = 2 * index + 1;
                rightIndex = leftIndex + 1;
                if (rightIndex < this.container.Count && this.container[leftIndex].CompareTo(this.container[rightIndex]) < 0)
                {
                    currentIndex = rightIndex;
                }
                else
                {
                    currentIndex = leftIndex;
                }

                if (movingValue.CompareTo(this.container[currentIndex]) > 0)
                {
                    break;
                }

                this.container[index] = this.container[currentIndex];
                index = currentIndex;
            }

            this.container[index] = movingValue;

            return valueToPop;
        }

        public T Peek()
        {
            return this.container[0];
        }
    }
}
