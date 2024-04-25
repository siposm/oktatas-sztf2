namespace _02_hashtable
{
    public class HashTableWithOpenAddressing<K, T> : HashTable<K, T>
    {
        class HashItem
        {
            public K key;
            public T value;
            public bool deleted = false;
        }

        HashItem[] A;

        public HashTableWithOpenAddressing(int size) : base(size)
        {
            A = new HashItem[size];
            for (int i = 0; i < size; i++)
                A[i] = new HashItem();
        }

        protected virtual int h(K key, int j)
        {
            return (base.h(key) + j * 31) % size;
        }

        public override void Add(K key, T value)
        {
            int j = 0;
            while (j < size && A[h(key, j)].key != null && !A[h(key, j)].deleted) j++;

            if (j < size)
            {
                A[h(key, j)].key = key;
                A[h(key, j)].value = value;
                A[h(key, j)].deleted = false;
            }
            else throw new NoSpaceHashException("Error happened!");
        }

        public override T Find(K key)
        {
            int j = 0;
            while (j < size && A[h(key, j)].key != null && !(A[h(key, j)].key.Equals(key) && !A[h(key, j)].deleted)) j++;

            if (j < size && A[h(key, j)].key != null)
            {
                return A[h(key, j)].value;
            }
            else
                throw new NoSuchKeyHashException("Error happened!");
        }

        public override void Remove(K key)
        {
            int j = 0;
            while (j < size && A[h(key, j)].key != null && !(A[h(key, j)].key.Equals(key) && !A[h(key, j)].deleted)) j++;

            if (j < size && A[h(key, j)].key != null)
            {
                A[h(key, j)].deleted = true;
            }
            else
                throw new NoSuchKeyHashException("Error happened!");
        }
    }
}