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
        //Introducing lock corrects the behaviour (check BankAccount class)
        //Then we introduced Interlocked instead of Lock with the same result
        //Another way is through SpinLock
        //We avoid Lock Recursion because it is dangerous 
        //Another way to sync data is Mutex
        //Finally we introduce Reader-Writer locks

        static ReaderWriterLockSlim padlock = new ReaderWriterLockSlim();
        static Random random = new Random();
        static void Main(string[] args)
        {
            var tasks = new List<Task>();
            var ba = new BankAccount();
            var ba2 = new BankAccount();
            int x = 0;

            //Reader-Writer Locks
            tasks.Add(Task.Factory.StartNew(() => 
            {
                padlock.EnterReadLock();

                Console.WriteLine($"Entered read lock x = {x}");
                Thread.Sleep(5000);

                padlock.ExitReadLock();
                Console.WriteLine($"Exited read lock x = {x}");
            }));
            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException ae)
            {
                ae.Handle(e =>
                {
                    Console.WriteLine(e);
                    return true;
                });
            }
            while (true)
            {
                Console.ReadKey();
                padlock.EnterWriteLock();
                Console.WriteLine("Write lock acquired");

                int newValue = random.Next(10);
                x = newValue;
                Console.WriteLine($"x = {x}");

                padlock.ExitWriteLock();
                Console.WriteLine("Write lock released");
            }
            //-----------------------------------------------------------------------------
            //Mutex example
            //Mutex mutex = new Mutex();
            //Mutex mutex2 = new Mutex();

            //for (int i = 0; i < 10; i++)
            //{
            //    tasks.Add(Task.Factory.StartNew(() =>
            //    {
            //        for (int i = 0; i < 1000; i++)
            //        {
            //            bool haveLock = mutex.WaitOne();
            //            try
            //            {
            //                ba.Deposit(1);
            //            }
            //            finally
            //            {
            //                if (haveLock) mutex.ReleaseMutex();
            //            }
            //        }
            //    }));
            //    tasks.Add(Task.Factory.StartNew(() =>
            //    {
            //        for (int i = 0; i < 1000; i++)
            //        {
            //            bool haveLock = mutex2.WaitOne();
            //            try
            //            {
            //                ba2.Deposit(1);
            //                //ba.Withdraw(100);
            //            }
            //            finally
            //            {
            //                if (haveLock) mutex2.ReleaseMutex();
            //            }                        
            //        }
            //    }));
            //    tasks.Add(Task.Factory.StartNew(() =>
            //    {
            //        for (int i = 0; i < 1000; i++)
            //        {
            //            bool haveLock = WaitHandle.WaitAll(new[] { mutex, mutex2 });
            //            try
            //            {
            //                ba.Transfer(ba2, 1);
            //            }
            //            finally
            //            {
            //                if (haveLock) 
            //                {
            //                    mutex.ReleaseMutex();
            //                    mutex2.ReleaseMutex();
            //                } 
            //            }
            //        }
            //    }));
            //}
            //-----------------------------------------------------------------------------
            //
            //Lock and Interlocked example
            //for (int i = 0; i < 10; i++)
            //{
            //    tasks.Add(Task.Factory.StartNew(() =>
            //    {
            //        for (int i = 0; i < 1000; i++)
            //        {
            //            ba.Deposit(100);
            //        }
            //    }));
            //    tasks.Add(Task.Factory.StartNew(() =>
            //    {
            //        for (int i = 0; i < 1000; i++)
            //        {
            //            ba.Withdraw(100);
            //        }
            //    }));
            //}
            //-----------------------------------------------------------------------------
            //SpinLock
            //var spinLock = new SpinLock();

            //for (int i = 0; i < 10; i++)
            //{
            //    tasks.Add(Task.Factory.StartNew(() =>
            //    {
            //        for (int i = 0; i < 1000; i++)
            //        {
            //            //SpinLock
            //            var lockTaken = false;
            //            try
            //            {
            //                spinLock.Enter(ref lockTaken);
            //                ba.Deposit(100);
            //            }
            //            finally
            //            {
            //                if (lockTaken)
            //                    spinLock.Exit();
            //            }

            //ba.Deposit(100);
            //    }
            //}));
            //tasks.Add(Task.Factory.StartNew(() =>
            //{
            //    for (int i = 0; i < 1000; i++)
            //    {
            //        //SpinLock
            //        var lockTaken = false;
            //        try
            //        {
            //            spinLock.Enter(ref lockTaken);
            //            ba.Withdraw(100);
            //        }
            //        finally
            //        {
            //            if (lockTaken)
            //                spinLock.Exit();
            //        }
            //ba.Withdraw(100);
            //    }
            //}));
            //}
            //-----------------------------------------------------------------------------
            //Task.WaitAll(tasks.ToArray());
            //Console.WriteLine($"Final balance of ba is {ba.Balance}");
            //Console.WriteLine($"Final balance of ba2 is {ba2.Balance}");


            //Lock Recursion example
            //LockRecursion(5);
            //-----------------------------------------------------------------------------
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
        //-----------------------------------------------------------------------------
    }
}
