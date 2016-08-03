using BankSystem.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            //writes on the Console
            var bankAccount = new BankAccount(new ConsoleLogger())
            {
                Name = "Pesho"
            };

            bankAccount.Deposit(1000);
            bankAccount.Withdraw(100);
            Console.WriteLine(bankAccount.Money);

            //writes in the file
            var bankAccount2 = new BankAccount()
            {
                Name = "Didi"
            };

            bankAccount2.Deposit(500);
            bankAccount2.Withdraw(200);


        }
    }
}
