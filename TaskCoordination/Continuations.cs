using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskCoordination
{
    public class Continuations
    {
        public static void ExecuteExample()
        {
            var task = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Boiling water");
            });
            var task2 = task.ContinueWith(t =>
            {
                Console.WriteLine($"Completed task {t.Id}, pour water into cup");
            });
            task2.Wait();
        }
        public static void ExecuteExample2()
        {
            var task = Task.Factory.StartNew(() => "Task 1");
            var task2 = Task.Factory.StartNew(() => "Task 2");
            var task3 = Task.Factory.ContinueWhenAll(new[] { task, task2 }, tasks =>
               {
                   Console.WriteLine("Tasks completed");
                   foreach (var t in tasks)
                   {
                       Console.WriteLine(" - " + t.Result);
                       Console.WriteLine("All tasks done");
                   }
               });
            task3.Wait();
        }
    }
}
