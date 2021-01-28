using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.p001000
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> values = new List<int>();

            while (values.Count() != 2)
            {
                values = from item in Console.ReadLine().Split()
                        where int.TryParse(item, out _)
                        select int.Parse(item);
            }

            Console.WriteLine(values.Sum());
        }
    }
}
