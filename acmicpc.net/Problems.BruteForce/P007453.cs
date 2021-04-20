using System;
using System.Collections.Generic;

namespace acmicpc.net.Problems.BruteForce
{
    public class P007453
    {
        private static int N;
        private static int[][] A;
        // private static int[] B;
        // private static int[] C;
        // private static int[] D;
        public static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());
            A = new int[4][];
            for (int i = 0; i < N; i++)
            {
                var p = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
                for (int j = 0; j < 4; j++)
                {
                    if (A[j] is null)
                        A[j] = new int[N];

                    A[j][i] = p[j];
                }
            }

            var count1 = GetSum(A[0], A[1]);
            var count2 = GetSum(A[2], A[3]);

            long ans = 0;
            foreach (var i in count1)
            {
                if (count2.TryGetValue(-i.Key, out var x) is false)
                    continue;

                ans += i.Value * x;
            }

            Console.WriteLine(ans);
        }

        private static Dictionary<long, long> GetSum(int[] A, int[] B)
        {
            Dictionary<long, long> count = new Dictionary<long, long>();

            for (int i = 0; i < A.Length; i++)
            {
                int a = A[i];

                for (int j = 0; j < B.Length; j++)
                {
                    long sum = a + B[j];
                    if (count.TryAdd(sum, 1) is false)
                        count[sum] += 1;
                }
            }

            return count;
        }
    }
}