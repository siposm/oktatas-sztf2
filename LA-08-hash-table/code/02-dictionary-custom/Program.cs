namespace _02_hashtable
{
    internal class Program
    {
        static void HashError()
        {
            Dictionary<Student, int> a = new Dictionary<Student, int>();
            Student h1 = new Student("John Doe");
            a.Add(h1, 1000);

            Student h2 = new Student("Jane Doe");
            a.Add(h2, 1500);

            Console.WriteLine(a[h1]);
            Console.WriteLine(a[h2]);

            h2.Name = "Lorem Ipsum";
            Console.WriteLine(a[h1]);
            Console.WriteLine(a[h2]);
        }

        static void HashTest()
        {
            HashTable<string, Person> hashTable = new HashTableWithLinkedList<string, Person>(200);
            hashTable.Add("ASD123", new Person() { Name = "Test Person 1" });
            hashTable.Add("KFL231", new Person() { Name = "Test Person 2" });
            hashTable.Add("JKL456", new Person() { Name = "Test Person 3" });
            hashTable.Add("NFA189", new Person() { Name = "Test Person 4" });
            hashTable.Add("MDL778", new Person() { Name = "Test Person 5" });

            Console.WriteLine(hashTable.Find("ASD123"));
            Console.WriteLine(hashTable.Find("KFL231"));
            Console.WriteLine(hashTable.Find("JKL456"));
            Console.WriteLine(hashTable.Find("NFA189"));
            Console.WriteLine(hashTable.Find("MDL778"));
        }

        static void Main(string[] args)
        {
            //HashError();
            HashTest();
        }
    }
}