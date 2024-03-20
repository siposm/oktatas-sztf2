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

        static void SajatHashTeszt()
        {
            HashTable<string, int> hashTable = new HashTableWithLinkedList<string, int>(200);
            hashTable.Add("Peti", 1000);
            hashTable.Add("Laci", 500);
            hashTable.Add("Klari", 1500);
            hashTable.Add("Bela", 800);
            hashTable.Add("Csilla", 1800);

            Console.WriteLine(hashTable.Find("Peti"));
            Console.WriteLine(hashTable.Find("Laci"));
            Console.WriteLine(hashTable.Find("Klari"));
            Console.WriteLine(hashTable.Find("Bela"));
            Console.WriteLine(hashTable.Find("Csilla"));
        }

        static void Main(string[] args)
        {
            //HashError();
            SajatHashTeszt();
        }
    }
}