using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CriticalSections
{
    class Program
    {
        //In our first try the desired result is not working because the methods are not atomic 
        //meaning that values are changing between tasks (simultaneously computations)
        //Intoducing lock corrects the behaviour (check BankAccount class)
        static void Main(string[] args)
        {           
            var tasks = new List<Task>();

            var ba = new BankAccount();

            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        ba.Deposit(100);
                    }
                }));
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        ba.Withdraw(100);
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine($"Final balance is {ba.Balance}");
            Console.ReadKey();
        }
    }
}
