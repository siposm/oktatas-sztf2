namespace _05_example_complex
{
    class Neptun
    {
        public Student[] Students { get; set; }
        public int StudentIndex { get; private set; }

        public Neptun(int amount)
        {
            this.Students = new Student[amount];
            this.StudentIndex = 0;
        }

        public void AddStudent(Student student)
        {
            this.Students[StudentIndex++] = student;
        }

        public void AddGrade(ITeacherInterface student, int grade)
        {
            // Because of the interface reference, we can only do those, which are allowed by the interface! (exists in the interface)
            // We can also think of it as the ticket entry method receiving the entire default listener object, but since we want to hide certain things / make restrictions, we handle the listener through an interface.

            for (int i = 0; i < Students.Length; i++)
            {
                if (Students[i].NeptunCode == student.NeptunCode)
                {
                    student.ProgGrade = grade;
                }
            }
        }

        public void RequestDataForStudent(IRegistrarsOfficeInterface student)
        {
            Console.WriteLine(">> Name: {0} [{1}]", student.Name, student.NeptunCode);

            for (int i = 0; i < student.SubjectCounter; i++)
                Console.WriteLine("\t | {0}", student.Subjects[i].Name);
        }

        public void GetSubjects(IStudentInterface student)
        {
            student.ListSubjects();
        }

        public void ModifyPhoneNumber(IStudentInterface student, string newPhoneNumber)
        {
            student.PhoneNumber = newPhoneNumber;
        }
    }
}