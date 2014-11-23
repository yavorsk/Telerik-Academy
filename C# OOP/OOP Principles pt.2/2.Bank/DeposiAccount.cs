
class DepositAccount : Account, IWithdrawable, IDepositable
{
    public DepositAccount(Customer client, decimal balance, decimal interest)
    {
        this.Client = client;
        this.Balance = balance;
        this.InterestRate = interest;
    }

    public override decimal CalculateInterestAmount(int months)
    {
        if (0< this.Balance && this.Balance < 1000)
        {
            return 0;
        }
        else
        {
            return base.CalculateInterestAmount(months);
        }
    }

    public void Deposit(decimal amountToDeposit)
    {
        this.Balance += amountToDeposit;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        this.Balance -= amountToWithdraw;
    }
}
