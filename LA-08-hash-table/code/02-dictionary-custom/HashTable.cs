namespace _02_hashtable
{
    public abstract class HashTable<K, T>
    {
        protected int size;

        public HashTable(int size)
        {
            this.size = size;
        }

        protected virtual int h(K key)
        {
            return Math.Abs(key.GetHashCode() % size);
        }

        abstract public void Add(K key, T value);
        abstract public T Find(K key);
        abstract public void Remove(K key);
    }
}