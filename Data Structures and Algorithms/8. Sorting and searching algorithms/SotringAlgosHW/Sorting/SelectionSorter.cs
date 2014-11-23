namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                int indexOfMin = i;
                for (int j = i+1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[indexOfMin]) < 0)
                    {
                        indexOfMin = j;
                    }
                }

                if (indexOfMin != i)
                {
                    var temp = collection[i];
                    collection[i] = collection[indexOfMin];
                    collection[indexOfMin] = temp;
                }
            }
        }
    }
}
