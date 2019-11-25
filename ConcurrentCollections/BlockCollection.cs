using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConcurrentCollections
{
    public class BlockCollection
    {
        public static BlockingCollection<int> block = 
               new BlockingCollection<int>(new ConcurrentBag<int>(),10);

        public static CancellationTokenSource cts = new CancellationTokenSource(); 

    }
}
