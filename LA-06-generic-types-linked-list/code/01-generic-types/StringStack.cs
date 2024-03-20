namespace _01_generic_types
{
    class StringStack
    {
        string[] items;
        int itemCounter;

        public StringStack(int size)
        {
            items = new string[size];
            itemCounter = 0;
        }

        public void Push(string item)
        {
            if (itemCounter == items.Length)
                throw new StackOverflowException("Error: Too many items...");
            else
                items[itemCounter++] = item;
        }

        public string Pop()
        {
            return items[--itemCounter];
        }

        public string Top()
        {
            return items[itemCounter - 1];
        }
    }
}