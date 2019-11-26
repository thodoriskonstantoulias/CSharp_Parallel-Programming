using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCoordination
{
    public class Semaphore
    {
        static SemaphoreSlim semaphore = new SemaphoreSlim(2,10);

        public static void ExecuteMethod()
        {
            for (int i = 0; i < 20; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine($"Entering task {Task.CurrentId}");
                    semaphore.Wait(); //ReleaseCount--
                    Console.WriteLine($"Processing task {Task.CurrentId}");
                });
            }
            while(semaphore.CurrentCount <= 2)
            {
                Console.WriteLine($"Semaphore count : {semaphore.CurrentCount}");
                Console.ReadKey();
                semaphore.Release(2); //ReleaseCount += 2
            }
        }
            
    }
}
