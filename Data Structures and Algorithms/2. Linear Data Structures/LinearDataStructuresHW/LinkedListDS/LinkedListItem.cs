using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListDS
{
    class LinkedListItem<T>
    {
        public T Value { get; set; }

        public LinkedListItem<T> Next {get; set; }

        public LinkedListItem(T value, LinkedListItem<T> next = null)
        {
            this.Value = value;
            this.Next = next;
        }

        public override bool Equals(object item)
        {
            // Check for null values and compare run-time types.
            if (item == null || GetType() != item.GetType())
                return false;

            LinkedListItem<T> otherItem = (LinkedListItem<T>)item;
            return this.Value.Equals(otherItem.Value);
        }
    }
}
