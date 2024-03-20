namespace _01_generic_types
{
    class IntStack
    {
        int[] items;
        int itemCounter;

        public IntStack(int size)
        {
            items = new int[size];
            itemCounter = 0;
        }

        public void Push(int item)
        {
            if (itemCounter == items.Length)
                throw new StackOverflowException("Error: Too many items...");
            else
                items[itemCounter++] = item;
        }

        public int Pop()
        {
            return items[--itemCounter];
        }

        public int Top()
        {
            return items[itemCounter - 1];
        }
    }
}