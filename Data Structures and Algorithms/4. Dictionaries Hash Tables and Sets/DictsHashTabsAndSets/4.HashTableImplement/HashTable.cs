using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.HashTableImplement
{
    public class HashTable<K, T> : IEnumerable<KeyValuePair<K,T>>
    {
        private LinkedList<KeyValuePair<K, T>>[] container;
        private List<K> keys;
        private int count;

        public HashTable()
        {
            this.container = new LinkedList<KeyValuePair<K, T>>[16];
            this.keys = new List<K>();
        }

        public int Count
        {
            get { return this.count; }
            private set { }
        }

        public int Capacity
        {
            get { return this.container.Length; }
        }

        public List<K> Keys
        {
            get { return this.keys; }
            private set { }
        }

        public void Add(K key, T value)
        {
            if (this.ContainsKey(key))
            {
                throw new ArgumentException("There is already an element with this key in the hash table!");
            }

            if (this.Count >= 0.75 * this.Capacity)
            {
                ResizeTableContainer();
            }

            var indexInContainer = Math.Abs(key.GetHashCode() % this.Capacity);

            if (this.container[indexInContainer] == null)
            {
                this.container[indexInContainer] = new LinkedList<KeyValuePair<K, T>>();
            }

            this.keys.Add(key);
            this.count++;
            this.container[indexInContainer].AddLast(new KeyValuePair<K, T>(key, value));
        }

        public T Find(K key)
        {
            if (!this.ContainsKey(key))
            {
                throw new ArgumentException("Element with no such key exists in the table!");
            }

            var indexInContainer = Math.Abs(key.GetHashCode() % this.Capacity);

            var nodeToFind = this.container[indexInContainer].First;

            while (nodeToFind != null)
            {
                if (nodeToFind.Value.Key.Equals(key))
                {
                    break;
                }

                nodeToFind = nodeToFind.Next;
            }

            return nodeToFind.Value.Value;
        }

        public void Remove(K key)
        {
            if (!this.ContainsKey(key))
            {
                throw new ArgumentException("Element with no such key exists in the table!");
            }

            var indexInContainer = Math.Abs(key.GetHashCode() % this.Capacity);

            var nodeToRemove = this.container[indexInContainer].First;

            while (nodeToRemove != null)
            {
                if (nodeToRemove.Value.Key.Equals(key))
                {
                    break;
                }

                nodeToRemove = nodeToRemove.Next;
            }

            this.container[indexInContainer].Remove(nodeToRemove);
            this.keys.Remove(key);
            this.count--;
        }

        public void Clear()
        {
            foreach (var list in this.container)
            {
                if (list != null)
                {
                    list.Clear();                    
                }
            }

            this.Keys.Clear();
            this.Count = 0;
        }

        public T this[K key]
        {
            get
            {
                return this.Find(key);
            }
            set
            {
                this.Add(key, value);
            }
        }

        public bool ContainsKey(K key)
        {
            bool isFound = false;

            int indexInContainer = Math.Abs(key.GetHashCode() % this.Capacity);

            if (this.container[indexInContainer] != null)
            {
                var element = this.container[indexInContainer].First;

                while (element.Next != null)
                {
                    if (element.Value.Key.Equals(key))
                    {
                        isFound = true;
                        break;
                    }

                    element = element.Next;
                }
            }

            return isFound;
        }

        private void ResizeTableContainer()
        {
            var newCapacity = this.Capacity * 2;
            var newContainer = new LinkedList<KeyValuePair<K, T>>[newCapacity];

            foreach (var key in this.Keys)
            {
                var newIndex = Math.Abs(key.GetHashCode() % newCapacity);
                var oldIndex = Math.Abs(key.GetHashCode() % this.Capacity);

                newContainer[newIndex] = this.container[oldIndex];
            }

            this.container = newContainer;
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            for (int i = 0; i < this.container.Length; i++)
            {
                if (this.container[i] != null)
                {
                    foreach (var pair in this.container[i])
                    {
                        yield return pair;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
