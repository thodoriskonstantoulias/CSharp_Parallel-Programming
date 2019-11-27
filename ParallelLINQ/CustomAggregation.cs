using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParallelLINQ
{
    public class CustomAggregation
    {
        // some operations in LINQ perform an aggregation
        //var sum = Enumerable.Range(1, 1000).Sum();
        //var sum = ParallelEnumerable.Range(1, 1000).Sum();


        // Sum is just a specialized case of Aggregate
        //var sum = Enumerable.Range(1, 1000).Aggregate(0, (i, acc) => i + acc);
        public static void ExecuteMethod()
        {
            //var sum = Enumerable.Range(1, 1000).Sum();
            var sum = ParallelEnumerable.Range(1, 1000)
                       .Aggregate(
                        0, // initial seed for calculations
                        (partialSum, i) => partialSum += i, // per task
                        (total, subtotal) => total += subtotal, // combine all tasks
                        i => i); // final result processing
                        Console.WriteLine($"sum = {sum}");
        }
        
    }
}
