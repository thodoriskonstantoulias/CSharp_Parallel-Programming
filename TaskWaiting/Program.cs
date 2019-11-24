using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskWaiting
{
    class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            //Wait for time to pass 
            //var task = new Task(() =>
            //{
            //    Console.WriteLine("Press any key to disarm,you have 5 seconds");
            //    bool cancelled = token.WaitHandle.WaitOne(5000);
            //    Console.WriteLine(cancelled? "Bomb disarmed" : "BOOM");
            //},token);
            //task.Start();
            //Console.ReadKey();
            //cts.Cancel();
            //Waiting fot Tasks
            var task = new Task(() =>
            {
                Console.WriteLine("You have 5 seconds");
                for (int i = 0; i < 5; i++)
                {
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(1000);
                }
                Console.WriteLine("I am done");
            },token);
            task.Start();

            var task2 = Task.Factory.StartNew(() => Thread.Sleep(3000), token);

            //Wait for both tasks to finish
            //Task.WaitAll(task, task2);

            //Wait for any of the 2 tasks to finish
            Task.WaitAny(task, task2);

            Console.WriteLine($"Task task status is {task.Status}");
            Console.WriteLine($"Task task2 status is {task2.Status}");

            Console.WriteLine("Main program ended!");
            Console.ReadKey();
        }
    }
}
