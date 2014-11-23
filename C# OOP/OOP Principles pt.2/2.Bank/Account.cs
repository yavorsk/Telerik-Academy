
abstract class Account
{
    public Customer Client { get; protected set; }
    public decimal Balance { get; protected set; }
    public decimal InterestRate { get; protected set; }

    public virtual decimal CalculateInterestAmount(int months)
    {
        decimal amount = this.InterestRate * months;
        return amount;
    }
}
