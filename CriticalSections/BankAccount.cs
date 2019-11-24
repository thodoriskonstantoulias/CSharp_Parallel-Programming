using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalSections
{
    public class BankAccount
    {
        public object padLock = new object();
        public int Balance { get; private set; }

        public void Deposit(int amount)
        {
            lock (padLock) 
            { 
                Balance += amount;
            }
        }
        public void Withdraw(int amount)
        {
            lock (padLock)
            {
                Balance -= amount;
            }
        }
    }
}
