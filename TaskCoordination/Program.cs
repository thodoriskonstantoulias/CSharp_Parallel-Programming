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


            //Introducing child tasks
            ChildTasks.ExecuteMethod();

            Console.ReadKey();
        }
    }
}
