using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace ConcurrentCollections
{
    public class ConcurrentStac
    {
        public static ConcurrentStack<int> stack = new ConcurrentStack<int>();
    }
}
