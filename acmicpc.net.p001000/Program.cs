using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.p001000
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> values = from item in Console.ReadLine().Split()
                                      select int.Parse(item);
            
            Console.WriteLine(values.Sum());
        }
    }
}