namespace _01_generic_types
{
    class GenericStack<T>
    {
        T[] items;
        int itemCounter;

        public GenericStack(int size)
        {
            items = new T[size];
            itemCounter = 0;
        }

        public void Push(T item)
        {
            items[itemCounter++] = item;
        }
        public T Pop()
        {
            return items[--itemCounter];
        }
        public T Top()
        {
            return items[itemCounter - 1];
        }
    }
}