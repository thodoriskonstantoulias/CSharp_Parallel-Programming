using System;
using System.Threading.Tasks;

namespace Parallel_Programming
{
    class Program
    {
        static void Main(string[] args) 
        {
            //Conventional route
            //Write('a');

            //Task route
            //Task.Factory.StartNew(() => Write('.'));

            //Another way of calling a task method
            //Task.Factory.StartNew(Write, 123);

            //Using generic version of Task - Using 2 different calling methods
            string text1 = "testing";
            string text2 = "this";
            var task1 = new Task<int>(TextLength,text1);
            task1.Start();
            Task<int> task2 = Task.Factory.StartNew(TextLength, text2);

            Console.WriteLine($"The length of {text1} is {task1.Result}");
            Console.WriteLine($"The length of {text2} is {task2.Result}");


            Console.WriteLine("Main program done!");
            Console.ReadLine();
        }

        public static void Write(char c)
        {
            int i = 1000;
            while(i-- > 0)
            {
                Console.Write(c);
            }
        }
        public static void Write(object o)
        {
            int i = 1000;
            while (i-- > 0)
            {
                Console.Write(o);
            }
        }
        public static int TextLength(object o)
        {
            Console.WriteLine($"\n Task with id : {Task.CurrentId} processing object {o}");
            return o.ToString().Length;
        }
    }

    // Summary:

    // 1. Two ways of using tasks
    //    Task.Factory.StartNew() creates and starts a Task
    //    new Task(() => { ... }) creates a task; use Start() to fire it
    // 2. Tasks take an optional 'object' argument
    //    Task.Factory.StartNew(x => { foo(x) }, arg);
    // 3. To return values, use Task<T> instead of Task
    //    To get the return value. use t.Result (this waits until task is complete)
    // 4. Use Task.CurrentId to identify individual tasks.

}
