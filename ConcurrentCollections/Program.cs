using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConcurrentCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            //Introducing Concurrent Dictionary
            Console.WriteLine("DICTIONARY");
            Console.WriteLine("-------------");
            Task.Factory.StartNew(ConcurrentDict.AddParis).Wait();
            ConcurrentDict.AddParis();

            //ConcurrentDict.capitals["Russia"] = "Leningrad";
            ConcurrentDict.capitals.AddOrUpdate("Russia", "Moscow", (key, oldVal) => oldVal + " --> Moscow");
            Console.WriteLine($"The capital of Russia is : { ConcurrentDict.capitals["Russia"]}");

            //ConcurrentDict.capitals["Sweden"] = "Uppsala";
            var capOfSweden = ConcurrentDict.capitals.GetOrAdd("Sweden", "Stockholm");
            Console.WriteLine($"The capital of Sweden is : {capOfSweden}");

            const string toRemove = "Russia";
            string removed;
            var didRemove = ConcurrentDict.capitals.TryRemove(toRemove,out removed);
            if (didRemove)
            {
                Console.WriteLine($"Removed {removed}");
            }
            else
            {
                Console.WriteLine($"Failed to remove the capital of {toRemove}");
            }
            //-------------------------------------------------------------------------------

            //Introducing Concurrent Queue
            Console.WriteLine("QUEUE");
            Console.WriteLine("-------------");
            ConcurrentQue.q.Enqueue(1);
            ConcurrentQue.q.Enqueue(2);
            int result;
            if (ConcurrentQue.q.TryDequeue(out result))
            {
                Console.WriteLine($"Removed element {result}");
            }
            if (ConcurrentQue.q.TryPeek(out result))
            {
                Console.WriteLine($"Front element is {result}");
            }
            //-------------------------------------------------------------------------------
            //Introducing Concurrent Stack
            Console.WriteLine("STACK");
            Console.WriteLine("-------------");
            ConcurrentStac.stack.Push(1);
            ConcurrentStac.stack.Push(2);
            ConcurrentStac.stack.Push(3);
            int result2;
            if (ConcurrentStac.stack.TryPeek(out result2))
            {
                Console.WriteLine($"{result2} is on top");
            }
            if (ConcurrentStac.stack.TryPop(out result2))
            {
                Console.WriteLine($"{result2} removed from stack");
            }
            //-------------------------------------------------------------------------------
            //Introducing Concurrent Bag
            Console.WriteLine("BAG");
            Console.WriteLine("-------------");
            // concurrent bag provides NO ordering guarantees
            // keeps a separate list of items for each thread
            // typically requires no synchronization, unless a thread tries to remove an item
            // while the thread-local bag is empty (item stealing)
            var tasks = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                var i1 = i;
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    ConcBag.bag.Add(i1);
                    Console.WriteLine($"{Task.CurrentId} has added {i1}");
                    int result3;
                    if (ConcBag.bag.TryPeek(out result3))
                    {
                        Console.WriteLine($"{Task.CurrentId} has peeked {result3}");
                    }
                }));
            }
            Task.WaitAll(tasks.ToArray());
            // take whatever's last
            int last;
            if (ConcBag.bag.TryTake(out last)){
                Console.WriteLine($"I got last the value : {last}");
            }


            Console.ReadKey();
        }
    }
}
