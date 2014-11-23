using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4.HashTableImplement;
using System.Collections;

namespace _5.HashedSetImplement
{
    public class HashedSet<T> : IEnumerable<T>
    {
        private HashTable<int, T> container;

        public HashedSet()
        {
            this.container = new HashTable<int, T>();
        }

        public void Add(T value)
        {
            this.container.Add(value.GetHashCode(), value);
        }

        public void Remove(T value)
        {
            this.container.Remove(value.GetHashCode());
        }

        public bool Contains(T value)
        {
            return this.container.ContainsKey(value.GetHashCode());
        }

        public int Count
        {
            get { return this.container.Count; }
        }

        public void Clear()
        {
            this.container.Clear();
        }

        public HashedSet<T> Union(HashedSet<T> otherSet)
        {
            HashedSet<T> unifiedSet = new HashedSet<T>();

            foreach (var pair in this.container)
            {
                unifiedSet.Add(pair.Value);
            }

            foreach (var value in otherSet)
            {
                if (!unifiedSet.Contains(value))
                {
                    unifiedSet.Add(value);
                }
            }

            return unifiedSet;
        }

        public HashedSet<T> Intersect(HashedSet<T> other)
        {
            HashedSet<T> intersectedSet = new HashedSet<T>();

            foreach (var pair in this.container)
            {
                if (other.Contains(pair.Value))
                {
                    intersectedSet.Add(pair.Value);
                }
            }

            return intersectedSet;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var pair in this.container)
            {
                yield return pair.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
