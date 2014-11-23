
class LoanAccount : Account, IDepositable
{
    public LoanAccount(Customer client, decimal balance, decimal interest)
    {
        this.Client = client;
        this.Balance = balance;
        this.InterestRate = interest;
    }

    public override decimal CalculateInterestAmount(int months)
    {
        if (this.Client is Individual)
        {
            if (months <= 3)
            {
                return 0;
            }
            else
            {
                return base.CalculateInterestAmount(months-3);
            }
        }
        else //(this.Client is Company)
        {
            if (months <= 2)
            {
                return 0;
            }
            else
            {
                return base.CalculateInterestAmount(months - 2);
            }
        }
    }

    public void Deposit(decimal amountToDeposit)
    {
        this.Balance += amountToDeposit;
    }
}
