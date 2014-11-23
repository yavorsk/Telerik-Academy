using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListDS
{
    class LinkedListY<T> : IEnumerable<T>
    {
        public LinkedListItem<T> First { get; set; }
        public LinkedListItem<T> Last { get; set; }

        public LinkedListY(LinkedListItem<T> first = null)
        {
            this.First = first;
            this.Last = first;
        }

        public void AddFirst(T value)
        {
            LinkedListItem<T> newNode = new LinkedListItem<T>(value);

            if (this.Count() == 0)
            {
                this.First = newNode;
                this.Last = newNode;
            }
            else
            {
                newNode.Next = this.First;
                this.First = newNode;
            }
        }

        public void AddLast(T value)
        {
            LinkedListItem<T> newNode = new LinkedListItem<T>(value);

            if (this.Count() == 0)
            {
                this.First = newNode;
                this.Last = newNode;
            }
            else
            {
                this.Last.Next = newNode;
                this.Last = newNode;
            }
        }

        public void AddAfter(LinkedListItem<T> item, T value)
        {
            LinkedListItem<T> currentItem = this.First;

            while (!currentItem.Equals(item))
            {
                currentItem = currentItem.Next;
            }

            LinkedListItem<T> newItem = new LinkedListItem<T>(value);
            newItem.Next = currentItem.Next;
            currentItem.Next = newItem;
        }

        public void AddBefore(LinkedListItem<T> item, T value)
        {
            LinkedListItem<T> currentItem = this.First;

            while (!currentItem.Next.Equals(item))
            {
                currentItem = currentItem.Next;
            }

            LinkedListItem<T> newItem = new LinkedListItem<T>(value);
            newItem.Next = currentItem.Next;
            currentItem.Next = newItem;
        }

        public void RemoveFirst()
        {
            if (this.Count() == 0)
            {
                throw new InvalidOperationException("The linked list is empty!");
            }
            else
            {
                this.First = this.First.Next;
            }
        }

        public void RemoveLast()
        {
            if (this.Count() == 0)
            {
                throw new InvalidOperationException("The linked list is empty!");
            }
            else
            {
                LinkedListItem<T> currentItem = this.First;

                while (currentItem.Next.Next != null)
                {
                    currentItem = currentItem.Next;
                }

                currentItem.Next = null;
            }
        }

        public int Count()
        {
            int count = 0;
            if (this.First == null)
            {
                count = 0;
            }
            else
            {
                LinkedListItem<T> currentItem = this.First;
                count = 1;

                while (currentItem.Next != null)
                {
                    currentItem = currentItem.Next;
                    count++;
                }
            }

            return count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListItem<T> item = this.First;

            while (item != null)
            {
                yield return item.Value;
                item = item.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
