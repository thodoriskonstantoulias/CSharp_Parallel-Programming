using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentCollections
{
    public class ConcurrentDict
    {
        public static ConcurrentDictionary<string, string> capitals = new ConcurrentDictionary<string, string>();
        
        public static void AddParis()
        {
            // there is no add, since you don't know if it will succeed
            bool success = capitals.TryAdd("France", "Paris");
            string who = Task.CurrentId.HasValue ? ("Task " + Task.CurrentId) : "Main thread";
            Console.WriteLine($"{who} {(success ? "added" : "did not add")} the element");
        }
    }
}
