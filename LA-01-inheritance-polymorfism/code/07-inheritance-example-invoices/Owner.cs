namespace _07_inheritance_example_invoices
{
    public sealed class Owner
    {
        public string Name { get; set; }

        public Owner(string name)
        {
            this.Name = name;
        }
    }
}