using System;
using System.Collections.Generic;
using System.Threading;
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
            //SpinLock
            var spinLock = new SpinLock();

            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        //SpinLock
                        var lockTaken = false;
                        try
                        {
                            spinLock.Enter(ref lockTaken);
                            ba.Deposit(100);
                        }
                        finally
                        {
                            if (lockTaken)
                                spinLock.Exit();
                        }

                        //ba.Deposit(100);
                    }
                }));
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        //SpinLock
                        var lockTaken = false;
                        try
                        {
                            spinLock.Enter(ref lockTaken);
                            ba.Withdraw(100);
                        }
                        finally
                        {
                            if (lockTaken)
                                spinLock.Exit();
                        }
                        //ba.Withdraw(100);
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine($"Final balance is {ba.Balance}");


            //Lock Recursion example
            //LockRecursion(5);

            Console.ReadKey();
        }
        //static SpinLock spinLock = new SpinLock(true);
        //Example for Lock Recursion
        //public static void LockRecursion(int x)
        //{
        //    // lock recursion is being able to take the same lock multiple times

        //    var lockTaken = false;
        //    try
        //    {
        //        spinLock.Enter(ref lockTaken);
        //    }
        //    catch (LockRecursionException e)
        //    {
        //        Console.WriteLine("Exception : " + e);
        //    }
        //    finally
        //    {
        //        if (lockTaken)
        //        {
        //            Console.WriteLine($"Took a lock x = {x}");
        //            LockRecursion(x - 1);
        //            spinLock.Exit();
        //        }
        //        else
        //        {
        //            Console.WriteLine($"Failed to take a lock x = {x}");
        //        }
        //    }
        //}
    }
}
