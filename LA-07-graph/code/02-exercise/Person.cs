namespace _02_exercise
{
    class Person
    {
        public string? Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}