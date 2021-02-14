using System;
using System.Collections;

namespace acmicpc.net.Problems.DP
{
    //제곱수의 합
    public class P001699
    {
        private static int[] Memo;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Solve1(n);
        }

        private static void Solve1(int n)
        {
            Memo = new int[n];

            for (int i = 0; i < n; i++)
            {
                Memo[i] = n;
                for (int j = 1; j * j <= i + 1; j++)
                {
                    int x = j * j;
                    Memo[i] = Math.Min(Memo[i], (x > i ? 0 : Memo[i - x]) + 1);
                }
            }

            Console.WriteLine(Memo[n - 1]);
        }
    }
}