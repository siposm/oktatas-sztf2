namespace _02_inheritance_ctor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("John Doe", 22);
            student.NeptunCode = "ASD123";
            Console.WriteLine(student.NeptunCode);
            Console.WriteLine(student.Name);

            ForeignStudent fStudent = new ForeignStudent();
        }
    }
}