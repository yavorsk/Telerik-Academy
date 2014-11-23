namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var result = this.QuickSort(collection);

            while(collection.Count > 0)
            {
                collection.RemoveAt(0);
            }

            for (int i = 0; i < result.Count; i++)
            {
                collection.Add(result[i]);
            }
        }

        private IList<T> QuickSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            int pivotIndex = collection.Count / 2;
            T pivot = collection[pivotIndex];
            collection.RemoveAt(pivotIndex);

            List<T> lesser = new List<T>();
            List<T> greater = new List<T>();

            foreach (var item in collection)
            {
                if (item.CompareTo(pivot) <= 0)
                {
                    lesser.Add(item);
                }
                else
                {
                    greater.Add(item);
                }
            }

            var result = new List<T>();
            
            result.AddRange(this.QuickSort(lesser));
            result.Add(pivot);
            result.AddRange(this.QuickSort(greater));

            return result;
        }
    }
}
