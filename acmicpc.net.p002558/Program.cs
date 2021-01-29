using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.p002558
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> values = from item in Console.ReadLine().Split().Concat(Console.ReadLine().Split())
                                      select int.Parse(item);

            Console.WriteLine(values.Sum());
        }
    }
}
