using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParallelLoops
{
    public class ParallelInvoke
    {
        
        public static void ExecuteMethod()
        {
            var a = new Action(() => { Console.WriteLine($"First : {Task.CurrentId}"); });
            var b = new Action(() => { Console.WriteLine($"Second : {Task.CurrentId}"); });
            var c = new Action(() => { Console.WriteLine($"Third : {Task.CurrentId}"); });

            Parallel.Invoke(a, b, c);

            Parallel.For(1, 11, i =>
             {
                 Console.WriteLine($"{i*i}\t");
             });

            string[] words = {"one", "two", "three", "four" };
            Parallel.ForEach(words, word =>
            {
                Console.WriteLine($"{word} has length {word.Length} ,(task = {Task.CurrentId})");
            });
        }
    }
}
