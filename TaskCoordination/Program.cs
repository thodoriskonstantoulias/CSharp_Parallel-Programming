using System;
using System.Threading.Tasks;

namespace TaskCoordination
{
    class Program
    {
        static void Main(string[] args)
        {
            //Introducing Continuations
            Continuations.ExecuteExample();
            Continuations.ExecuteExample2();
            Console.WriteLine("-------------------");

            //Introducing child tasks
            ChildTasks.ExecuteMethod();
            Console.WriteLine("-------------------");

            //Introducing barrier
            Barriers.ExecuteMethod();
            Console.WriteLine("-------------------");

            //Introducing Countdown Event
            CountDownEvnt.ExecuteMethod();
            Console.WriteLine("-------------------");

            //Introducing Manual and Auto reset events 
            ResetEvents.ExecuteMethod1();
            ResetEvents.ExecuteMethod2();
            Console.WriteLine("-------------------");

            //Introducing Semaphore Slim
            Semaphore.ExecuteMethod();
            Console.WriteLine("-------------------");

            Console.ReadKey();
        }
    }
}
