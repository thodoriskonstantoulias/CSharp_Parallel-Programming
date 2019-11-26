using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCoordination
{
    public class CountDownEvnt
    {
        static int countTask = 5;
        static CountdownEvent cte = new CountdownEvent(countTask);
        static Random random = new Random();
        public static void ExecuteMethod()
        {
            for (int i = 0; i < countTask; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine($"Entering task {Task.CurrentId}");
                    Thread.Sleep(random.Next(3000));
                    cte.Signal();
                    Console.WriteLine($"Exiting task {Task.CurrentId}");
                });
            }
            var finalTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"Waiting for other tasks to complete in {Task.CurrentId}");
                cte.Wait();
                Console.WriteLine("All tasks completed");
            });
            finalTask.Wait();
        }
    }
}
