using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelLoops
{
    public class Partitioning
    {
        [Benchmark]
        public void SquareEachValue()
        {
            const int count = 100000;
            var values = Enumerable.Range(0, count);
            var results = new int[count];
            Parallel.ForEach(values, x =>
             {
                 results[x] = (int) Math.Pow(x, 2);
             });
        }

        [Benchmark]
        public void SquareEachValueChunked()
        {
            const int count = 100000;
            var values = Enumerable.Range(0, count);
            var results = new int[count];

            var part = Partitioner.Create(0, count, 10000);
            Parallel.ForEach(part, range =>
             {
                 for (int i = range.Item1; i < range.Item2; i++)
                 {
                     results[i] = (int)Math.Pow(i, 2);
                 }
             });
        }
        public static void ExecuteMethod()
        {
            var summary = BenchmarkRunner.Run<Partitioning>();
            Console.WriteLine(summary);
        }
    }
}
