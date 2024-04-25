namespace _02_hashtable
{
    public class HashTableWithLinkedList<K, T> : HashTable<K, T>
    {
        class HashItem
        {
            public K key;
            public T value;
            public HashItem next;
        }

        HashItem[] A;

        public HashTableWithLinkedList(int m) : base(m)
        {
            A = new HashItem[m];
        }

        public override void Add(K key, T value)
        {
            HashItem newItem = new HashItem();
            newItem.key = key;
            newItem.value = value;
            newItem.next = A[h(key)];
            A[h(key)] = newItem;
        }

        public override T Find(K key)
        {
            HashItem p = A[h(key)];
            while (p != null && !p.key.Equals(key)) p = p.next;
            if (p != null)
                return p.value;
            else
                throw new NoSuchKeyHashException("Error happened!");
        }

        public override void Remove(K key)
        {
            HashItem p = A[h(key)];
            HashItem e = null;
            while (p != null && !p.key.Equals(key))
            {
                e = p;
                p = p.next;
            }

            if (p != null)
                if (e == null)
                    A[h(key)] = p.next;
                else
                    e.next = p.next;
            else
                throw new NoSuchKeyHashException("Error happened!");
        }
    }
}