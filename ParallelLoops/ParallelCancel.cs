using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelLoops
{
    public class ParallelCancel
    {
        private static ParallelLoopResult result;

        public static void ExecuteMethod()
        {
            var cts = new CancellationTokenSource();
            ParallelOptions po = new ParallelOptions();
            po.CancellationToken = cts.Token;

            result = Parallel.For(0, 20, po, (int x, ParallelLoopState state) =>
             {
                 Console.WriteLine($"{x} Task Id : {Task.CurrentId}");
                 if (x == 10)
                 {
                     //throw new Exception(); // execution stops on exception
                     //state.Stop(); // stop execution as soon as possible
                     //state.Break(); // request that loop stop execution of iterations beyond current iteration asap
                     cts.Cancel();
                 }
             });
            Console.WriteLine();
            Console.WriteLine($"Was loop completed? {result.IsCompleted}");
            if (result.LowestBreakIteration.HasValue)
            {
                Console.WriteLine($"Lowest break iteration : {result.LowestBreakIteration}");
            }
        }
    }
}
