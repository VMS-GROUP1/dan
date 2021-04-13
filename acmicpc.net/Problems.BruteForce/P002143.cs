using System;
using System.Collections.Generic;

namespace acmicpc.net.Problems.BruteForce
{
    public class P002143
    {
        private static int t;
        private static int n;
        private static int m;
        public static void Main(string[] args)
        {
            t = int.Parse(Console.ReadLine().Trim());
            n = int.Parse(Console.ReadLine().Trim());
            int[] p1 = Array.ConvertAll(Console.ReadLine().Trim().Split(), x => int.Parse(x));
            m = int.Parse(Console.ReadLine().Trim());
            int[] p2 = Array.ConvertAll(Console.ReadLine().Trim().Split(), x => int.Parse(x));

            var a1 = GetSum(p1);
            var a2 = GetSum(p2);

            long ans = 0;
            foreach (var a in a1.Keys)
            {
                if (a2.TryGetValue(t - a, out var x) is false)
                    continue;

                ans += a1[a] * x;
            }

            Console.WriteLine(ans);
        }

        private static Dictionary<long, long> GetSum(int[] array)
        {
            Dictionary<long, long> ans = new Dictionary<long, long>();

            for (int i = 0; i < array.Length; i++)
            {
                long sum = 0;

                for (int j = i; j < array.Length; j++)
                {
                    sum += array[j];

                    if (ans.TryAdd(sum, 1) is false)
                        ans[sum] += 1;
                }
            }

            return ans;
        }
    }
}