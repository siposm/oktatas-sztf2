namespace _03_virtual_methods
{
    public class Person
    {

        public int Age { get; set; }
        public string Name { get; set; }

        public Person(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }

        public virtual void SayHello()
        {
            Console.WriteLine($"Hi my name is {Name} and I am {Age} years old.");
        }

        public void Greeting()
        {
            Console.WriteLine("Hello, I am a PERSON!");
        }
    }
}