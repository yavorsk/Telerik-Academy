using System;
using System.Collections.Generic;

// 1. A bank holds different types of accounts for its customers: deposit accounts, loan accounts and mortgage accounts. 
// Customers could be individuals or companies.
//	All accounts have customer, balance and interest rate (monthly based). Deposit accounts are allowed to deposit and with draw money.
// Loan and mortgage accounts can only deposit money.
// All accounts can calculate their interest amount for a given period (in months). 
// In the common case its is calculated as follows: number_of_months * interest_rate.
// Loan accounts have no interest for the first 3 months if are held by individuals and for the first 2 months if are held by a company.
// Deposit accounts have no interest if their balance is positive and less than 1000.
// Mortgage accounts have ½ interest for the first 12 months for companies and no interest for the first 6 months for individuals.
// Your task is to write a program to model the bank system by classes and interfaces. 
// You should identify the classes, interfaces, base classes and abstract actions and implement 
// the calculation of the interest functionality through overridden methods.
// ctor propfull alt+F12

class BankTest
{
    static void Main()
    {
        List<Account> bankAccounts = new List<Account>()
        {
            new DepositAccount(new Individual("Gosho", 4325), 909.5M, 4M),
            new DepositAccount(new Company("Gogo Inc.", 4678), 909.5M, 4M),
            new LoanAccount(new Individual("Pepo", 1234), 4000M, 2M),
            new LoanAccount(new Company("Pepo & Co", 7899), 4000M, 2M),
            new MortgageAccount(new Individual("Vanio", 7789), 10000M, 3.5M),
            new MortgageAccount(new Company("Vanio 2000", 7788), 10000M, 3.5M)
        };

        int months = 6;

        foreach (var account in bankAccounts)
        {
            Console.WriteLine("Interest for {0} months of account = {1}", months, account.CalculateInterestAmount(months));
        }
    }
}
