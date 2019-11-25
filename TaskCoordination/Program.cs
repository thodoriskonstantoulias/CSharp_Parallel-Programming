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

            Console.ReadKey();
        }
    }
}
