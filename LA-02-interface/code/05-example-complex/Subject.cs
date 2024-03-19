namespace _05_example_complex
{
    class Subject : IComparable
    {
        public string Name { get; set; }
        public int Grade { get; set; }
        public int Credit { get; set; }

        public void GetData()
        {
            Console.WriteLine("NAME: {0} - GRADE: {1} - CREDIT: {2}", Name, Grade, Credit);
        }

        public override string ToString()
        {
            return string.Format("[Subject: Name={0}, Grade={1}, Credit={2}]", Name, Grade, Credit);
        }

        public int CompareTo(object? obj)
        {
            return this.Credit.CompareTo((obj as Subject)?.Credit);
        }
    }
}