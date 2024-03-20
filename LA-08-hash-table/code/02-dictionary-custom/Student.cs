namespace _02_hashtable
{
    class Student
    {
        public string Name { get; set; }

        public Student(string name)
        {
            this.Name = name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}