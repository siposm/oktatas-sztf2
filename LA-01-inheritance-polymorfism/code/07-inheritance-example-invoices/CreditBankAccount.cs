namespace _07_inheritance_example_invoices
{
    public class CreditBankAccount : BankAccount
    {
        public int CreditLimit { get; private set; }

        public CreditBankAccount(Owner owner, int creditLimit) : base(owner)
        {
            this.CreditLimit = creditLimit;
        }

        public override bool RemoveMoney(int amount)
        {
            if (Balance - amount >= -CreditLimit)
            {
                Balance -= amount;
                return true;
            }
            else
                return false;
        }
    }
}