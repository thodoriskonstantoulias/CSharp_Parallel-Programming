using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCoordination
{
    public class ResetEvents
    {
        static ManualResetEventSlim evt = new ManualResetEventSlim();
        static AutoResetEvent autoevt = new AutoResetEvent(false);

        public static void ExecuteMethod1()
        {
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Boiling water");
                evt.Set(); //true
            });
            var makeTea = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Waiting for water");
                evt.Wait(); //still true
                Console.WriteLine("Here is your tea");
            });
            makeTea.Wait();
        }

        public static void ExecuteMethod2()
        {
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Boiling water");
                autoevt.Set(); //set to true
            });
            var makeTea = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Waiting for water");
                autoevt.WaitOne(); //auto resets to false
                Console.WriteLine("Here is your tea");
                var ok = autoevt.WaitOne(1000);
                if (ok)
                {
                    Console.WriteLine("Enjoy your tea");
                }
                else
                {
                    Console.WriteLine("No tea for you");
                }
            });
            makeTea.Wait();
        }
    }
}
