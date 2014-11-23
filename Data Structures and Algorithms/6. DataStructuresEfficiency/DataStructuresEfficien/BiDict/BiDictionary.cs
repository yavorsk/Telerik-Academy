using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiDict
{
    public class BiDictionary<K1, K2, T>
    {
        private Dictionary<K1, List<T>> firstKeyDict;
        private Dictionary<K2, List<T>> secondKeyDict;
        private Dictionary<string, List<T>> bothKeysDict;

        public BiDictionary()
        {
            this.firstKeyDict = new Dictionary<K1, List<T>>();
            this.secondKeyDict = new Dictionary<K2, List<T>>();
            this.bothKeysDict = new Dictionary<string, List<T>>();
        }

        public void Add(K1 key1, K2 key2, T value)
        {
            if (!this.firstKeyDict.ContainsKey(key1))
            {
                this.firstKeyDict[key1] = new List<T>();
            }
            this.firstKeyDict[key1].Add(value);

            if (!this.secondKeyDict.ContainsKey(key2))
            {
                this.secondKeyDict[key2] = new List<T>();
            }
            this.secondKeyDict[key2].Add(value);

            if (!this.bothKeysDict.ContainsKey(key1.ToString()+ key2.ToString()))
            {
                this.bothKeysDict[key1.ToString() + key2.ToString()] = new List<T>();
            }
            this.bothKeysDict[key1.ToString() + key2.ToString()].Add(value);
        }

        public List<T> FindByKey1(K1 key1)
        {
            return this.firstKeyDict[key1];
        }

        public List<T> FindByKey2(K2 key2)
        {
            return this.secondKeyDict[key2];
        }

        public List<T> FindByTwoKeys(K1 key1, K2 key2)
        {
            return this.bothKeysDict[key1.ToString() + key2.ToString()];
        }
    }
}
