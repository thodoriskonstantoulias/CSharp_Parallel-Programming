using System;

namespace ParallelLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //Introducing AsParallel and ParallelQuery
            ParalQuery.ExecuteMethod();
            Console.WriteLine("-------------------------");

            //Introducing AsParallel and ParallelQuery
            CancelLINQ.ExecuteMethod();
            Console.WriteLine("-------------------------");

            //Introducing Merge options
            MergeParLINQ.ExecuteMethod();
            Console.WriteLine("-------------------------");

            Console.ReadKey();
        }
    }
}
