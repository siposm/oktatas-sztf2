namespace _01_oop_auto_property
{
    class Person
    {
        public string Id { get; }
        public string? Name { get; private set; }
        public int Age { get; set; }

        public Person()
        {
            this.Id = "ASD123";
            // Id has only getter, value can be assigned only from constructor
        }

        public void SomeMethod()
        {
            this.Name = "___ some modification ___";
            // Name has private set, so it can be modified from inside the class

            //this.Id = "XYZ456";
            // not working from here, only from ctor
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Age = 26;
        }
    }
}