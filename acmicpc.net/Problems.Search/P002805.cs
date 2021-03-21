using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.Search
{
    public class P002805
    {
        public static void Main(string[] args)
        {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            int n = data[0];
            int m = data[1];

            var wood = Console.ReadLine().Split().Select(x => long.Parse(x)).ToList();
            Console.WriteLine(Search(wood, m));
        }

        public static long Search(List<long> wood, int want)
        {
            long total = wood.Sum();
            long u = Math.Min(wood.Max(), wood.Max() - (long)Math.Floor((double)want / wood.Count));
            long l = Math.Max(0, wood.Min() - (long)Math.Ceiling((double)want / wood.Count));
            long ans = l;

            if (Check(wood, u, want))
                return u;

            while (l <= u)
            {
                long m = (l + u) / 2;

                if (Check(wood, m, want))
                {
                    ans = Math.Max(ans, m);
                    l = m + 1;
                }
                else
                {
                    u = m - 1;
                }
            }

            return ans;
        }

        private static bool Check(List<long> wood, long height, int m)
        {
            long mine = 0;
            wood.ForEach(x => mine += x - Math.Min(x, height));
            return mine >= m;
        }
    }
}