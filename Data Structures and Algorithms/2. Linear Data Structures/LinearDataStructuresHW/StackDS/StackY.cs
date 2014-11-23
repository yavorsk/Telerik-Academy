using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDS
{
    class StackY<T>
    {
        private T[] stackArray;
        public int Count { get; private set; }

        public StackY()
        {
            this.stackArray = new T[8];
            this.Count = 0;
        }

        public void Push(T value)
        {
            if (this.Count < this.stackArray.Length)
            {
                this.stackArray[this.Count] = value;
                this.Count ++;
            }
            else
            {
                this.ResizeStack();
                this.stackArray[this.Count] = value;
                this.Count++;
            }
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            T popped = this.stackArray[this.Count-1];
            this.Count--;

            return popped;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            return this.stackArray[this.Count - 1];
        }

        public bool Contains(T value)
        {
            bool result = false;

            for (int i = 0; i < this.Count; i++)
            {
                if (this.stackArray[i].Equals(value))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private void ResizeStack()
        {
            T[] newStackArray = new T[this.Count * 2];

            for (int i = 0; i < this.Count; i++)
            {
                newStackArray[i] = this.stackArray[i];
            }

            this.stackArray = newStackArray;
        }
    }
}
