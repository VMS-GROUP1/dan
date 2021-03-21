using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.Search
{
    public class P001654
    {
        public static void Main(string[] args)
        {
            long[] data = Array.ConvertAll(Console.ReadLine().Split(), x => long.Parse(x));
            long k = data[0];
            long n = data[1];

            List<long> cables = new List<long>();
            for (long i = 0; i < k; i++)
            {
                cables.Add(long.Parse(Console.ReadLine()));
            }

            Console.WriteLine(Search(cables, k, n));
        }

        public static long Search(List<long> cables, long k, long n)
        {
            long total = cables.Sum();
            long u = total / n;
            long l = cables.Min() / (long)Math.Ceiling((double)n / k);
            long ans = l;

            if (Check(cables, u, n))
                return u;

            while (l <= u)
            {
                long m = (l + u) / 2;

                if (Check(cables, m, n))
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

        private static bool Check(List<long> cables, long length, long n)
        {
            long count = 0;
            cables.ForEach(x => count += x / length);
            return count >= n;
        }
    }
}