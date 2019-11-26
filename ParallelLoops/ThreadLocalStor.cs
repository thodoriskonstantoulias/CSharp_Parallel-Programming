using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelLoops
{
    public class ThreadLocalStor
    {
        public static void ExecuteMethod()
        {
            int sum = 0;
            Parallel.For(1, 1001,
            () => 0, // initialize local state, show code completion for next arg
            (x, state, tls) =>
            {
                //Console.WriteLine($"{Task.CurrentId}");
                tls += x;
                Console.WriteLine($"Task {Task.CurrentId} has sum {tls}");
                return tls;
            },
            partialSum =>
            {
                Console.WriteLine($"Partial value of task {Task.CurrentId} is {partialSum}");
                Interlocked.Add(ref sum, partialSum);
            });
                Console.WriteLine($"Sum of 1..100 = {sum}");
            }
        
    }
}
