namespace _07_inheritance_example_invoices
{
    public class Bank
    {
        BankAccount[] accounts;
        int account_N;
        int account_Max;

        public Bank(int account_Max)
        {
            this.account_Max = account_Max;
            accounts = new BankAccount[account_Max];
        }

        public BankAccount? BankAccountnyitas(Owner owner, int creditLimit)
        {
            if (account_N == account_Max) return null;

            BankAccount newAccount;
            if (creditLimit > 0)
            {
                newAccount = new CreditBankAccount(owner, creditLimit);
            }
            else
            {
                newAccount = new SavingsBankAccount(owner);
            }
            accounts[account_N++] = newAccount;

            return newAccount;
        }

        public int AllBalance(Owner owner)
        {
            int sum = 0;
            for (int i = 0; i < account_N; i++)
            {
                if (accounts[i].Owner == owner)
                {
                    sum += accounts[i].Balance;
                }
            }
            return sum;
        }

        public BankAccount BankAccountWithBiggestBalance(Owner owner)
        {
            int max = -1;
            for (int i = 0; i < account_N; i++)
            {
                if (accounts[i].Owner == owner && (max == -1 || accounts[i].Balance > accounts[max].Balance))
                {
                    max = i;
                }
            }
            return accounts[max];
        }

        public int AllCreditLimit()
        {
            int sum = 0;
            for (int i = 0; i < account_N; i++)
            {
                if (accounts[i] is CreditBankAccount)
                {
                    sum += (accounts[i] as CreditBankAccount).CreditLimit;
                }
            }
            return sum;
        }
    }
}