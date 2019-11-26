using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCoordination
{
    public class Barriers
    {
        static Barrier barrier = new Barrier(2,b=> 
        {
            Console.WriteLine($"Phase {b.CurrentPhaseNumber} is finished");
        });

        public static void Water()
        {
            Console.WriteLine("Putting the kettle on (slow)");
            Thread.Sleep(2000);
            barrier.SignalAndWait();
            Console.WriteLine("Pouring water into the cup");
            barrier.SignalAndWait();
            Console.WriteLine("Putting the kettle away");
        }
        public static void Cup()
        {
            Console.WriteLine("Finding the cup (fast)");
            barrier.SignalAndWait();
            Console.WriteLine("Adding tea");
            barrier.SignalAndWait();
            Console.WriteLine("Adding sugar");
        }

        public static void ExecuteMethod()
        {
            var water = Task.Factory.StartNew(Water);
            var cup = Task.Factory.StartNew(Cup);

            var tea = Task.Factory.ContinueWhenAll(new[] { water, cup },tasks => 
            {
                Console.WriteLine("Enjoy your cup of tea");
            });
            tea.Wait();
        }
    }
}
