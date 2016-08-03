using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Logics
{
    public class BankAccount
    {
        private ILogger logger;

        public BankAccount()
        {
            this.logger = new FileLogger();
        }

        public BankAccount(ILogger logger)
        {
            this.logger = logger;
        }
        
        public string Name { get; set; }
        public decimal Money { get; private set;  }

        public void Withdraw(decimal money)
        {
            if (this.Money < money)
            {
                throw new ArgumentException("Insificient value", "money");
            }

           this.logger.Log(string.Format("{0} withdraw {1}", this.Name, money));
           this.Money -= money;
        }
        public void Deposit(decimal money)
        {
            try
            {
                this.logger.Log(string.Format("{0} deposit {1}", this.Name, money));
            }
            catch
            {                
            }

            this.Money += money;
        }
    }
}
