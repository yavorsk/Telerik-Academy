class Worker : Human
{
    decimal WeekSalary { get; set; }
    double WorkHoursPerDay { get; set; }

    public Worker(string firstName, string secondName, decimal weekSalary, double workHoursDay)
        : base(firstName, secondName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursDay;
    }

    public decimal MoneyPerHour()
    {
        return WeekSalary / (decimal)(5 * WorkHoursPerDay);
    }
}