namespace _03_virtual_methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[3];

            people[0] = new Student(19, "John Doe", "ASD123");
            people[1] = new Student(20, "Jane Doe", "OPWE23");
            people[2] = new Teacher(19, "Lorem Ipsum");


            // ==========================================================================
            // Using virtual methods (polymorphism)

            Console.WriteLine("\n=== SAYHELLO\n");
            for (int i = 0; i < people.Length; i++)
            {
                people[i].SayHello();
            }

            // ==========================================================================
            // Using non-virtual methods (*NO* polymorphism)

            Console.WriteLine("\n=== GREETINGS\n");
            for (int i = 0; i < people.Length; i++)
            {
                people[i].Greeting();
            }

            // ==========================================================================
            // virtual vs non virtual

            Console.WriteLine("\n---------------\n");
            
            // 1. using non-virtual methods
            Person e = new Person(40, "Első Person");
            e.Greeting();
            
            // 2. in Student class, using the 'new' keyword we hide the base's method
            Student h = new Student(30, "Első Hallgató", "ASD123");
            h.Greeting();


            // ==========================================================================
            // Handling types

            Console.WriteLine("\n---------------\n");

            int counter = 0;
            for (int i = 0; i < people.Length; i++)
            {
                if (people[i] is Student)
                {
                    counter++;
                    (people[i] as Student)?.Disenroll();
                }
            }
            Console.WriteLine("Student count: " + counter + " pcs");
        }
    }
}