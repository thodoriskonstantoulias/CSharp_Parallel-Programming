using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelLINQ
{
    public class CancelLINQ
    {
        public static void ExecuteMethod()
        {
            var cts = new CancellationTokenSource();

            var items = ParallelEnumerable.Range(1, 20);
            var results = items.WithCancellation(cts.Token).Select(x =>
            {
                double result = Math.Log10(x);
                //if (result > 1) throw new InvalidOperationException();
                Console.WriteLine($"{result} with task id : {Task.CurrentId}");
                return result;
            });

            try
            {
                foreach (var c in results)
                {
                    if (c > 1)
                    {
                        cts.Cancel();
                    }
                    Console.WriteLine($"result = {c}");
                }
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine("Canceled");
            }
            catch (AggregateException ae)
            {
                ae.Handle(e =>
                {
                    Console.WriteLine($"{e.GetType().Name} : {e.Message}");
                    return true;
                });
            }
        }
    }
}
