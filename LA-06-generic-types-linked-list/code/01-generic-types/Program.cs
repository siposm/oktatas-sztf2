namespace _01_generic_types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IntStack intStack = new IntStack(5);
            intStack.Push(10);
            intStack.Push(20);
            intStack.Push(100);

            Console.WriteLine(intStack.Pop());
            Console.WriteLine(intStack.Top());
            Console.WriteLine(intStack.Pop());

            // ***********************************************************

            StringStack stringStack = new StringStack(5);
            stringStack.Push("apple");
            stringStack.Push("orange");
            stringStack.Push("kiwi");

            Console.WriteLine(stringStack.Pop());
            Console.WriteLine(stringStack.Top());
            Console.WriteLine(stringStack.Pop());

            // ***********************************************************

            GenericStack<string> genStack = new GenericStack<string>(5);
            genStack.Push("apple");
            genStack.Push("orange");
            genStack.Push("kiwi");

            Console.WriteLine(genStack.Pop());
            Console.WriteLine(genStack.Top());
            Console.WriteLine(genStack.Pop());

            try
            {
                genStack.Push("...");
                genStack.Push("...");
                genStack.Push("...");
            }
            catch (StackOverflowException exc)
            {
                Console.WriteLine("**ERROR**");
                Console.WriteLine(exc.Message);
            }

            // ***********************************************************

            GenericStack<Person> personStack = new GenericStack<Person>(3);
            personStack.Push(new Person() { Name = "P1" });
            personStack.Push(new Person() { Name = "P2" });
            personStack.Push(new Person() { Name = "P3" });

            Console.WriteLine("Top person's name: " + personStack.Top().Name);

            // ***********************************************************

            KeyValuePair<string, Person>[] peopleRegistry = new KeyValuePair<string, Person>[5];

            peopleRegistry[0].Key = "ASD123"; // id card number or neptun code...
            peopleRegistry[0].Value = new Person() { Name = "John Doe" };

            peopleRegistry[1].Key = "MLF345"; // id card number or neptun code...
            peopleRegistry[1].Value = new Person() { Name = "Jane Doe" };

            // ***********************************************************

            GenericStack<KeyValuePair<string, Person>> keyValuePairStack = new GenericStack<KeyValuePair<string, Person>>(3);

            keyValuePairStack.Push(new KeyValuePair<string, Person>
            {
                Key = "234KFA",
                Value = new Person() { Name = "Test Person" }
            });
        }
    }
}