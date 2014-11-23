namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var result = this.MergeSort(collection);

            while (collection.Count > 0)
            {
                collection.RemoveAt(0);
            }

            for (int i = 0; i < result.Count; i++)
            {
                collection.Add(result[i]);
            }
        }

        private IList<T> MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            var left = new List<T>();
            var right = new List<T>();
            var middleIndex = collection.Count / 2;

            for (int i = 0; i < middleIndex; i++)
            {
                left.Add(collection[i]);
            }

            for (int i = middleIndex; i < collection.Count; i++)
            {
                right.Add(collection[i]);
            }

            left = MergeSort(left).ToList();
            right = MergeSort(right).ToList();

            return this.MergeSort(left, right);
        }

        private IList<T> MergeSort(List<T> left, List<T> right)
        {
            var result = new List<T>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left[0].CompareTo(right[0]) <= 0)
                    {
                        result.Add(left[0]);
                        left.RemoveAt(0);
                    }
                    else
                    {
                        result.Add(right[0]);
                        right.RemoveAt(0);
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else if (right.Count > 0)
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }

            return result;
        }
    }
}
