namespace _05_example_complex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // STUDENT 1.
            Student student1 = new Student(2);
            student1.NeptunCode = "ASD123";
            student1.Name = "John Doe";

            student1.RegisterSubject(new Subject
            {
                Name = "Programming I.",
                Credit = 6,
                Grade = 0
            });
            student1.RegisterSubject(new Subject
            {
                Name = "Maths I.",
                Credit = 5,
                Grade = 0
            });

            // STUDENT 2.
            Student student2 = new Student(3);
            student2.NeptunCode = "FFFA46";
            student2.Name = "Jane Doe";

            student2.RegisterSubject(new Subject
            {
                Name = "Software development III.",
                Credit = 6,
                Grade = 0
            });
            student2.RegisterSubject(new Subject
            {
                Name = "Linear Algebra",
                Credit = 5,
                Grade = 0
            }); 
            student2.RegisterSubject(new Subject
            {
                Name = "Advanced Development Techniques",
                Credit = 7,
                Grade = 0
            });


            Neptun neptun = new Neptun(10);
            neptun.AddStudent(student1);
            neptun.AddStudent(student2);
            
            neptun.RequestDataForStudent(student1);
            neptun.GetSubjects(student1);

            neptun.RequestDataForStudent(student2);
            neptun.GetSubjects(student2);
        }
    }
}