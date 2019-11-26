using System;

namespace ParallelLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            //Introducing Parallel Programming, Invoke, For, Foreach
            ParallelInvoke.ExecuteMethod();
            Console.WriteLine("---------------------------");

            //Introducing Parallel Cancellation 
            try
            {
                ParallelCancel.ExecuteMethod();
            }
            catch (OperationCanceledException oe)
            {
                Console.WriteLine(oe.Message);
            }
            catch (AggregateException ae)
            {
                ae.Handle(e =>
                {
                    Console.WriteLine(e.Message);
                    return true;
                });
            }
            Console.WriteLine("---------------------------");

            //Introducing Thread Local Storage
            ThreadLocalStor.ExecuteMethod();
            Console.WriteLine("---------------------------");

            //Introducing Partinioning (Benchmark comparison)
            Partitioning.ExecuteMethod();
            Console.WriteLine("---------------------------");

            Console.ReadKey();
        }
    }
}
