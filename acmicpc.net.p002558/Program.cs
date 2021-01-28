using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.p002558
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> values = new List<int>();

            while (values.Count() != 2)
            {
                var line1 = Console.ReadLine().Split().FirstOrDefault();
                var line2 = Console.ReadLine().Split().FirstOrDefault();

                values = from item in new string[] { line1, line2 }
                         where int.TryParse(item, out _)
                         select int.Parse(item);
            }

            Console.WriteLine(values.Sum());
        }
    }
}
