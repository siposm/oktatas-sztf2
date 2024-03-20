namespace _02_linkedlist
{
    class LinkedList<T>
    {
        private ListItem? head;
        class ListItem
        {
            public T? value;
            public ListItem? next;
        }
        public void InsertToFront(T item)
        {
            ListItem newItem = new ListItem();
            newItem.value = item;
            newItem.next = head;

            head = newItem;
        }
        public void Traversal()
        {
            ListItem p = head;
            while (p != null)
            {
                ProcessListItem(p);
                p = p.next;
            }
        }
        private void ProcessListItem(ListItem item)
        {
            Console.WriteLine(item.value);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> myList = new LinkedList<int>();
            myList.InsertToFront(10);
            myList.InsertToFront(123);
            myList.InsertToFront(99);
            myList.InsertToFront(3);

            myList.Traversal();

            LinkedList<Person> myList2 = new LinkedList<Person>();
            myList2.InsertToFront(new Person() { Name = "Lajos" });
            myList2.InsertToFront(new Person() { Name = "Péter" });
            myList2.InsertToFront(new Person() { Name = "Tomi" });
            myList2.InsertToFront(new Person() { Name = "Kinga" });

            myList2.Traversal();

            LinkedList<KeyValuePair<string, Person>> myList3 = new LinkedList<KeyValuePair<string, Person>>();
        }
    }
}