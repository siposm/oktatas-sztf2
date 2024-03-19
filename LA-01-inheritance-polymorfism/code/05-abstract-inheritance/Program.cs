namespace _05_abstract_inheritance
{
    abstract class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            this.Name = name;
        }

        // Here we can't decide what this method will do.
        // So I mark here as 'abstract' and then in the descendant class I can decide later.
        public abstract void SayHello();
    }

    class Teacher : Person
    {
        public int LessonCounter { get; set; }

        public Teacher(string name) : base(name) { }

        public override void SayHello()
        {
            Console.WriteLine("Hello I am TEACHER.");
        }
    }

    class Student : Person
    {
        public string NeptunCode { get; set; }

        public Student(string name) : base(name) { }

        // Implement abstract class --> SayHello method will occur here
        // Now I can write whatever I want to.
        public override void SayHello()
        {
            Console.WriteLine("Hello I am STUDENT.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Teacher teacher = new Teacher("John Doe")
            {
                LessonCounter = 10
            };
        }
    }
}