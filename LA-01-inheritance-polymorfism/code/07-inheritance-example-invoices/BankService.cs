namespace _07_inheritance_example_invoices
{
    public abstract class BankService
    {
        public Owner Owner { get; set; }

        public BankService(Owner owner)
        {
            this.Owner = owner;
        }
    }
}