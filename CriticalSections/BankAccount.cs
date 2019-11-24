using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CriticalSections
{
    // interlocked class contains atomic operations on variables
    // atomic = cannot be interrupted
    public class BankAccount
    {
        public object padLock = new object();
        private int balance;
        public int Balance { get { return balance; } private set { balance = value; } }

        //public void Deposit(int amount)
        //{
        //    lock (padLock) 
        //    { 
        //        Balance += amount;
        //    }
        //}
        //public void Withdraw(int amount)
        //{
        //    lock (padLock)
        //    {
        //        Balance -= amount;
        //    }
        //}

        //Introducing Interlocked operations
        //public void Deposit(int amount)
        //{
        //    Interlocked.Add(ref balance, amount);
        //}
        //public void Withdraw(int amount)
        //{
        //    Interlocked.Add(ref balance, -amount);
        //}

        //Introducing SpinLock
        public void Deposit(int amount)
        {
            balance += amount;
        }
        public void Withdraw(int amount)
        {
            balance -= amount;
        }
    }
}
