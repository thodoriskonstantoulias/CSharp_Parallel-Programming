using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParallelLINQ
{
    public class MergeParLINQ
    {
        public static void ExecuteMethod()
        {
            // FullyBuffered = all results produced before they are consumed
            // NotBuffered = each result can be consumed right after it's produced
            // Default = AutoBuffered = buffer the number of results selected by the runtime

            var items = Enumerable.Range(1, 20).ToArray();
            var results = items.AsParallel().WithMergeOptions(ParallelMergeOptions.FullyBuffered).Select(x =>
            {
                var result = Math.Log10(x);
                Console.WriteLine($"Produced {result}");
                return result;
            });
            foreach (var result in results)
            {
                Console.WriteLine($"Consumed : {result}");
            }
        }
    }
}
