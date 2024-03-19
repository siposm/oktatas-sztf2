namespace _07_inheritance_example_invoices
{
    public class BankCard : BankService
    {
        public BankCard(Owner owner, BankAccount account, string cardNumber) : base(owner)
        {
            this.Account = account;
            this.CardNumber = cardNumber;
        }

        public string CardNumber { get; set; }

        private BankAccount Account { get; set; }

        public bool Buy(int amount)
        {
            return Account.RemoveMoney(amount);
        }
    }
}