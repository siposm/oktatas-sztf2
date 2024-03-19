namespace _03_virtual_methods
{
    public class Student : Person
    {
        public string NeptunCode { get; set; }

        public Student(int age, string name, string neptunCode) : base(age, name)
        {
            this.NeptunCode = neptunCode;
        }

        public void Enroll()
        {
            NeptunCode = GenerateCode();
        }

        private string GenerateCode()
        {
            // TODO: create neptun code generating algorithm
            return "ABC123";
        }

        public override void SayHello()
        {
            Console.WriteLine($"Hi my name is {Name} [{NeptunCode}] and I am {Age} years old.");
        }


        public new void Greeting()
        {
            Console.WriteLine("Hello, I am a STUDENT!");
        }

        public void Disenroll()
        {
            Console.WriteLine("Goodbye!");
        }
    }
}