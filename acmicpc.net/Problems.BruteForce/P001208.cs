using System;
using System.Collections.Generic;

namespace acmicpc.net.Problems.BruteForce
{
    public class P001208
    {
        private static int N;
        private static int S;
        private static int[] M;
        private static long ANS;
        public static void Main(string[] args)
        {
            int[] p = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            N = p[0];
            S = p[1];
            M = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            List<int> M1 = new List<int>();
            List<int> M2 = new List<int>();

            for (int i = 0; i < M.Length; i++)
            {
                int value = M[i];
                if (i < N / 2)
                    M1.Add(value);
                else
                    M2.Add(value);
            }

            Dictionary<long, long> count1 = new Dictionary<long, long>();
            Dictionary<long, long> count2 = new Dictionary<long, long>();
            ANS = 0;
            Do(M1, 0, 0, count1);
            Do(M2, 0, 0, count2);

            foreach (var pair in count1)
            {
                if (pair.Key == S)
                    ANS += pair.Value;

                if (count2.TryGetValue(S - pair.Key, out var x) is false)
                    continue;

                ANS += pair.Value * x;
            }

            ANS += count2.GetValueOrDefault(S);

            Console.WriteLine(ANS);
        }

        private static void Do(List<int> S, int x, long sum, Dictionary<long, long> count)
        {
            if (x == S.Count)
                return;

            int value = S[x];
            sum += value;
            if (count.TryAdd(sum, 1) is false)
                count[sum] += 1;

            Do(S, x + 1, sum - value, count);
            Do(S, x + 1, sum, count);
        }
    }
}