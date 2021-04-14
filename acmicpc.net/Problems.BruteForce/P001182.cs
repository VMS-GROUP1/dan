using System;
using System.Collections.Generic;

namespace acmicpc.net.Problems.BruteForce
{
    public class P001182
    {
        private static int N;
        private static int S;
        private static int[] M;
        private static int ANS;
        public static void Main(string[] args)
        {
            int[] p = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            N = p[0];
            S = p[1];
            M = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));

            ANS = 0;
            Do(0, 0);
            Console.WriteLine(ANS);
        }

        private static void Do(int x, int sum)
        {
            if (x == N)
                return;

            int value = M[x];
            sum += value;
            if (sum == S)
            {
                ANS++;
            }

            Do(x + 1, sum - value);
            Do(x + 1, sum);
        }
    }
}