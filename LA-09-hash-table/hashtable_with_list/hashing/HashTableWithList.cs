using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashing
{
    class HashTableWithList<K, T> : HashTable<K, T>
    {
        class HashItem
        {
            public K key;
            public T value;
            public List<T> nextValues;
        }

        HashItem[] A;

        public HashTableWithList(int m) : base(m)
        {
            A = new HashItem[m];
        }


        public override void Insert(K key, T value)
        {
            if( A[h(key)] != null )
            {
                // already in use
                A[h(key)].nextValues.Add(value); // end of the list
            }
            else
            {
                HashItem newItem = new HashItem();
                newItem.key = key;
                newItem.value = value;
                newItem.nextValues = new List<T>();

                A[h(key)] = newItem;
            }
        }

        public override void Delete(K key)
        {
            if (A[h(key)] == null)
                throw new NoSuchKeyHashingException("No such key exists.");
            else
            {
                HashItem x = A[h(key)];
                if (x.nextValues.Count > 0)
                    x.nextValues.RemoveAt(x.nextValues.Count - 1);
                else
                    A[h(key)] = null;
            }
        }

        public override T Search(K key)
        {
            if( A[ h(key) ] == null )
                throw new NoSuchKeyHashingException("No such key exists.");
            else
            {
                HashItem x = A[h(key)];
                if (x.nextValues.Count > 0)
                    return x.nextValues.Last();
                else
                    return x.value;
            }
        }
    }
}
