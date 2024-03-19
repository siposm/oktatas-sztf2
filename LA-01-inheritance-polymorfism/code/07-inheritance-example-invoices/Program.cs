namespace _07_inheritance_example_invoices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank UniObudaBank = new Bank(10);

            Owner jd = new Owner("John Doe");
            BankAccount acc1 = UniObudaBank.BankAccountnyitas(jd, 1000);
            BankAccount acc2 = UniObudaBank.BankAccountnyitas(jd, 0);

            Owner tp = new Owner("Test Person");
            UniObudaBank.BankAccountnyitas(tp, 2000);

            acc1.AddMoney(300);
            acc2.AddMoney(200);
            ((SavingsBankAccount)acc2).InterestCredit();

            acc1.RemoveMoney(500); // success
            acc2.RemoveMoney(500); // no success

            BankCard kartya = acc1.RequestBankCard("12345");
            kartya.Buy(500); // success
            kartya.Buy(500); // no success

            Console.WriteLine("John Doe full balance: " + UniObudaBank.AllBalance(jd));
            Console.WriteLine("John Doe's biggest balance: " + UniObudaBank.BankAccountWithBiggestBalance(jd).Balance);
            Console.WriteLine("All credit limit: " + UniObudaBank.AllCreditLimit());
        }
    }
}