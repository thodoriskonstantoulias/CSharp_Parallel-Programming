using System;
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


            Console.ReadKey();
        }
    }
}
