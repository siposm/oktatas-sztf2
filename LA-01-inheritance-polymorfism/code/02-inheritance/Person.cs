namespace _02_inheritance_ctor
{
    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public void Greet()
        {
            Console.WriteLine($"Hi, my name is {Name}.");
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}