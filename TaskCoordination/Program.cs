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

            Console.ReadKey();
        }
    }
}
