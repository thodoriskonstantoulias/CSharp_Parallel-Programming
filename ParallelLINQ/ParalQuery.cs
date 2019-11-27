using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelLINQ
{
    public class ParalQuery
    {
        public static void ExecuteMethod()
        {
            const int count = 50;
            var items = Enumerable.Range(1, count).ToArray();
            var results = new int[count];

            items.AsParallel().ForAll(x =>
            {
                int newValue = x * x * x;
                Console.WriteLine($"{newValue} with task id : {Task.CurrentId}");
                results[x - 1] = newValue;
            });
            Console.WriteLine();

            var cubes = items.AsParallel().AsOrdered().Select(x => x* x *x);
            // this evaluation is delayed: you actually calculate the values only
            // when iterating or doing ToArray()
            foreach (var i in cubes)
            {
                Console.WriteLine(i);
            }
        }
    }
}
