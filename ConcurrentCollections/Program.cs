﻿using System;
using System.Threading.Tasks;

namespace ConcurrentCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            //Introducing Concurrent Dictionary
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

            Console.ReadKey();
        }
    }
}
