namespace _02_inheritance_ctor
{
    class ForeignStudent : Student
    {
        public ForeignStudent() : base("Test Name", 0)
        {

        }
        public ForeignStudent(string name, int age) : base(name, age)
        {

        }
    }
}