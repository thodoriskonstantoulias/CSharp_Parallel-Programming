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
            var task = new Task(() =>
            {
                Console.WriteLine("Press any key to disarm,you have 5 seconds");
                bool cancelled = token.WaitHandle.WaitOne(5000);
                Console.WriteLine(cancelled? "Bomb disarmed" : "BOOM");
            },token);
            task.Start();

            Console.ReadKey();
            cts.Cancel();

            Console.WriteLine("Main program ended!");
            Console.ReadKey();
        }
    }
}
