using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Data;
using ATMdb.Model;
using System.Transactions;

namespace ATM.ConsoleClient
{
    class Program
    {
        static void Main()
        {
            var context = new ATMdbContext();

            //var cardOne = new CardAccount();
            //cardOne.CardCash = 200m;
            //cardOne.CardNumber = "1234567890";
            //cardOne.CardPin = "1234";

            //var cardTwo = new CardAccount();
            //cardTwo.CardCash = 100m;
            //cardTwo.CardNumber = "0987654321";
            //cardTwo.CardPin = "7890";

            //context.CardAccounts.Add(cardOne);
            //context.CardAccounts.Add(cardTwo);

            //context.SaveChanges();
            //Console.WriteLine("First and second card added...");

            bool transComplete = WithdrawMoney("1234567890", "1234", 66m, context);

            context.SaveChanges();

            if (transComplete)
            {
                Console.WriteLine("Transaction completed succesfully");
            }
            else
            {
                Console.WriteLine("Transaction aborted!");
            }
        }

        static bool WithdrawMoney(string cardNumber, string pinCode, decimal amountToWithdraw, ATMdbContext dbContext)
        {
            var moneyWithdrawalComplete = false;

            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.RequiresNew,
                        new TransactionOptions(){IsolationLevel = IsolationLevel.RepeatableRead}))
            {
                var card = (from c in dbContext.CardAccounts
                            where c.CardNumber == cardNumber
                            where c.CardPin == pinCode
                            select c).First();

                if (card != null && card.CardCash >= amountToWithdraw )
                {
                    card.CardCash -= amountToWithdraw;
                    transaction.Complete();
                    RecordWithdrawal(cardNumber, amountToWithdraw, dbContext);
                    moneyWithdrawalComplete = true;
                }
            }

            return moneyWithdrawalComplete;
        }

        static void RecordWithdrawal(string cardNumber, decimal ammount, ATMdbContext dbContext)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew,
                        new TransactionOptions(){IsolationLevel = IsolationLevel.RepeatableRead}))
            {
                dbContext.TransactionHistories.Add(new TransactionHistory()
                {
                    TransactionDate = DateTime.Now,
                    TransactionAmount = ammount,
                    CardNumber = cardNumber
                });
                scope.Complete();
            }
        }
    }
}
