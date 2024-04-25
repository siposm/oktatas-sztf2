namespace _02_hashtable
{
    class Person
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return this.Name.ToUpper();
        }
    }
}