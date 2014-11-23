
class MortgageAccount : Account, IDepositable
{
        public MortgageAccount(Customer client, decimal balance, decimal interest)
    {
        this.Client = client;
        this.Balance = balance;
        this.InterestRate = interest;
    }

    public override decimal CalculateInterestAmount(int months)
    {
        if (this.Client is Individual)
        {
            if (months <= 6)
            {
                return 0;
            }
            else
            {
                return base.CalculateInterestAmount(months - 6);
            }
        }
        else //(this.Client is Company)
        {
            if (months <= 12)
            {
                return this.InterestRate / 2 * months;
            }
            else
            {
                return (this.InterestRate / 2 * 12) + this.InterestRate * (months - 12);
            }
        }
    }

    public void Deposit(decimal amountToDeposit)
    {
        this.Balance += amountToDeposit;
    }
}
