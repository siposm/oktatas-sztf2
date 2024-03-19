namespace _07_inheritance_example_invoices
{
    public class SavingsBankAccount : BankAccount
    {
        public static double BaseInterest = 0.01;

        public double Interest { get; set; }

        public SavingsBankAccount(Owner owner) : base(owner)
        {
            this.Interest = BaseInterest;
        }

        public override bool RemoveMoney(int amount)
        {
            if (Balance - amount > 0)
            {
                Balance -= amount;
                return true;
            }
            else
                return false;
        }

        public void InterestCredit()
        {
            Balance = (int)((double)Balance * (1 + Interest));
        }
    }
}