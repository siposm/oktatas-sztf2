using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashing
{
    public abstract class HashTable<K,T>
    {
        protected int m;

        public HashTable(int m)
        {
            this.m = m;
        }

        protected virtual int h(K key)
        {
            return Math.Abs( key.GetHashCode() % m );
        }

        abstract public void Insert(K key, T value);
        abstract public T Search(K key);
        abstract public void Delete(K key);
    }
}
