using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCancellation
{
    class Program
    {
        //We may want to cancel a Task 
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            //How to monitor the cancellation
            token.Register(() =>
            {
                Console.WriteLine("Cancellation requested");
            });


            var task = new Task(()=> 
            {
                int i = 0;
                while (true)
                {
                    //if (token.IsCancellationRequested)
                    //    break;
                    //    throw new OperationCanceledException();

                    //Shorter way of cancelling
                    token.ThrowIfCancellationRequested();
                    Console.WriteLine($"{i++}");
                    Thread.Sleep(100);
                }
            },token);
            task.Start();

            Console.ReadKey();
            cts.Cancel();

            Console.WriteLine("Main program ended");
            Console.ReadKey();
        }

    }
}
