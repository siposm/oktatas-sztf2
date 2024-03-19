namespace _07_inheritance_example_invoices
{
    public abstract class BankAccount : BankService
    {
        public BankAccount(Owner owner) : base(owner)
        {
        }

        public int Balance { get; protected set; }

        public void AddMoney(int amount)
        {
            Balance += amount;
        }

        public abstract bool RemoveMoney(int amount);

        public BankCard RequestBankCard(string cardNumber)
        {
            return new BankCard(Owner, this, cardNumber);
        }
    }
}