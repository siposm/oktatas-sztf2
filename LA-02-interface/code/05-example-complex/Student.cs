namespace _05_example_complex
{
    class Student : IStudentInterface, IRegistrarsOfficeInterface, ITeacherInterface
    {
        public Subject[] Subjects { get; set; }
        public int SubjectCounter { get; private set; }
        public string? PhoneNumber { get; set; }
        public string? Name { get; set; }
        public string? NeptunCode { get; set; }
        public int ProgGrade
        {
            get
            {
                return FindGrade(new Subject() { Name = "Programozás II." });
            }
            set
            {
                Subjects[FindIndex(new Subject() { Name = "Programozás II." })].Grade = value;
            }
        }

        private int FindIndex(Subject subject)
        {
            for (int i = 0; i < SubjectCounter; i++)
                if (Subjects[i].Name == subject.Name)
                    return i;
            return -1;
        }

        private int FindGrade(Subject subject)
        {
            for (int i = 0; i < Subjects.Length; i++)
            {
                if (Subjects[i].Name== subject.Name)
                    return Subjects[i].Grade;
            }
            return -1;
        }

        public Student(int subjectCount)
        {
            Subjects = new Subject[subjectCount];
            SubjectCounter = 0;
        }

        public void RegisterSubject(Subject subject)
        {
            if (SubjectCounter < Subjects.Length)
                Subjects[SubjectCounter++] = subject;
        }

        public void ListSubjects()
        {
            Console.WriteLine("\nSUBJECTS \n");

            for (int i = 0; i < Subjects.Length; i++)
                Subjects[i].GetData();
        }
    }
}