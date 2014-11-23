namespace ATM.Data
{
    using ATM.Data.Migrations;
    using ATMdb.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ATMdbContext : DbContext
    {
        public ATMdbContext()
            : base("ATMDbConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ATMdbContext, Configuration>());
        }

        public IDbSet<CardAccount> CardAccounts { get; set; }

        public IDbSet<TransactionHistory> TransactionHistories { get; set; }
    }
}