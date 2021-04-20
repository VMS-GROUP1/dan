using System;
using System.Collections.Generic;

namespace acmicpc.net.Problems.BruteForce
{
    public class P002632
    {
        private static int t;
        private static int n;
        private static int m;
        public static void Main(string[] args)
        {
            t = int.Parse(Console.ReadLine());
            int[] p1 = Array.ConvertAll(Console.ReadLine().Trim().Split(), x => int.Parse(x));
            m = p1[0];
            n = p1[1];

            int[] A = new int[m];
            int[] B = new int[n];
            for (int i = 0; i < m; i++)
            {
                A[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                B[i] = int.Parse(Console.ReadLine());
            }

            var a1 = GetSum(A);
            var a2 = GetSum(B);

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
            int length = array.Length;

            for (int i = 0; i < length; i++)
            {
                long sum = 0;

                for (int j = i; j < length + i; j++)
                {
                    int index = j;

                    if (j >= length)
                        index = j - length;

                    if (i > 0 && i - 1 == index)
                        break;

                    sum += array[index];
                    if (ans.TryAdd(sum, 1) is false)
                        ans[sum] += 1;
                }
            }

            ans.TryAdd(0, 1);

            return ans;
        }
    }
}