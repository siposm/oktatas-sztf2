namespace _02_inheritance_ctor
{
    class Student : Person
    {
        public string NeptunCode { get; set; }

        public Student(string name, int age) : base(name, age)
        {
        }

        public Student(string name, int age, string neptunCode) : base(name, age)
        {
            this.NeptunCode = neptunCode;
        }
    }
}