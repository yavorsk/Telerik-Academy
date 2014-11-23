namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        private Random random;

        public SortableCollection()
        {
            this.items = new List<T>();
            this.random = new Random();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
            this.random = new Random();
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            var result = false;

            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].Equals(item))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public bool BinarySearch(T item)
        {
            // Itereative

            int minIndex = 0;
            int maxIndex = this.Items.Count - 1;

            while (minIndex <= maxIndex)
            {
                int midIndex = (maxIndex - minIndex) / 2 + minIndex;

                if (this.Items[midIndex].CompareTo(item) < 0)
                {
                    minIndex = midIndex;
                }
                else if (this.Items[midIndex].CompareTo(item) > 0)
                {
                    maxIndex = midIndex;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                int randomIndex = i + random.Next(0, this.Items.Count - i);
                var temp = this.Items[i];
                this.Items[i] = this.Items[randomIndex];
                this.Items[randomIndex] = temp;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
